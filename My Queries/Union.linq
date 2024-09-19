<Query Kind="Program" />

void Main()
{
	var lista = new List<Foo>
	{
		{ new Foo{ Cod1 = 1, Cod2 = 1} },
		{ new Foo{ Cod1 = 1, Cod2 = 4} },
		{ new Foo{ Cod1 = 1, Cod2 = 5} },
	};
	
	//Teste.Test1();
	lista.Union(p=> p.Cod1, p=> p.Cod2).Dump();
}

class Foo
{
	public int Cod1;
	public int Cod2;
}

public static class  Teste
{
	public static IEnumerable<TKey> Union<TSource,TKey>(
		this IEnumerable<TSource> source, 
		Func<TSource,TKey> propriedade1,
		Func<TSource,TKey> propriedade2)
	{
		Func<Func<TSource,TKey>, IEnumerable<TKey>> funcPropriedade =
			propriedade => source
					.Select(s=> propriedade(s));
		
		var retorno = funcPropriedade(propriedade1)
			.Union(funcPropriedade(propriedade2));
		
		return retorno;
	}
}