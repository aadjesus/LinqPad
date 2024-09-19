<Query Kind="Program">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	var contWhile = 0;
	var contDo = 0;
	
	var listaFoo = new List<ClasseTeste>();	
	listaFoo.AddRange(Enumerable.Range(0,100000)
		.Select(s=> new ClasseTeste() 
		{
			Codigo = s, 
			Valor = s.GetHashCode() * s
		})
		.ToArray());

	Dictionary<string,TimeSpan> dictionary = new Dictionary<string,TimeSpan>();
	Stopwatch stopwatch = new Stopwatch();
	
	Action<string,Action> acaoRotina = 
		(nome,acao)=>
		{
			stopwatch.Restart();	
			acao();
			stopwatch.Stop();
			dictionary.Add(nome,stopwatch.Elapsed);
		};
	
	acaoRotina("for",
		() =>
		{	
			decimal total = 0;
			for (int i = 0; i < listaFoo.Count; i++)
				total += listaFoo[i].Valor;
		});
	
	acaoRotina("while",
		() =>
		{
			decimal total = 0;
			while (contWhile < listaFoo.Count)				
				total += listaFoo[contWhile++].Valor;
		});
		
	acaoRotina("foreach",
		() =>
		{
			decimal total = 0;			
			foreach (var element in listaFoo)
				total += element.Valor;				
		});	
	
	acaoRotina("do",
		() =>
		{			
			decimal total = 0;			
			do
	    		total += listaFoo[contDo++].Valor;
			while (contDo < listaFoo.Count);
		});
	
	acaoRotina("ForEachLinq",
		() =>
		{			
			decimal total = 0;
			listaFoo.ForEach(f=> total += f.Valor);
		});		
	
	acaoRotina("ForEachAsParallelLinq",
		() =>
		{			
			decimal total = 0;
			listaFoo.AsParallel().Aggregate(total, (a,b) => a += b.Valor);
		});			
		
	var listaDictionary = dictionary
		.OrderBy(o=> o.Value)
		.Dump();	
		
	//listaDictionary.Last().Value.Dump("Maior").Subtract(listaDictionary.First().Value.Dump("Menor")).Dump();	
}

public class ClasseTeste
{
	public int Codigo;
	public decimal Valor;
}