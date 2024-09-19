<Query Kind="Program" />

void Main()
{
	Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
	
	Enumerable.Range(0, 20000)
		.Select(n => n.ToString())
		.Aggregate((a, b) => a + ", " + b);
		
	stopwatch.Stop();
	
	stopwatch.Dump();
}