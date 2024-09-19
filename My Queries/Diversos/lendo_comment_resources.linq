<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Mensagens.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
</Query>

void Main()
{

	var executingAssembly = Assembly.LoadFile(@"c:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Mensagens.dll");
	
	using (var stream = executingAssembly.GetManifestResourceStream("FGlobus.Mensagens.Informacoes.resources"))
	{
		System.Resources.ResXResourceReader rr12 = new System.Resources.ResXResourceReader( @"c:\GlobusMais\Frameworks\FGlobus\Mensagens\Informacoes.resx");		
		
		
		rr12.UseResXDataNodes = true;
      	IDictionaryEnumerator dict = rr12.GetEnumerator();
      	while (dict.MoveNext()) 
	  	{	
			System.Resources.ResXDataNode resXDataNode = dict.Value as System.Resources.ResXDataNode;
			if (resXDataNode != null && !String.IsNullOrEmpty(resXDataNode.Comment))
			{
				//resXDataNode.Comment.Dump();
				//dict.Key.Dump();
				//dict.Dump();
				//dict.Value.Dump();	
				resXDataNode.Dump();
				return;
			}		
      	}
		
		
		
	}
}


