<Query Kind="Program">
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Excecao.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>Globus5.WPF.Comum</Namespace>
  <Namespace>System.Web.Services.Protocols</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.gestaoDeFrotaOnline</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");

	//WebServices.CarregarConfigWebServices(@"c:\Users\alessandro.augusto\Documents\Windows\Outros\LinqPad\Pira_BgmRodotec.Globus5_81.Config");		
//	Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.Url = "http://wsglobus.piracicabana.com.br:81//GestaoDeFrotaOnlineWS.asmx";
//	Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.Url.Dump();
//	Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.GenericoRetornarTodos<ParametrosDTO >().Dump("2");


//--1679

//	ControleOperacionalAtualDTO[] controleOperacionalAtualDTO = Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarUltimaDeteccaoDoVeiculoLinha(		
//		Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarDataHoraBanco(),
//		new int[] {26601 ,26604 ,26605 ,26606 ,26607 ,26608 ,26609 ,26612 ,26613 ,26614 ,26615});
//	ControleOperacionalDTO[] controleOperacionalDTO = Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarControleOperacionalPeloId(controleOperacionalAtualDTO.Select(s=> s.IdControleOperacional).ToArray()) ;		

//	Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.GenericoConsultaBasica<ControleOperacionalDTO>(
//		new sCondicaoAdicionalCriteria[]
//		{
//			new sCondicaoAdicionalCriteria(){ Operador = eOperador.MaiorOuIgual, Propriedade="DataOcorrencia", Valor=controleOperacionalDTO.Min(m => m.DataOcorrencia)},
//			new sCondicaoAdicionalCriteria(){ Operador = eOperador.MenorOuIgual, Propriedade="DataOcorrencia", Valor=Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarDataHoraBanco().AddHours(1)},
//			new sCondicaoAdicionalCriteria(){ Operador = eOperador.Contido, Propriedade="CodigoVeic", Valor=controleOperacionalDTO.GroupBy(g=> g.CodigoVeic ?? 0).Select(s=> s.Key).ToArray()}
//		})
//
//	var listaDados = 
//		Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.GenericoConsultaBasica<ControleOperacionalDTO>(
//			new sCondicaoAdicionalCriteria[]
//			{
//				new sCondicaoAdicionalCriteria(){ Operador = eOperador.MaiorOuIgual, Propriedade="DataOcorrencia", Valor=new DateTime(2011,12,29,10,01,0)},
//				new sCondicaoAdicionalCriteria(){ Operador = eOperador.MenorOuIgual, Propriedade="DataOcorrencia", Valor=new DateTime(2011,12,29,9,59,0)},
//				new sCondicaoAdicionalCriteria(){ Operador = eOperador.Contido, Propriedade="CodigoVeic", Valor=new int[] {1679}}
//			})		
//			.Select(s=> new 
//			{
//				s.DataOcorrencia,
//				CodigoVeic = s.CodigoVeic ?? 0,
//				Latitude = Convert.ToDouble(s.Latitude.Replace('.',',')),
//				Longitude = Convert.ToDouble(s.Longitude.Replace('.',','))
//			})
//			.Where(w=> w.Latitude != 0 &&  w.Longitude != 0)
//			.OrderBy(o => o.DataOcorrencia);
//		
//	listaDados
//		.GroupBy(g => g.CodigoVeic, (chave, listaGrupo) => new
//		{
//			CodigoVeic = chave,
//			Distancia = listaGrupo
//				.Select((s, indexItem) => new
//				{
//					s.DataOcorrencia,
//					Origem_Latitude = s.Latitude,
//					Origem_Longitude = s.Longitude,
//					Destino = listaGrupo
//						.Where((w, indexFiltro) => indexFiltro.Equals(indexItem+1)).FirstOrDefault()
//				})
//				.Where(w=> w.Destino != null)
//				.Select(s => new 
//				{
//					Origem_Data = s.DataOcorrencia.ToString("HH:mm:ss") ,
//					s.Origem_Latitude,
//					s.Origem_Longitude,
//					Destino_DataOcorrencia = s.Destino.DataOcorrencia.ToString("HH:mm:ss"),
//					Destino_Latitude= s.Destino.Latitude,
//					Destino_Longitude= s.Destino.Longitude,
//					Km = FGlobus.Util.Util.RetornarDistanciaEntreAsCoordenadas(
//						s.Origem_Latitude, 
//						s.Origem_Longitude, 
//						s.Destino.Latitude, 
//						s.Destino.Longitude)
//				}).Dump()
//				.Sum(s=> s.Km)
//		})	
//		.Dump("1");

	
}