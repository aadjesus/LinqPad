<Query Kind="Program" />

void Main()
{	
	foreach (var item in listaGuid)
	{
		string.Concat("'", DotNetToOracle(item),"',").Dump();
	}
	
}

static string DotNetToOracle(string textoGuid)
{
	var guid = new Guid(textoGuid);
	var retorno = BitConverter.ToString(guid.ToByteArray());
	
	return retorno;
}

string[] listaGuid = {"DE329B5CDB9F1C42E05381EE640A76EA",
					  "DE329B5CDBA21C42E05381EE640A76EA",};