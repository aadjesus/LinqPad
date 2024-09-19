<Query Kind="Program">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	string[] listaIgnora = new string[] 
	{
		"Assembly","AssemblyQualifiedName","Attributes","CustomAttributes","DeclaredConstructors","DeclaredEvents","DeclaredFields","DeclaredMembers","DeclaredMethods",
		"DeclaredNestedTypes" ,"DeclaredProperties","GenericTypeArguments","GenericTypeParameters","GUID","ImplementedInterfaces","StructLayoutAttribute","TypeHandle",
		"DeclaringMethod","GenericParameterAttributes","GenericParameterPosition","DeclaringType","ReflectedType","TypeInitializer"};
	
	Type[] lista = new Type[] 
	{
		typeof(object),
		typeof(string),
		typeof(int),
		typeof(DateTime),
		typeof(MyClass),	
		typeof(MyEnum),
		typeof(int[]),
	};	
	
	var x1 =  typeof(object).GetType().GetProperties()
		.Where(w=> !listaIgnora.Contains(w.Name))
		.OrderBy(o=> o.Name)
		.ToArray();	
	
	string[,] a2 = new string [lista.Length, x1.Length];
	for (int i = 0; i < lista.Length; i++)
	{
		foreach (var element2 in lista[i].GetType().GetProperties()
									.Where(w=> !listaIgnora.Contains(w.Name)))
		{	
			try
			{	       
				int x2 = Array.IndexOf(x1,element2);
				
				a2[i,x2] = element2.GetValue(lista[i]).ToString();
				a2[0,x2] = element2.Name;
				
			}
			catch 
			{
				//lista[i].Dump();
			}
		}		
	}
	 
	a2.Dump();
	
	object[] aaa = new object[]
	{
		"",0,DateTime.Now,MyEnum.a, new MyClass(), new int[5],new List<int>(),
	};

	typeof(string).FullName.Dump("1");
	
	foreach (var element in aaa)
	{
		StringBuilder a3 = new StringBuilder();
		
//		a3.Append("IComparable: ");
//		a3.Append(element is IComparable);
//		a3.Append(";");
//		a3.Append("IsArray: ");
//		a3.Append(element.GetType().IsArray);
		
		a3.Append(element.GetType().FullName);
		
		a3.ToString().Dump();
	}
	
	
}

enum MyEnum
{
	a
}
class MyClass
{
	
}
