<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

void Main()
{
	var arquivo = @"c:\Temp\sss3.txt";	

	using (var streamReader = new StreamReader(arquivo))
	{
		string texto = streamReader.ReadToEnd();
		var x1 = JObject.Parse(texto);
		x1["Data"].Count().Dump();
		//x1["Data"]
		//	.Select(s=> s.Value<string>("Campo01")).Dump();
			
		//var x1 = JArray.Parse(texto);
		//x1.Values().Dump();
		
		//List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
	}	
}

// Define other methods and classes here
