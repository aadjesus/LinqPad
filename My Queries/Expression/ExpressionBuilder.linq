<Query Kind="Program" />

void Main()
{
	List<Foo> aaa = new List<Foo>();
	aaa.Add(new Foo(){ Codigo = 1, Nome = "A"});
	aaa.Add(new Foo(){ Codigo = 2, Nome = "A"});
	aaa.Add(new Foo(){ Codigo = 3, Nome = "A"});
	aaa.Add(new Foo(){ Codigo = 1, Nome = "B"});
	
	List<Filter> filter = new List<Filter>()
 	{
		//     new Filter { PropertyName = "Codigo" , Operation = Op.Igual, Value =  1  },
		//	   new Filter { PropertyName = "Nome"   , Operation = Op.Igual, Value = "a" }
     
	 	new Filter { PropertyName = "Codigo" ,  Operation = Op.MaiorOuIgual, Value = 1 },
	 	new Filter { PropertyName = "Codigo" ,  Operation = Op.MenorOuIgual, Value = 2 }
	 
 	};
 
 var deleg = ExpressionBuilder.GetExpression<Foo>(filter).Compile();
 
 aaa
 	.Where(deleg).Dump();
 
}

public class Foo
{
	public int Codigo {get;set;}
	public string Nome {get;set;}
}

 public class Filter 
 {
     public string PropertyName { get ; set ; }
     public Op Operation { get ; set ; }
     public object Value { get ; set ; }
 }

public enum Op 
 {
	Igual,
    MaiorQue,
    MenorQue,
    MaiorOuIgual,
    MenorOuIgual,
    Contem,
    ComecaCom,
    TerminaCom 
 }

public static class ExpressionBuilder 
 {
     private static MethodInfo containsMethod = typeof(string).GetMethod("Contains" );
     private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type [] {typeof(string)});
     private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type [] { typeof(string)}); 
 
     public static Expression<Func<T,bool>> GetExpression<T>(IList<Filter> filters)
     {            
         if  (filters.Count == 0)
             return null ;
 
         ParameterExpression param = Expression.Parameter(typeof (T), "t" );
         Expression exp = null ;
 
         if  (filters.Count == 1)
             exp = GetExpression<T>(param, filters[0] );
         else  if  (filters.Count == 2)
             exp = GetExpression<T>(param, filters[0], filters[1]);
         else 
         {
             while  (filters.Count > 0)
             {
                 var  f1 = filters[0];
                 var  f2 = filters[1];
 
                 if  (exp == null )
                     exp = GetExpression<T>(param, filters[0], filters[1]);
                 else 
                     exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));
 
                 filters.Remove(f1);
                 filters.Remove(f2);
 
                 if  (filters.Count == 1)
                 {
                     exp = Expression .AndAlso(exp, GetExpression<T>(param, filters[0]));
                     filters.RemoveAt(0);
                 }
             }
		}
 
         return Expression.Lambda<Func<T, bool>>(exp, param);
     }

     private static Expression GetExpression<T>(ParameterExpression param, Filter filter)
     {
         MemberExpression member = Expression.Property(param, filter.PropertyName);
         ConstantExpression constant = Expression.Constant( filter.Value);
 
         switch (filter.Operation)
         {	 
             case  Op.Igual:
                 return Expression.Equal(member, constant);
 
             case  Op.MaiorQue:
                 return Expression.GreaterThan(member, constant);
 
             case Op.MaiorOuIgual:
                 return Expression.GreaterThanOrEqual(member, constant);
 
             case Op.MenorQue:
                 return Expression.LessThan(member, constant);
 
             case Op.MenorOuIgual:
                 return Expression.LessThanOrEqual(member, constant);
 
             case Op.Contem:
                 return Expression.Call(member, containsMethod, constant);
 
             case Op.ComecaCom:
                 return Expression.Call(member, startsWithMethod, constant);
 
             case Op.TerminaCom:
                 return Expression.Call(member, endsWithMethod, constant);
         }
 
         return null ;
     }
 
     private static BinaryExpression GetExpression<T>(ParameterExpression param, Filter filter1, Filter  filter2)
     {
         Expression bin1 = GetExpression<T>(param, filter1);
         Expression bin2 = GetExpression<T>(param, filter2);
 
         return  Expression.AndAlso(bin1, bin2);
     }
 }