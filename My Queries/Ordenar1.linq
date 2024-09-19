<Query Kind="Program" />

void Main()
{	
	var lista = new List<MyClass>();
    lista.Add(new MyClass() { Cod1 = 10, Cod2 = "B",Valor = 1 });
    lista.Add(new MyClass() { Cod1 = 03, Cod2 = "A",Valor = 2 });
    lista.Add(new MyClass() { Cod1 = 21, Cod2 = "C",Valor = 3 });
    lista.Add(new MyClass() { Cod1 = 02, Cod2 = "B",Valor = 1 });
    lista.Add(new MyClass() { Cod1 = 33, Cod2 = "A",Valor = 2 });
    lista.Add(new MyClass() { Cod1 = 04, Cod2 = "0",Valor = 3 });
    lista.Add(new MyClass() { Cod1 = 05, Cod2 = "K",Valor = 1 });
    lista.Add(new MyClass() { Cod1 = 08, Cod2 = "A",Valor = 2 });
    lista.Add(new MyClass() { Cod1 = 01, Cod2 = "1",Valor = 3 });
	
//	lista.AddRange(Enumerable.Range(0,100000)
//		.Select(s=> new MyClass()
//		{ 
//			Cod1 = s, 
//			Cod2 = s.GetHashCode().ToString(), 
//			Valor = s.GetHashCode()
//		}));
	
	//Expression<Func<MyClass, object>> propriedade = a => new {a.Cod1, a.Cod2};	
	//lista.OrderBy(a => new {a.Cod2, a.Cod1}).Dump();
	lista
		.OrderBy(a => a.Cod2)
		.ThenBy(a => a.Cod1)
		.ThenBy(a => a.Valor)
		.Dump();
	
	lista.MyOrderBy(a => new {a.Cod2, a.Cod1, a.Valor}).Dump();
	
	//lista.MyOrderByDescending(propriedade).Dump();
	
	
//	Stopwatch stopwatch = new Stopwatch();
//    stopwatch.Start();	
//	var x1 = lista.Ordenar1( propriedade);	
//	stopwatch.Stop();	
//	stopwatch.Dump("Ordenar novo");
//	
//	stopwatch.Start();	
//	var x2 = lista.Ordenar(propriedade);
//	stopwatch.Stop();	
//	stopwatch.Dump("Ordenar velho");
	
	//lista.Dump();
	//x1.Dump();
	//x2.Dump();
}

class MyClass 
{
    public int Cod1 { get; set; }
	public string Cod2 { get; set; }
    public decimal Valor { get; set; }
	
	public override int GetHashCode()
    {
        int hash = 57;
        hash = 27 * hash * Valor.GetHashCode();
        return hash;
    }		
}


public static class MyExtensions1x
{
	private static IEnumerable<TSource> ExecutarOrdem<TSource>(
		this IEnumerable<TSource> source,
        bool decrescente)
    {
		Expression<Func<TSource, int>> expressionGetHashCode = 
			objeto => objeto.GetHashCode();

		return source.ExecutarOrdem(expressionGetHashCode,decrescente);
	}
	
	public static IEnumerable<TSource> MyOrderByDescending<TSource>(
		this IEnumerable<TSource> source)
    {
		return source.ExecutarOrdem(true);
	}
	
	public static IEnumerable<TSource> MyOrderBy<TSource>(
		this IEnumerable<TSource> source)
    {
		return source.ExecutarOrdem(false);
	}
	
	public static IEnumerable<TSource> MyOrderBy<TSource,TKey>(
		this IEnumerable<TSource> source,
        Expression<Func<TSource, TKey>> propriedade)
	{
		return source.ExecutarOrdem(propriedade, false);
	}
	
	public static IEnumerable<TSource> MyOrderByDescending<TSource, TKey>(
		this IEnumerable<TSource> source,
        Expression<Func<TSource, TKey>> propriedade)
	{
		return source.ExecutarOrdem(propriedade, true);
	}

	private static IEnumerable<TSource> ExecutarOrdem<TSource, TKey>(
		this IEnumerable<TSource> source,
        Expression<Func<TSource, TKey>> propriedade,
        bool decrescente = false)
    {
		//if (source.NuloOuVazio())
		//	return source;
			
        NewExpression newExpression = propriedade.Body as NewExpression;
        if (newExpression == null)
        {
            if (decrescente)
                return source
                    .OrderByDescending(propriedade.Compile());
            else
                return source
                    .OrderBy(propriedade.Compile());
        }
        else
        {
            var param = Expression.Parameter(typeof(TSource));
			var retorno = source;

            foreach (var element in newExpression.Members.Reverse())
            {
                var expressionLambda = Expression.Lambda<Func<TSource, object>>(
                    Expression.Convert(
                        Expression.Property(
                            param,
                            element.Name),
                    typeof(object)),
                    param);
					
                retorno = source.ExecutarOrdem(expressionLambda, decrescente);
            }
			
			return retorno;
        }        
    }
}