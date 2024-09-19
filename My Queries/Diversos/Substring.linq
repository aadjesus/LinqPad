<Query Kind="Program" />

void Main()
{
	string[] lista = new string[] 
	{
		"1234567890",
		"123456789012345",
		"12345",
	};
	
	string texto = "1234567890";
	texto.Substring(0, Math.Min(15,texto.Length).Dump() ).Dump();
	
	lista
		.Select(s=> s.Substring(0, Math.Min(10,s.Length)))
		.Dump();
	
}