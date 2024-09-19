<Query Kind="Program" />

void Main()
{
	var lista =  Enumerable.Range(1,1000000).Select(s=> new Foo{ Cod1 = s,  Qtde = s+10});	
	
	var stopwatch = new Stopwatch();
	stopwatch.Start();
	var qtde = 0;
    foreach (var element in lista)
	{
		qtde += element.Qtde;
	}	
	stopwatch.Stop();
	stopwatch.Dump("foreach 1");	
	qtde.Dump();

//
//var stopwatch = new Stopwatch();
//	stopwatch.Start();
//	var qtde = 0;	
//	lista.ToList().ForEach(element =>
//	{
//		qtde += element.Qtde;
//	});	
//	stopwatch.Stop();
//	stopwatch.Dump("foreach 2");
//	qtde.Dump();
}

class Foo
{
	public int Cod1;
	public int Qtde;
}