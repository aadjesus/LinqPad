<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
//	//var acesso = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
//	var acesso = "";//DateTime.Now.ToString("M/dd/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
//	acesso = DateTime.Now.ToString("yyyy-MM-dd-HH.mm.ss.ffffff").Dump();
//	DateTime.ParseExact(acesso,"yyyy-MM-dd-HH.mm.ss.ffffff", CultureInfo.InvariantCulture).Dump();
//	
//    var acessoCripto = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(acesso)).Dump().Replace("MD","OA");
//	acessoCripto.Dump();
//	
//		
//	//string.Concat(acesso.ToCharArray().Select(s=> s)).Dump();
//	
//	//"http://sp.praxio.com.br:8184/alessandro.augusto//Api99Kote/DownloadNf?id99Kote=1&acesso=MTgvOAMvMjAyMiAxNDoyODoxMw"
//	

	var acessoCripto = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(
                        DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd-HH.mm.ss.ffffff")))
                    .Insert(10, "pRxFs").Dump();

	acessoCripto = "MjAyMi0wMypRxFs0yMi0xOC41MC40MC4zODU1ODY=";
	var acessoDescripto = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(acessoCripto.Replace("pRxFs","")));
	acessoDescripto.Dump();
	
	//var acesso2 = DateTime.Now;
	//var qtde = 1000000;
	//var qtde1 = 0;
	//var qtde2 = 0;
	//var qtde3 = 0;
	//var x4 = "";
	//var x2 = "";
	//foreach (var element in Enumerable.Range(1,qtde))
	//{
	//	acesso2 = acesso2.AddMinutes(1);
	//	try
	//	{	        
	//		 x4 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(acesso2.ToString("yyyy-MM-dd-HH.mm.ss.ffffff")));
	//		//if (element < 100)
	//		//	x4.Dump();				
	//		if (x4.IndexOf("Pf")>0)
	//			++qtde1;			
	//		
	//		if (x4.IndexOf("=")>0)
	//			++qtde2;			
	//
	//		x4 = x4.Insert(10,"pRxFs").Dump();
	//		//x4 = x4.Replace("pRxFs","").Dump();
	//		
	//		x2 = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(x4));
	//		var x3 = DateTime.ParseExact(x2,"yyyy-MM-dd-HH.mm.ss.ffffff", CultureInfo.InvariantCulture);
	//		
	//		DateTime data = DateTime.MinValue;
	//		DateTime.TryParseExact(x2, "yyyy-MM-dd-HH.mm.ss.ffffff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out data);
	//
	//		break;
	//	}
	//	catch (Exception ex)
	//	{
	//		//x4.Dump("1");
	//		x2.Dump("ERRO");
	//		
	//	    break;
	//		//ex.Dump();
	//	}
	//}
	//x4.Dump();	
	//x2.Dump();	
	//qtde1.Dump();
	//qtde2.Dump();
	//
}