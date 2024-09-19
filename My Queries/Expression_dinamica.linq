<Query Kind="Program" />

void Main()
{
	var certificado = new CertificadoX509Praxio()
	{
		NotAfter  = new DateTime(2022,7,21, 11,52,55),
		NotBefore = new DateTime(2022,7,01, 11,52,55)
	};	
	
	certificado.validarParametros(ExpressionType.LessThan,    v => v.NotAfter,"Data de validade do certificado expirada");
	certificado.validarParametros(ExpressionType.GreaterThan, v => v.NotBefore,"Data do certificado inválida");
}
		
class CertificadoX509Praxio
{
	public DateTime NotBefore;
    public DateTime NotAfter;
}

public static class Util
{	
	public static void validarParametros<TSource>(
		this TSource certificado, 
		ExpressionType operation, 
		Expression<Func<TSource, DateTime>> value, 
		string mensagem)
	{
		var valor = value.Compile().Invoke(certificado);
	    var makeBinary = Expression.MakeBinary(
			operation, 
			Expression.Constant(valor), 
			Expression.Constant(DateTime.UtcNow.ToLocalTime()));
			
		makeBinary.ToString().Dump("Condição: " + operation);
		var expression = Expression.Lambda<Func<TSource, bool>>(
			makeBinary, 
			Expression.Parameter(typeof(TSource)));	
		
		if (expression.Compile().Invoke(certificado).Dump())
			throw new Exception(mensagem +": "+ valor);
	}
}