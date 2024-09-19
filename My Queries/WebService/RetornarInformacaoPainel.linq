<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Excecao.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
  <Namespace>Globus5.WPF.Comum.ws.gestaoDeFrotaOnline</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.escala</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.globus</Namespace>
  <Namespace>Globus5.WPF.Comum</Namespace>
</Query>

List<int> listaCodIntLinha = new List<int>();
DateTime dataHoraConsulta;

private void Main()
{
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");
	
	PainelInformativoDTO painelInformativoDTO =  new PainelInformativoDTO() {CodigoEmpresa=8, CodigoFl = 9,CodPainel = 6, CodLocalidade = 4105};
	
	dataHoraConsulta = Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarDataHoraBanco()
		.Dump("dataHoraConsulta")
		;	
	LocaisDTO locaisDTO = Globus5.WPF.Comum.WebServices.EscalaWSApp.RetornarLocaisPorChave(painelInformativoDTO.CodLocalidade)
	//.Dump("locaisDTO")
	;	
	
	IList<PainelInformativoLinhaDTO> listaPainelInformativoLinhaDTO = Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarLinhaAssociadaAoPainelInformativo(
		painelInformativoDTO.CodigoEmpresa, 
		painelInformativoDTO.CodigoFl, 
		painelInformativoDTO.CodPainel).Dump("PainelInformativoLinhaDTO");	
	
	IList<LinhaDTO> listaLinhaDTO = new List<LinhaDTO>();

	// Verifica se existe linha no painel informado
	bool informouLinha = listaPainelInformativoLinhaDTO != null && listaPainelInformativoLinhaDTO.Count() > 0;

	if (informouLinha)
	{
		// Pesquisa linhas do painel
		listaCodIntLinha = listaPainelInformativoLinhaDTO
			.GroupBy(g => g.CodIntLinha)
			.Select(s => s.Key)
			.ToList();
		listaLinhaDTO = Globus5.WPF.Comum.WebServices.GlobusWSApp.RetornarLinhaPeloCodigoInterno(listaCodIntLinha.ToArray())
		//.Dump("LinhaDTO")
		;
	}	
				
	 ItinerarioHorarioItensDTO[] listaItinerarioLocalInformado = RetornarItinerarioHorarioItensDTO()
		.Where(w=> w.CodLocalidade.Equals(locaisDTO.CodLocalidade))
		.ToArray().Dump("listaItinerarioLocalInformado");	

	if (listaItinerarioLocalInformado.Length == 0)
		throw new Exception("NenhumRegEncontParaPesquisa");
	
	ItinerarioServicoDTO[] listaItinerarioServicoLocalInformado = RetornarItinerarioServicoDTO(listaItinerarioLocalInformado)
		//.Dump("listaItinerarioServicoLocalInformado")
		;

	ControleOperacionalAtualDTO[] controleOperacionalAtualDTO = Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarUltimaDeteccaoDoVeiculoLinha(
					dataHoraConsulta,
					listaCodIntLinha.ToArray()
		).ToArray()
		.Dump("controleOperacionalAtualDTO");
		
	sRetornoSMS[] newListaRetornoSMS = new sRetornoSMS[0];
	if (controleOperacionalAtualDTO.Count() > 0)
	{		
		listaCodIntLinha.Clear();
		listaCodIntLinha.AddRange(controleOperacionalAtualDTO
								.GroupBy(g => g.Codintlinha)
								.Select(s => s.Key)
								.ToArray());								
		
	 	ItinerarioHorarioItensDTO[] listaItinerarioLocaisAtuais = RetornarItinerarioHorarioItensDTO()
			.Where(w=> controleOperacionalAtualDTO.Select(s=> s.CodLocalidade).Contains(w.CodLocalidade))
			.ToArray().Dump("listaItinerarioLocaisAtuais");		

		ItinerarioServicoDTO[] listaItinerarioServicoLocaisAtuais = RetornarItinerarioServicoDTO(listaItinerarioLocaisAtuais)
			//.Dump("listaItinerarioServicoLocaisAtuais")
			;
			
		var controleOperacional = Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarControleOperacionalPeloId(controleOperacionalAtualDTO
				.GroupBy(g => g.IdControleOperacional)
				.Select(s => s.Key)
				.ToArray())
			.Select(s => new
					{
						s.DataOcorrencia,
						CodIntLinha = s.CodIntLinha ?? 0,
						s.Sentido,
						CodLocalidade = s.CodLocalidade ?? 0,
						s.CodIntServDiaria,
						CodHorDiaria = s.CodHorDiaria ?? 0,
						CodIntTurno = s.CodIntTurno ?? 0
					})
					.Dump("controleOperacional")
					;
										
		List<sRetornoSMS> listaRetornoSMS =
						(from a in controleOperacional
						 join ItiInf in listaItinerarioLocalInformado on new { a.CodIntLinha, a.Sentido } equals new { ItiInf.CodIntLinha, ItiInf.Sentido }
						 join ItiAtu in listaItinerarioLocaisAtuais on new { a.CodIntLinha, a.CodLocalidade, a.Sentido } equals new { ItiAtu.CodIntLinha, ItiAtu.CodLocalidade, ItiAtu.Sentido }
						 where ItiInf.Sequencial > ItiAtu.Sequencial
						 join ItiServAtu in listaItinerarioServicoLocaisAtuais on new { ItiAtu.IdItinerario, ItiAtu.CodIntLinha, ItiAtu.Sequencial, ItiAtu.Sentido, a.CodIntServDiaria, a.CodHorDiaria, a.CodIntTurno } equals
																				  new { ItiServAtu.IdItinerario, ItiServAtu.CodIntLinha, ItiServAtu.Sequencial, ItiServAtu.Sentido, ItiServAtu.CodIntServDiaria, ItiServAtu.CodHorDiaria, ItiServAtu.CodIntTurno } into join_ItiServAtu
						 from ItiServAtu in join_ItiServAtu.DefaultIfEmpty()
						 join ItiServInf in listaItinerarioServicoLocalInformado on new { ItiInf.IdItinerario, ItiInf.CodIntLinha, ItiInf.Sequencial, ItiInf.Sentido, a.CodIntServDiaria, a.CodHorDiaria, a.CodIntTurno } equals
																					new { ItiServInf.IdItinerario, ItiServInf.CodIntLinha, ItiServInf.Sequencial, ItiServInf.Sentido, ItiServInf.CodIntServDiaria, ItiServInf.CodHorDiaria, ItiServInf.CodIntTurno } into join_ItiServInf
						 from ItiServInf in join_ItiServInf.DefaultIfEmpty()
						 select new
						 {
							 //ControleOperacional = a,
							 DataOcorrencia = a.DataOcorrencia,
							 Sentido = a.Sentido,
							 CodIntLinha = a.CodIntLinha,
							 // Verifica se existe servico para o itinerario informado ou o atual, se ñ existir 1 dos 2 pega o base
							 Tempo = (ItiServInf == null || ItiServAtu == null
										? ItiAtu.Tempo > ItiInf.Tempo
											? ItiAtu.Tempo.Subtract(ItiInf.Tempo.TimeOfDay)
											: ItiInf.Tempo.Subtract(ItiAtu.Tempo.TimeOfDay)
										: ItiServAtu.Tempo > ItiServInf.Tempo
											? ItiServAtu.Tempo.Subtract(ItiServInf.Tempo.TimeOfDay)
											: ItiServInf.Tempo.Subtract(ItiServAtu.Tempo.TimeOfDay)
									 ).TimeOfDay,								 									
						    Localidade_Atu = ItiAtu.CodLocalidade,
							Localidade_Info = ItiInf.CodLocalidade,
 							Tempo_Atu = ItiServAtu == null
										? ItiAtu.Tempo.TimeOfDay 
									    : ItiServAtu.Tempo.TimeOfDay,

 							Tempo_Info = ItiServInf == null
										? ItiInf.Tempo.TimeOfDay 
									    : ItiServInf.Tempo.TimeOfDay,
										
							Sev = ItiServInf == null || ItiServAtu == null 
										? "N"
										: "S"										
									 
						 }).Dump("sRetornoSMS-1")
						 .Select(s => new
						 {
							 s.DataOcorrencia,
							 s.Sentido,
							 s.Tempo,
							 s.CodIntLinha,
							 TempoPrevisto = Math.Round(s.DataOcorrencia.Add(s.Tempo).Subtract(dataHoraConsulta.TimeOfDay).TimeOfDay.TotalMinutes)
						 }).Dump("sRetornoSMS-2")
						 .Where(w => w.DataOcorrencia.Add(w.Tempo).TimeOfDay > dataHoraConsulta.TimeOfDay && w.TempoPrevisto > 0)
						 .Select(s => new sRetornoSMS()
						 {
							 TempoPrevisto = s.TempoPrevisto.ToString("00"),
							 Sentido = s.Sentido,
							 CodigoLinha = s.CodIntLinha.ToString()
						 })
						 .ToList()
						 .Dump("sRetornoSMS-3");
		List<int> listaCodIntLinhaDetec = new List<int>();
		List<int> listaCodIntLinhaProg = new List<int>();
		if (listaRetornoSMS.Count > 0)
		{
			// Cria lista com as linhas que foram encontradas na detecao
			listaCodIntLinhaDetec.AddRange(listaRetornoSMS
				.GroupBy(g => g.CodigoLinha)
				.Select(s => int.Parse(s.Key))
				.ToArray());

			// Cria lista com as linhas que ñ estão na detecao
			listaCodIntLinhaProg.AddRange(listaCodIntLinha
				.Where(w => !listaCodIntLinhaDetec.Contains(w))
				.ToArray());
		}
		
		// Adiciona na lista de retorno os dados da programacao
//		if (listaCodIntLinhaProg.Count > 0)
//			listaRetornoSMS.AddRange(cadastroBOEscala.RetornarEscalaProgramadaPorCodIntLinha(
//														dataHoraConsulta.Date,
//														dataHoraConsulta,
//														listaCodIntLinhaProg.ToArray(),
//														painelInformativoDTO.CodLocalidade)
//							.Select(s => new Globus5.DTO.GestaoDeFrotaOnLine.EstruturasGestaoDeFrotaOnLine.sRetornoSMS()
//							{
//								TempoPrevisto = s.HoraChegadaProg.Minute.ToString("00"),
//								Sentido = ((char)s.Sentido).ToString(),
//								CodigoLinha = s.CodIntLinha.ToString()
//							}).ToArray());

		// Atualiza lista com as linhas dos retornos encontradas
		listaCodIntLinha.Clear();
		listaCodIntLinha = listaRetornoSMS
							.GroupBy(g => g.CodigoLinha)
							.Select(s => int.Parse(s.Key))
							.ToList();
		
		if (listaRetornoSMS.Count > 0)
		{
			// Consulta linhas se ñ foi informada
			if (!informouLinha)
				listaLinhaDTO = Globus5.WPF.Comum.WebServices.GlobusWSApp.RetornarLinhaPeloCodigoInterno(listaCodIntLinha.ToArray()).ToArray();

						// Cria lista com origem das linhas
						List<int> listaCodlocalidade = listaLinhaDTO
							.GroupBy(g => g.OrigemLinha ?? 0)
							.Select(s => s.Key)
							.ToList();

						// Adiciona na lista os destinos das linhas
						listaCodlocalidade.AddRange(listaLinhaDTO
							.GroupBy(g => g.DestinoLinha ?? 0)
							.Select(s => s.Key)
							.ToArray());

						// Consulta origem\destino das linhas
						IList<LocaisDTO> listaLocais = Globus5.WPF.Comum.WebServices.EscalaWSApp.RetornarLocaisPorCodigos(listaCodlocalidade.ToArray());
						foreach (var item in listaRetornoSMS
								.OrderBy(o => o.TempoPrevisto))
						{
							LinhaDTO linhaDTO = listaLinhaDTO
								.Where(w => w.CodIntLinha.Equals(Convert.ToInt16(item.CodigoLinha)))
								.SingleOrDefault();
							sRetornoSMS retornoSMS = new sRetornoSMS();

							int index = Array.FindIndex(newListaRetornoSMS,
								delegate(sRetornoSMS sms)
								{
									return sms.CodigoLinha.Equals(linhaDTO.CodigoLinha) /*&& sms.Sentido.Equals(item.Sentido)*/;
								});

							int i = newListaRetornoSMS.Length;
							string tempoPrevisto = Convert.ToInt16(item.TempoPrevisto).ToString("0m");
							if (index == -1)
							{
								retornoSMS = item;
								retornoSMS.NomeAbrevLinha = linhaDTO.NomeAbreviado;
								retornoSMS.CodigoLinha = linhaDTO.CodigoLinha;
								retornoSMS.OrigemLinha = listaLocais.Where(w => w.CodLocalidade.Equals(linhaDTO.OrigemLinha ?? 0)).SingleOrDefault().DescLocalidade;
								retornoSMS.DestinoLinha = listaLocais.Where(w => w.CodLocalidade.Equals(linhaDTO.DestinoLinha ?? 0)).SingleOrDefault().DescLocalidade;
								retornoSMS.TempoPrevisto = tempoPrevisto;

								Array.Resize(ref newListaRetornoSMS, i + 1);
								newListaRetornoSMS[i] = retornoSMS;
							}
							else if (newListaRetornoSMS[index].TempoPrevisto.IndexOf(tempoPrevisto) == -1)
							{
								newListaRetornoSMS[index].TempoPrevisto += " " + tempoPrevisto;
							}
						}
					}

	}
	
	newListaRetornoSMS.ToList().Dump("newListaRetornoSMS");
}

private ItinerarioHorarioItensDTO[] RetornarItinerarioHorarioItensDTO()
{
	 return Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarItinerariosLinhasUsuario(
	 	dataHoraConsulta,
		listaCodIntLinha.ToArray());

}

private ItinerarioServicoDTO[] RetornarItinerarioServicoDTO(ItinerarioHorarioItensDTO[] itinerarioHorarioItensDTO)
{
	string[] itinerarioLinhas = itinerarioHorarioItensDTO
		.GroupBy(g => new
		{
			g.IdItinerario,
			g.CodIntLinha
		})
		.Select(s => s.Key.IdItinerario.ToString() + ";" + s.Key.CodIntLinha.ToString())
		.ToArray();

	return Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarItinerariosServicos(itinerarioLinhas)
		.Where(w=> itinerarioHorarioItensDTO
						.Select(s=> String.Concat(s.Sentido,s.Sequencial))
						.Contains(String.Concat(w.Sentido,w.Sequencial)))
		.ToArray();
}