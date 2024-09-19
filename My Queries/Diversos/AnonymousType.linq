<Query Kind="Program" />

void Main()
{
	Type anonType = new 
	{ 
		Propriedade1 = String.Empty, 
		Propriedade2 = 0 
	}
	.GetType();
	
	var exp = Expression.New(
			anonType.GetConstructor(new[] { typeof(string), typeof(int) }),
            Expression.Constant("def"),
            Expression.Constant(456));
			
	LambdaExpression lambda = LambdaExpression.Lambda(exp);
	object myObj = lambda.Compile().DynamicInvoke();

	Console.WriteLine(myObj);	
}

// Define other methods and classes here
