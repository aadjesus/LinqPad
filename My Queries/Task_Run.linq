<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	
	"INICIO".Dump();
	Task.Run(()=> 
	{
		"INICIO-Task".Dump();
		foreach (var element in Enumerable.Range(1,10))
		{
			element.Dump();
			Thread.Sleep(TimeSpan.FromSeconds(1));				
		}
		
		"FIM-Task".Dump();		
	}); 	 
	"FIM".Dump();
	
	Teste(); 
	await Task.CompletedTask.Dump();
}

public async Task Teste() 
{ 
	"INICIO-Metodo".Dump();
	foreach (var element in Enumerable.Range(1,10))
	{
		element.Dump();
		Thread.Sleep(TimeSpan.FromSeconds(1));				
	}		
	"FIM-Metodo".Dump();
}

