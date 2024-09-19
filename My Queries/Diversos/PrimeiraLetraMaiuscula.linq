<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	"aLESSANDRO AugUsto de JESUS".ConverterPrimeiraLetraParaMaiuscula().Dump();	
	"aLESSANDRO AugUsto de JESUS".ConverterPrimeiraLetraParaMaiuscula(false).Dump();		
	String a=null;
	a.ConverterPrimeiraLetraParaMaiuscula().Dump();
}


public static class ExtensaoDeMetodos
{
		public static string ConverterPrimeiraLetraParaMaiuscula(this string valor, bool todas = true)
		{
			if (string.IsNullOrEmpty(valor))
				return valor;

			return valor.ToLower()
				.Split(new string[] { todas ? " " : "" }, StringSplitOptions.None)
				.Aggregate(string.Empty, (a, b) => a + (String.IsNullOrEmpty(a) ? "" : " ") +
												 b.Aggregate(string.Empty, (a1, b1) => a1 + (String.IsNullOrEmpty(a1) ? Char.ToUpper(b1) : b1)));
		}
	
	
}