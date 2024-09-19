<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
  </Connection>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WebReferences\WebReferences\Distribuicao\BgmRodotec.Globus5.WebReferences.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>FGlobus.Util</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{	
	WebServiceGenerico<Globus5.WPF.Comum.ws.estado.EstadosDTO>.ConsultaBasica().Dump();
	
	Globus5.WebReferences.WSCargas.EstadoWSApp.Url = "http://sp.bgmrodotec.com.br:8183/Alessandro.Augusto/estadows.asmx";	
	Globus5.WebReferences.WSCargas.EstadoWSApp.RetornarEstadosPorListaDeEstados(new string[] {"SP"}).Dump();
}