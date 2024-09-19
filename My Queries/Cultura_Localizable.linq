<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	//Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
	//DateTime.Now.Dump();	
	
	 //string defaultCulture = WebServices.SegurancaWSApp.RetornarIdiomaWebConfig();

	System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
	DateTime.Now.Dump();	

	
}

// Define other methods and classes here
