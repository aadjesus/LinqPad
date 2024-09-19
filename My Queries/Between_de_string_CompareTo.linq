<Query Kind="Program" />

void Main()
{
	var dataIni = "2021-01-05";
	var dataFin = "2021-01-07";
	
	var lista = new [] {
		"2021-01-01",
		"2021-01-04",
		"2021-01-05",
		"2021-01-07",
		"2021-01-09",
	};
	
	lista
		.Where(w=> 
		{
			w.Dump();	
			var x3 = w.CompareTo(dataIni).Dump();
			var x4 = w.CompareTo(dataFin).Dump();
		
			return x3 >= 0 && 
			       x4 <= 0;
		})
		.Dump();
	
	
	dataIni.CompareTo("2021-01-04").Dump();
	dataIni.CompareTo("2021-01-05").Dump();
	dataIni.CompareTo("2021-01-07").Dump();
}

// Define other methods and classes here
