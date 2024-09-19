<Query Kind="Program">
  <NuGetReference>NServiceBus.Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var teste = new Teste();
	string json = @"{
	  'Valor1': 'ssssssss',
	  'Valor2': false,
	  'Valor3': 10,
	  'Valor4': '2017-12-28T09:24:38.8554991-02:00',	  
	  'Lista1': ['valor1','valor2'],	  
	  'Lista2': [{'Valor1':'aaaa1','Valor2':false,'Valor3':15}, {'Valor1':'aaaa2','Valor2':true,'Valor3':20}]
	}";
	
	JsonConvert.SerializeObject(DateTime.Now).Dump();
	JsonConvert.PopulateObject(json, teste);
	teste.Dump();
}

public class Teste
{
    public string Valor1 { get; set; }
	public bool Valor2 { get; set; }
	public int Valor3 { get; set; }    
	public DateTime Valor4 { get; set; }    
    public string[] Lista1 { get; set; }
	public Teste[] Lista2 { get; set; }
}
