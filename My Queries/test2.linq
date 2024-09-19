<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	//((Foo[])Enum.GetValues(typeof(Foo))).Dump();
	//(Enum[]);
	MyExtension1.Teste1<Foo>();
	MyExtension1.Teste1<Foo>(Foo.a1);
}

public static class MyExtension1
{
	public static void Teste1<TSource>(params TSource[] lista)	
	{
		if (lista.Any())
		{		
		}
		
		foreach (Enum item in Enum.GetValues(typeof(TSource)))
		{
			item.Dump();
		}
	}	
	
	public static string GetDescription(this Enum en) //ext method
        {

            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {

                object[] attrs = memInfo[0].GetCustomAttributes(
                                              typeof(DescriptionAttribute),

                                              false);

                if (attrs != null && attrs.Length > 0)

                    return ((DescriptionAttribute)attrs[0]).Description;

            }

            return en.ToString();

        }
}	

enum Foo
{
	a1,b1
}