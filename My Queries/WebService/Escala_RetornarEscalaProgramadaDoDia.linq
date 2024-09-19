<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
  <Namespace>FGlobus.Componentes.WinForms.ws.controle</Namespace>
  <Namespace>Globus5.WPF.Comum</Namespace>
  <Namespace>System.Web.Services.Protocols</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.escala</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.frota</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");	

	sEscalaControleOperacional[] listaEscalaControleOperacional = Globus5.WPF.Comum.WebServices.EscalaWSApp.RetornarEscalaProgramadaDoDia(
										new DateTime(2011, 1, 1, 7, 9, 0),
										new int[] { 2201 },
										new int[] { 2201 });
	
	AcessorioDoVeiculoDTO[] listaAcessorioDoVeiculo = Globus5.WPF.Comum.WebServices.FrotaWSApp.GenericoConsultaBasica<AcessorioDoVeiculoDTO>(new Globus5.WPF.Comum.ws.frota.sCondicaoAdicionalCriteria()
	{
		Operador = Globus5.WPF.Comum.ws.frota.eOperador.Contido,
		Propriedade = "CodigoVeic",
		Valor = listaEscalaControleOperacional
					.GroupBy(g => g.CodIntVeiculo)
					.Select(s => s.Key)
					.ToArray()
	});


	AcessorioDTO[] listaAcessorio = Globus5.WPF.Comum.WebServices.FrotaWSApp.GenericoConsultaBasica<AcessorioDTO>(new Globus5.WPF.Comum.ws.frota.sCondicaoAdicionalCriteria()
	{
		Operador = Globus5.WPF.Comum.ws.frota.eOperador.Contido,
		Propriedade = "CodAcessorio",
		Valor = listaAcessorioDoVeiculo
					.GroupBy(g => g.CodAcessorio)
					.Select(s => s.Key)
					.ToArray()
	});	
	
	 Func<IEnumerable<AcessorioDoVeiculoDTO>, int, IEnumerable<AcessorioDTO>> delegateAcessoriosDoVeiculo =
	 		delegate(IEnumerable<AcessorioDoVeiculoDTO> lista, int codigoVeic)
			{
				if (codigoVeic.Equals(0))
					return new List<AcessorioDTO>() ;
				else
					return lista
						.Where(w => w.CodigoVeic.Equals(codigoVeic))
						.Join(listaAcessorio,
								a1 => a1.CodAcessorio,
								b1 => b1.CodAcessorio,
								(a1, b1) => b1);
			};
									 
	Func<IEnumerable<sEscalaControleOperacional>, eSentido, string> PrimeiroOuUltimoPontoSentido =
			delegate(IEnumerable<sEscalaControleOperacional> lista, eSentido sentido)
			{
				return lista
					.Where(w=> w.Sentido == sentido)
					.OrderBy(o=> o.HoraChegadaProg)
					.Aggregate(String.Empty, 
					(a, b) =>
					{
						string acessorio = delegateAcessoriosDoVeiculo(listaAcessorioDoVeiculo, b.CodIntVeiculo)
							.Aggregate(String.Empty, (a1, b1) => String.Concat(a1, (String.IsNullOrEmpty(a1) ? "" : "x"), b1.DescricaoAcessorio));
						
						return String.Concat(
											a,
											"<div title='asdasdasdas'> ",
											" - ", b.CodIntVeiculo.ToString("0000000"),
											" - ", b.CodigoServico,
											" - ", b.HoraChegadaProg.ToString("HH:mm"),
											" - ", acessorio,
											" </div>\n");
				
					});
			};
	
	PrimeiroOuUltimoPontoSentido(listaEscalaControleOperacional, eSentido.Ida).Dump();	
}

// Define other methods and classes here