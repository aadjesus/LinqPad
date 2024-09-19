<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Excecao.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Mensagens.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WebReferences\WebReferences\Distribuicao\BgmRodotec.Globus5.WebReferences.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <GACReference>DevExpress.Utils.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <Namespace>FGlobus.Componentes.WinForms</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	typeof(Teste_class)
		.GetProperties()
		.Dump("GetProperties - Teste_class");
		
	typeof(Teste_struct)
		.GetProperties()
		.Dump("GetProperties - Teste_struct");
		
		
	typeof(Teste_class)
		.GetFields()
		.Dump("GetFields - Teste_class");
		
	typeof(Teste_struct)
		.GetFields()
		.Dump("GetFields - Teste_struct");
		
		
}

class Teste_class
{
	public int Codigo {get;set;}
}

struct Teste_struct
{
	public int Codigo ;
}
