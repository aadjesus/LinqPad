<Query Kind="Program" />

void Main()
{
	var population = Tuple.Create("Teste", 1,DateTime.Now, Tuple.Create("Teste", 1,DateTime.Now));
	
	population.Dump();	
	population.Item1.Dump();
	population.Item2.Dump();
	population.Item3.Dump();
	population.Item4.Dump();
	
}

// Define other methods and classes here
