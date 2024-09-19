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
  <Namespace>System.Web.Services.Protocols</Namespace>
  <Namespace>Globus5.WPF.Comum</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.cargas</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{	
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");	
	
	var genericoConsultaPorChave = WebServices.CargasWSApp.GenericoRetornarTodos<RotaItinerarioCgsDTO>();	
	genericoConsultaPorChave.Dump("GenericoRetornarTodos");	

	var genericoConsutaBasicaPorCondicoes = WebServices.CargasWSApp.GenericoConsutaBasicaPorCondicoes<RotaItinerarioCgsDTO>(
		new sCondicaoAdicionalCriteria[] 
		{
			new sCondicaoAdicionalCriteria()
			{	
				Propriedade = "Sequencia", 
				Operador = eOperador.Contido, 
				Valor = new int[] {1,2,3}
			}
			,
			new sCondicaoAdicionalCriteria()
			{	
				Propriedade = "CodRota", 
				Operador = eOperador.Contido, 
				Valor = new int[] {11,12}
			}
		}	
	);	
	genericoConsutaBasicaPorCondicoes.Dump("genericoConsutaBasicaPorCondicoes");
	
	
}