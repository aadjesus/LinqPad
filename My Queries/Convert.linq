<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	//"10".Converter<int>().Dump("String'numeric' to int");	
	//"a".Converter<int>().Dump("String'alphanumeric' to int");	
	//"a".Converter<int?>().Dump("String'alphanumeric' to int'Nullable'");
	//(10.991).Converter<int>().Dump();
	//var x1  = (10.991);
	//x1.GetType().Dump();
	//double.TryParse(
	//int.TryParse(
	double x1 = 10.991;
	int x2 = 0;
	Int32.TryParse(x1.ToString(), out x2).Dump();
	x2.Dump();
	Convert.ChangeType(x2.ToString().Replace('.',','), typeof(int)).Dump();
	
}

public static partial class ExtensaoDeMetodos
{
	public static TResult Converter<TResult>(
		this object objeto, 
		TResult valorDefault = default(TResult))
    {
		if (objeto == null || !objeto.ToString().Any() || !(objeto is IConvertible))
        	return valorDefault;
	
		var tipoRetorno = typeof(TResult);	
		
		if (tipoRetorno == typeof(string))
			return (TResult)Convert.ChangeType(objeto, tipoRetorno);
			
		if (tipoRetorno.IsGenericType && 
			tipoRetorno.GetGenericTypeDefinition() == typeof (Nullable<>))
		{
			var tipoNullable = Nullable.GetUnderlyingType(tipoRetorno) ?? tipoRetorno;					
			return objeto.Converter(tipoNullable, valorDefault);
		}
		
		return objeto.Converter(tipoRetorno, valorDefault);
    }		
	
	private static TResult Converter<TResult>(
		this object objeto, 
		Type tipo, 
		TResult valorDefault)
	{			
		//TypeDescriptor.GetConverter(tipo).Dump();
//		var methodInfo = tipo.GetMethod (
//			"TryParse",  
//			new [] 
//			{
//				tipo,//typeof(string), 
//				tipo.MakeByRefType()
//			});
	 
	 var methodInfo = tipo.GetMethods().FirstOrDefault(f=> f.Name == "TryParse" && f.GetParameters().Length == 2);
	 
		if (methodInfo == null || !(bool)methodInfo.Invoke(null, new object[] {objeto, null}))
			return valorDefault;
			
		return (TResult)Convert.ChangeType(objeto, tipo);
	}
}