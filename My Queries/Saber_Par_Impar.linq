<Query Kind="Program" />

void Main()
{
	var lista = Enumerable.Range(0,10)
		.GroupBy(g=> (g % 2 == 0 ? "Par" : "Impar"));
		
	lista
		.Select(s=> new {s.Key, Qtde = s.Count()})
		.Dump();
	
	lista
		.Aggregate("",(a,b)=>  a + b.Key +"-"+ b.Count() + Environment.NewLine) 		
		.Dump();
	
}