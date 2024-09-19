<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Excecao.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Mensagens.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WebReferences\WebReferences\Distribuicao\BgmRodotec.Globus5.WebReferences.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <GACReference>DevExpress.Utils.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <Namespace>FGlobus.Componentes.WinForms</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <Namespace>FGlobus.Util.ExtensaoObject</Namespace>
  <Namespace>Globus5.WebReferences</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.ged</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	foreach (var element in WSGED.GEDWSApp.RetornarDocumentosPorID(1).Where(w=> w.IDGEDDocumento == 2 ).Dump())
	{
		element.SerializarObjetoParaString(true).Dump();
		//System.Windows.Forms.Clipboard.SetText(
		("[" + string.Join(",", element.Documento)).Dump()
		//)
		;
		
		//var str = System.Text.Encoding.Default.GetString(element.Documento);
		//System.Windows.Forms.Clipboard.SetText(str);
		
		
		//str.Dump();
		//str.Length.Dump();
	}
}

// Define other methods and classes here