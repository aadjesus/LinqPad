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
</Query>

void Main()
{
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");

	Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.Url.Dump();
	Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarInformacaoPainel(
		new Globus5.WPF.Comum.ws.gestaoDeFrotaOnline.PainelInformativoDTO() 
		{
			CodigoEmpresa = 8,
			CodigoFl = 9, 
			CodPainel = 16, 
			CodLocalidade = 9311
		}
	).Dump();			
	
	Globus5.WPF.Comum.WebServices.IntegracaoWSApp.Url.Dump();
	Globus5.WPF.Comum.WebServices.IntegracaoWSApp.RetornarInformacaoPainelIntegracao(
		new Globus5.WPF.Comum.ws.integracao.AutenticacaoWebService()
		{
		      ShortCode = 1010,
			  Token = "LTY2Nzg3MDg0NjY0MA=="
		}
		,8,9,16).Dump();
	
}