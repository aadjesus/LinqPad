<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Excecao.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
  <Namespace>Globus5.WPF.Comum</Namespace>
  <Namespace>System.Web.Services.Protocols</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.gestaoDeFrotaOnline</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.globus</Namespace>
</Query>

void Main()
{
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");

	Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.Url.Dump();
	sEscalaControleOperacionalRelatorios[] escalaControleOperacionalRelatorios = Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarCumprimentodeViagens(
	new DateTime(2011,11,20,0,0,0),
	new DateTime(2011,11,20,23,59,59),
	new int[] {29737},
	false);

	 LinhaDTO[] listaLinhasResultado = WebServices.GlobusWSApp.RetornarLinhaPeloCodigoInterno(escalaControleOperacionalRelatorios
					.Select(s => s.CodIntLinha)
					.Distinct()
					.ToArray());
	listaLinhasResultado
		.ToList()
		.ForEach(f=> f.FlgCircular = "N");		
	
	 var resultado = escalaControleOperacionalRelatorios
					.Join(listaLinhasResultado,
							a => a.CodIntLinha,
							b => b.CodIntLinha,
							(a, b) => new
							{
								Linha = a.CodigoLinha.Concatenar('-', a.DescricaoLinha, (b.FlgCircular.Equals("S") ? "C" : "R")),
								a.CodigoFl,
								a.CodIntLinha,
								a.CodigoLinha,
								a.DescricaoLinha,
								Sentido = a.Sentido.Equals("I") ? "Ida" : "Volta",
								a.CodigoServico,
								a.CodigoHorario,
								a.Sequencia,
								a.CodLocalidade,
								a.HoraLocalProg,
								a.HoraLocalRea,
								a.PrefixoVeiculo,
								a.QtdViagemProgramada,
								a.QtdViagemRealizada,
								Circular = b.FlgCircular.Equals("S"),
								DividePor = b.FlgCircular.Equals("S") ? 2 : 1, 
								ValorParaCalculo = b.FlgCircular.Equals("S") ? 0.5 : 1.0,
							});
							
				#region delegate

				Func<int, double> delegateCalculoViagem =
					delegate(int codIntLinha)
					{
						try
						{
							return resultado
									.Where(w => w.CodIntLinha.Equals(codIntLinha))
									.SingleOrDefault()
									.ValorParaCalculo;
						}
						catch (Exception)
						{
							return 1;
						}
					};

				Func<int, double, double, double> delegateCalculoViagemRealizada =
					delegate(int codIntLinha, double qtdeProg, double qtdeReal)
					{
						double percentual = 0;
						try
						{
							percentual = ((qtdeReal / qtdeProg) * 100);
						}
						catch
						{
						}

						if (percentual >= spnEdtViagemRealizadaMinimo)
							//return 1;
							return delegateCalculoViagem(codIntLinha);
						else if (percentual >= spnEdtViagemNaoRealizadaMaximo)
							//return 0.5;
							return delegateCalculoViagem(codIntLinha);
						else
							return 0;
					};

				#endregion

				#region Grupo de Filial\Linha\Servico\Horario

				var grupoFilLinSerHor = resultado
					.GroupBy(g => new
					{
						g.CodigoFl,
						g.CodIntLinha,
						g.CodigoServico
					}
					, (key, lista2) => new
					{
						Chave = key,
						Lista = lista2
							.GroupBy(g2 => g2.CodigoHorario)
							.OrderBy(o => o.Key)
							.Select((s1, index) => new
							{
								Index = index + 1,
								CodigoFl = key.CodigoFl,
								CodigoHorario = s1.Key,
								Circular = s1.FirstOrDefault().Circular,
								CodigoServico = key.CodigoServico,
								CodIntLinha = key.CodIntLinha,
								ContPontoControleProgramada = s1.Sum(sm => sm.QtdViagemProgramada),
								ContPontoControleRealizada = s1.Sum(sm => sm.QtdViagemRealizada),
								HoraPriLoca = s1.OrderBy(o => o.Sequencia).Min(m => m.HoraLocalRea),
								HoraUltLoca = s1.OrderBy(o => o.Sequencia).Max(m => m.HoraLocalRea)
							})
							.OrderBy(o => o.CodigoHorario)
					})
					.SelectMany(s => s.Lista)
					.ToArray();

				#endregion

				#region Grupo de Filial\Linha\Servico

				var grupoFilLinSer = resultado
					.GroupBy(g => new
					{
						g.CodigoFl,
						g.CodIntLinha,
						g.CodigoServico,
					}
					, (chave, listaGrupo) => new
					{
						CodigoFl = chave.CodigoFl,
						CodIntLinha = chave.CodIntLinha,
						CodigoServico = chave.CodigoServico,
						Qtde = listaGrupo.Count(),

						ViagemServicoProgramado = listaGrupo.FirstOrDefault().ValorParaCalculo * listaGrupo.GroupBy(g => g.CodigoHorario).Count(),
						ViagemServicoRealizado = listaGrupo
							.GroupBy(g => g.CodigoHorario)
							.Where((w, index) => ((index + 1) % listaGrupo.FirstOrDefault().DividePor).Equals(0))
							.Sum(sm => delegateCalculoViagemRealizada(
											chave.CodIntLinha,
											listaGrupo.Sum(sm1 => sm1.QtdViagemProgramada), // sm.Sum(sm1 => sm1.QtdViagemProgramada),  
											listaGrupo.Sum(sm1 => sm1.QtdViagemRealizada)))	// sm.Sum(sm1 => sm1.QtdViagemRealizada)))
					});

				#endregion

				#region Grupo de Filial\Linha

				var grupoFilLin = grupoFilLinSer
					.GroupBy(g => new
					{
						g.CodigoFl,
						g.CodIntLinha
					})
					.Select(s => new
					{
						s.Key.CodigoFl,
						s.Key.CodIntLinha,
						ViagemLinhaProgramado = s.Sum(sm => sm.ViagemServicoProgramado),
						ViagemLinhaRealizado = s.Sum(sm => sm.ViagemServicoRealizado)
					});

				#endregion

				#region Grupo de Filial

				var grupoFil = grupoFilLin
					.GroupBy(g => g.CodigoFl)
					.Select(s => new
					{
						CodigoFl = s.Key,
						ViagemFilialProgramado = s.Sum(sm => sm.ViagemLinhaProgramado),
						ViagemFilialRealizado = s.Sum(sm => sm.ViagemLinhaRealizado)
					});

				#endregion

				#region Lista

				var resultadoNovo = from a in resultado
									join b in Globus5.WPF.Comum.WebServices.ControleWSApp.RetornarFiliaisPorEmpresa(14) on a.CodigoFl equals b.CodigoFl into join_Filial
									from b in join_Filial.DefaultIfEmpty()
									join c in Globus5.WPF.Comum.WebServices.EscalaWSApp.RetornarLocais() on a.CodLocalidade equals c.CodLocalidade into join_Locais
									from c in join_Locais.DefaultIfEmpty()

									join d in grupoFilLinSer on new { a.CodigoFl, a.CodIntLinha, a.CodigoServico } equals new { d.CodigoFl, d.CodIntLinha, d.CodigoServico } into join_FilLinSer
									from d in join_FilLinSer.DefaultIfEmpty()

									join f in grupoFilLinSerHor on new { a.CodigoFl, a.CodIntLinha, a.CodigoServico, a.CodigoHorario } equals new { f.CodigoFl, f.CodIntLinha, f.CodigoServico, f.CodigoHorario } into join_FilLinSerHor
									from f in join_FilLinSerHor.DefaultIfEmpty()

									join g in grupoFilLin on new { a.CodigoFl, a.CodIntLinha } equals new { g.CodigoFl, g.CodIntLinha } into join_FilLin
									from g in join_FilLin.DefaultIfEmpty()

									join h in grupoFil on a.CodigoFl equals h.CodigoFl into join_Fil
									from h in join_Fil.DefaultIfEmpty()
									select new
									{
//										a.CodigoFl,
//										Filial = a.CodigoFl.ToString("000") + " - " + b.EmpresaAutorizadaOBJ.NomeFantasiaEmpresa,
//										a.CodIntLinha,
//										a.Linha,
//										a.Sentido,
//										a.CodigoServico,
//										a.CodigoHorario,
//										a.Sequencia,
//										a.CodLocalidade,
//										Local = a.CodLocalidade.ToString() + " - " + c.DescLocalidade,
//										HoraSaidaProg = a.HoraLocalProg.ToString("HH:mm"),
//										HoraSaidaRea = a.HoraLocalRea.ToString("HH:mm"),
//										a.PrefixoVeiculo,
//										Servico = "Serviço: " + a.CodigoServico.PadLeft(grupoFilLinSer.Max(m => m.CodigoServico.Length), '0'),
//										Partida = "Partida: " + a.CodigoHorario.ToString(),
//
										f.ContPontoControleProgramada,
										f.ContPontoControleRealizada,
										f.Index,
										ViagemHorarioPercentual = (f.Index % a.DividePor).Equals(0)
														 ? (grupoFilLinSerHor
																 .Where(w => w.CodigoFl.Equals(a.CodigoFl) &&
																			 w.CodIntLinha.Equals(a.CodIntLinha) &&
																			 w.CodigoServico.Equals(a.CodigoServico) &&
																			 Array.IndexOf(new int[] { f.Index - (f.Circular ? 1 : 0), f.Index }, w.Index) != -1)
																 .Sum(sm => sm.ContPontoControleRealizada) /
															grupoFilLinSerHor
																 .Where(w => w.CodigoFl.Equals(a.CodigoFl) &&
																			 w.CodIntLinha.Equals(a.CodIntLinha) &&
																			 w.CodigoServico.Equals(a.CodigoServico) &&
																			 Array.IndexOf(new int[] { f.Index - (f.Circular ? 1 : 0), f.Index }, w.Index) != -1)
																 .Sum(sm => sm.ContPontoControleProgramada)).ToString("#0.## %")
														 : ""
														 //,
//										d.ViagemServicoProgramado,
//										d.ViagemServicoRealizado,
//										ViagemServicoPercentual = d.ViagemServicoRealizado / d.ViagemServicoProgramado,
//
//										g.ViagemLinhaProgramado,
//										g.ViagemLinhaRealizado,
//										ViagemLinhaPercentual = g.ViagemLinhaRealizado / g.ViagemLinhaProgramado,
//
//										h.ViagemFilialProgramado,
//										h.ViagemFilialRealizado,
//										ViagemFilialPercentual = h.ViagemFilialRealizado / h.ViagemFilialProgramado,
//
//										ViagemGeralProgramado = grupoFil.Sum(sm => sm.ViagemFilialProgramado),
//										ViagemGeralRealizado = grupoFil.Sum(sm => sm.ViagemFilialRealizado),
//										ViagemGeralPercentual = grupoFil.Sum(sm => sm.ViagemFilialRealizado) / grupoFil.Sum(sm => sm.ViagemFilialProgramado),
//
//										HoraPriLoca = f.HoraPriLoca.Equals(DateTime.MinValue) ? "" : f.HoraPriLoca.ToString("HH:mm"),
//										HoraUltLoca = f.HoraUltLoca.Equals(DateTime.MinValue) ? "" : f.HoraUltLoca.ToString("HH:mm"),
//										TotalHora = f.HoraUltLoca > f.HoraPriLoca && !f.HoraPriLoca.Equals(DateTime.MinValue) ? f.HoraUltLoca.Add(-f.HoraPriLoca.TimeOfDay).ToString("HH:mm") : ""
									};
				#endregion
				
				resultadoNovo.OrderBy(o => o.Index).Dump();
	
}

public double spnEdtViagemRealizadaMinimo= 75;
public double spnEdtViagemNaoRealizadaMaximo= 50;
public enum eValorSoma
{
	Um,
	Meio
}