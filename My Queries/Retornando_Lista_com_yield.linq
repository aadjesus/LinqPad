<Query Kind="Program" />

void Main()
{
	var x1 = new Metodos();
	
	var lista = new List<Tuple<Stopwatch,Stopwatch>>();
	for (int i = 0; i < 10; i++)
		lista.Add(
			Tuple.Create(
				x1.Executar(m => m.Retorno_yield()),
				x1.Executar(m => m.Retorno())));
				
	var lista2 = lista
		.Select(s=> new Analize(s))
		.Dump();	
	
	lista2.Qtde(a=> a.Retorno_yield,"return yield");
	lista2.Qtde(a=> a.Retorno,"return List");
	
}
class Analize
{
	Func<Stopwatch,Stopwatch,string> funcTempo = 
		(t1,t2) => string.Concat((t1.Elapsed > t2.Elapsed ? "*":""),t1.Elapsed);
		
	public Analize(Tuple<Stopwatch,Stopwatch> tuple)
	{
		Retorno_yield = funcTempo(tuple.Item1,tuple.Item2);
		Retorno = funcTempo(tuple.Item2,tuple.Item1);
		Tempo = new TimeSpan(Math.Abs((tuple.Item1.Elapsed - tuple.Item2.Elapsed).Ticks));
	}
	
	public string Retorno_yield {get;set;}
	public string Retorno {get;set;}
	public TimeSpan Tempo {get;set;}
}
public class Metodos
{
	public IEnumerable Retorno_yield()
	{
		for (int i = 0; i < 100; i++)
			yield return i;
	}
	
	public IEnumerable Retorno()
	{
		var retorno = new List<int>();
		for (int i = 0; i < 100; i++)			
			retorno.Add(i);
			 
		return retorno;
	}
}

public static class Util
{
	public static Stopwatch Executar(this Metodos objeto, Func<Metodos,IEnumerable> metodo)
	{
		var tempo = new Stopwatch();
		tempo.Start();
		
		metodo(objeto);		
		
		tempo.Stop();
		return tempo;
	}	
	
	public static void Qtde<Analize ,TKey>(this IEnumerable<Analize> lista, Func<Analize, TKey> propriedade, string texto )
	{	
		lista.Count(c=> propriedade(c).ToString().Contains("*") ).Dump(texto);		
	}
}


