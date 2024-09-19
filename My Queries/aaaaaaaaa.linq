<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	var x1 = new Foo1()
	{ 
	    cod = 15,
		Teste2 = new Foo2()
		{
	  		cod = 10,
	  		//Teste0 = new Foo0(){ cod2 = 11}  
		}				 
	};	
	
	
	x1.Test1(a=> a.Teste2.Teste0.cod2).Dump();
	//x1.Test1(a=> a.Teste2.cod).Dump();
	
	//Teste1.GetFullPropertyName<Foo1,int>(a=> a.Teste2.Teste0.cod).Dump();
	//typeof(Type).GetMethods().Dump();
	
	 
}

static class Teste1
{

public static string GetFullPropertyName<T, TProperty>(Expression<Func<T, TProperty>> exp)
{
    MemberExpression memberExp;
    if (!TryFindMemberExpression(exp.Body, out memberExp))
        return string.Empty;

    var memberNames = new Stack<string>();
    do
    {
        memberNames.Push(memberExp.Member.Name);
    }
    while (TryFindMemberExpression(memberExp.Expression, out memberExp));

    return string.Join(".", memberNames.ToArray());
}

private static bool TryFindMemberExpression(Expression exp, out MemberExpression memberExp)
{
    memberExp = exp as MemberExpression;
    if (memberExp != null)
    {
        // heyo! that was easy enough
        return true;
    }

  
    if (IsConversion(exp) && exp is UnaryExpression)
    {
        memberExp = ((UnaryExpression)exp).Operand as MemberExpression;
        if (memberExp != null)
        {
            return true;
        }
    }

    return false;
}

private static bool IsConversion(Expression exp)
{
    return (
        exp.NodeType == ExpressionType.Convert ||
        exp.NodeType == ExpressionType.ConvertChecked
    );
}

  public static T2 Test1<T,T2>(this T objeto, Expression<Func<T, T2>> expression)
  {
  	//  ------------------------------------------------------------------------------------------ 1
	//  object retrono = objeto;	
	//	foreach (var prop in aaa.Body.ToString().Split('.').Skip(1))
	//	{
	//		if (retrono != null)
	//		{
	//			var tipo = retrono.GetType();	 	
	//		 	retrono = tipo.GetProperty(prop).GetValue(retrono);
	//		 }		
	//	}
	//  return (T2)retrono;

  	//  ------------------------------------------------------------------------------------------ 2
	//   var memberNames = new List<MemberExpression>();
	//	 var memberExp = aaa.Body as MemberExpression;
	//	 do
	//    {
	//       memberNames.Add(memberExp.Member.Name);
	//    }
	//    while (TryFindMemberExpression(memberExp.Expression, out memberExp));

	//  ------------------------------------------------------------------------------------------ 3
	//	var memberExp = aaa.Body as MemberExpression;
	//	do
	//	{
	//		if (memberExp != null)
	//		{
	//			var lambdaExpression = Expression.Lambda(memberExp.Expression, aaa.Parameters.FirstOrDefault());
	//        	var subModel = lambdaExpression.Compile().DynamicInvoke(objeto);		
	//			subModel.Dump();
	//			if (subModel == null)
	//				memberExp = null;
	//			else
	//				memberExp = (memberExp.Expression as MemberExpression);		
	//		}
	//	}
	//	while (memberExp != null);

				object valor=null;
                try
                {
                    valor = expression.Compile().Invoke(objeto);					
					
                }
                catch
                {				
					var body = Expression.Default(expression.ReturnType);
            		var lambda = Expression.Lambda(body);
            		var func = lambda.Compile().DynamicInvoke();
					func.Dump();					
                }
                expression.ToString().Substring(expression.ToString().IndexOf('.') + 1).Dump();
				//valor.Dump();

//	expression.Body.ToString().Dump();
//	var memberExpression = expression.Body as MemberExpression;
//	var lambdaExpression = Expression.Lambda(memberExpression.Expression, expression.Parameters.FirstOrDefault());
//    var dynamicInvoke = lambdaExpression.Compile().DynamicInvoke(objeto);		
//	if (dynamicInvoke != null)
//	{
//		var x1 = System.Linq.Expressions.Expression.Constant(dynamicInvoke).Value;
//		var x2 = x1.GetType().GetProperty(memberExpression.Member.Name);				
//		var valor = x2.GetValue(x1, null);
//	
//		return (T2)valor;
//	}		
    return default(T2);
  }
	
}

class Foo0
{
	public int cod {get;set;}
	public string descricao {get;set;}
	public int cod2 {get;set;}
}

class Foo2
{
	public int cod;// {get;set;}	
	public string descricao {get;set;}
	public Foo0 Teste0 {get;set;}
}

class Foo1
{
	public int cod {get;set;}
	public string descricao {get;set;}
	public Foo2 Teste2 {get;set;}
}