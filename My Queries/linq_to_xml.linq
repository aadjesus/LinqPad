<Query Kind="Program" />

void Main()
{
	
	var x1 = XElement.Load(@"o:\Trabalho\xAlessandro Augusto\man_osprevisto.xml");
	x1.Elements()			
		.Select(s=> new 
		{		
			  CODINTOS            = s.Element("CODINTOS").Value,
			  SEQSERVOSPREV       = s.Element("SEQSERVOSPREV").Value,
			  CODIGOGRPSERVI      = s.Element("CODIGOGRPSERVI").Value,
			  CODIGOCADSERVI      = s.Element("CODIGOCADSERVI").Value,
			  CODIGOGRPDEFEITO    = s.Element("CODIGOGRPDEFEITO").Value,
			  CODIGODEFEITO       = s.Element("CODIGODEFEITO").Value,
			  CODIGOPLANREV       = s.Element("CODIGOPLANREV").Value,
			  CODIGOTPOPERSERVI   = s.Element("CODIGOTPOPERSERVI").Value,
			  TROCAOLEOPLANREV    = s.Element("TROCAOLEOPLANREV").Value,
			  TROCAOLEOCXCAMBIO   = s.Element("TROCAOLEOCXCAMBIO").Value,
			  TROCAOLEOCXDIF      = s.Element("TROCAOLEOCXDIF").Value		
		})
		.GroupBy(g=> g.CODINTOS)		
		.Where(w=> w.Count() > 3)
		.Select(s => s
						.GroupBy(g=> new 
						{
							g.CODIGOCADSERVI,
							g.CODIGOGRPSERVI,
							g.CODIGOPLANREV,
						//g.CODIGOTPOPERSERVI
						}))
		
		.Dump();
	
//	  CODIGOGRPSERVI
//    CODIGOCADSERVI
//    CODIGOPLANREV
//    CODIGOTPOPERSERVI

	
	
}

// Define other methods and classes here