<Query Kind="Program" />

void Main()
{
	XDocument srcTree = new XDocument(
    	new XElement("Node1",
        	new XElement("Propriedade1", "Valor1"),
        	new XElement("Propriedade2", "Valor2"),
        	new XElement("Propriedade3", "Valor3"),
        	new XElement("Propriedade4", "Valor4")
    	));	

	XDocument doc = XDocument.Parse(srcTree.ToString().Dump("z1"));
	doc.Dump("z2");
}


