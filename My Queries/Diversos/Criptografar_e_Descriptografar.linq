<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
</Query>

void Main()
{
	string connection_string = "Provider=OraOLEDB.Oracle.1;Data Source=08000841068205330544077506160607;Persist Security Info=True;User ID=06800811080208430844088509160777058806090590063106320633;Password=COMPORTE120321;Unicode=True";

	connection_string
		.Split(';')
		.ToList()
		.ForEach(item=> 
		{
			if (item.StartsWith("Data Source=") ||
				item.StartsWith("User ID=") ||
				item.StartsWith("Password="))
			{			
				string valor = item.Split('=').LastOrDefault();
				try
				{
					valor = FGlobus.Util.CriptografiaBO.Descriptografar(valor);
				}
				catch (Exception)
				{
				}
				connection_string = connection_string.Replace(item,String.Concat(item.Split('=').FirstOrDefault(), "=", valor));			
			}
		});
	connection_string.Dump();

}

public enum eItensConnectionString
	{
		[System.ComponentModel.Description("Provider")]
		Provider,
		[System.ComponentModel.Description("Data Source")]
		Servidor,
		[System.ComponentModel.Description("Persist Security Info")]
		Persist_Security_Info,
		[System.ComponentModel.Description("User ID")]
		Usuario,
		[System.ComponentModel.Description("Password")]
		Senha,
		[System.ComponentModel.Description("Unicode")]
		Unicode
	}