<Query Kind="Program" />

void Main()
{
	var dictionary = new Dictionary<string, DateTime>();
	dictionary.Add("BGM       ",new DateTime(1995,06,22)); 
	dictionary.Add("BGMRodotec",new DateTime(2004,01,02)); 
	dictionary.Add("Praxio    ",new DateTime(2018,07,01));
	dictionary.Add("Praxio2   ",new DateTime(2020,06,08));
	
	dictionary
		.OrderBy(o=> o.Value)
		.Select(s=> new 
		{
			Empresa = s.Key,
			Data    =  s.Value.ToString("dd/MM/yyyy") ,
			Tempo   = DateTime.Now.Year - s.Value.Year
		})
		.Dump();
}