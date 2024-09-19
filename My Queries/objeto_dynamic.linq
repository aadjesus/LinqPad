<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Excecao.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Mensagens.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WebReferences\WebReferences\Distribuicao\BgmRodotec.Globus5.WebReferences.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <GACReference>DevExpress.Utils.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <Namespace>FGlobus.Componentes.WinForms</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <Namespace>FGlobus.Util.ExtensaoBoolean</Namespace>
  <Namespace>FGlobus.Util.ExtensaoDateTime</Namespace>
  <Namespace>FGlobus.Util.ExtensaoDTO</Namespace>
  <Namespace>FGlobus.Util.ExtensaoEnum</Namespace>
  <Namespace>FGlobus.Util.ExtensaoException</Namespace>
  <Namespace>FGlobus.Util.ExtensaoImagens</Namespace>
  <Namespace>FGlobus.Util.ExtensaoLinq</Namespace>
  <Namespace>FGlobus.Util.ExtensaoObject</Namespace>
  <Namespace>FGlobus.Util.ExtensaoString</Namespace>
  <Namespace>FGlobus.Util.ExtensaoValoresFlutuante</Namespace>
  <Namespace>FGlobus.Util.ExtensaoWeb</Namespace>
  <Namespace>System.Dynamic</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	dynamic objetoDinamico = new ExpandoObject(); 
	objetoDinamico.Nome = "Teste"; 
	objetoDinamico.Valor = 10;
	objetoDinamico.Data = DateTime.Now;
	objetoDinamico.OK = true;
	
	Console.WriteLine(objetoDinamico);
	
	
	dynamic expand = new ExpandoObject();

	expand.Propriedade = "Valor da propriedade";
	expand.Metodo = (Func<string, string>) ((string name) => 
	{ 
    	return "Teste: " + name; 
	});

	Console.WriteLine(expand.Propriedade);
	Console.WriteLine(expand.Metodo("Parametro metodo"));
}

// Define other methods and classes here