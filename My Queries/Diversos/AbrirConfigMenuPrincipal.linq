<Query Kind="Program">
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Excecao.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\DevExpress 2011.2\Components\Bin\Framework\DevExpress.Utils.v11.2.dll</Reference>
  <Namespace>FGlobus.Componentes.WinForms</Namespace>
</Query>

void Main()
{
	Assembly assembly = Assembly.LoadFrom(@"c:\GlobusMais\WPF\Distribuicao\Cargas.exe");
    XDocument _xmlDataDoc = Globus5.WPF.Comum.Util.AbrirConfigMenuPrincipal(assembly);
	
//	var sss = xDocument
//		.Descendants("ItemMenu")
//		.Where(w=> w.Element("AssemblyName").Value == "BgmRodotec.Globus5.Cadastros.Cargas" &&
//			   	   w.Element("NomeClass").Value == "Estados");
//	//sss.Dump();
//	ItemMenu aa = new ItemMenu(sss.Elements(),false);
//	aa.Dump();
	
	var xxx = _xmlDataDoc.Descendants("Nivel1")	
                .Aggregate(new List<ItemMenu>(), (nivel1, itemNivel1) => // Cria lista com os itens de menu do arquivo 
                {
					//itemNivel1.Elements().Count().Dump();
                    nivel1.Add(new ItemMenu(itemNivel1.Elements(),false));
                    nivel1.AddRange(itemNivel1.Descendants()
                        .Aggregate(new List<ItemMenu>(), (nivel2, itemNivel2) =>
                        {
                            nivel2.Add(new ItemMenu(itemNivel2.Elements(),false));
                            return nivel2;
                        }));
                    return nivel1;
                })
				.Where(w => w.NomeItemMenu != null)
				.Select(s=> new 
				{
					s.Caption,s.Niveis,s.Nivel1,s.NomeItemMenu,
					s.AssemblyName,s.NomeClass					
				});
	xxx.Dump();				
	
	
	

}

// Define other methods and classes here
