<Query Kind="Program" />

void Main()
{
	Teste[] listaTeste = new Teste[] 
	{
		new Teste() { Codigo=1, Descricao="1111111111", Tipo= 1, Status = "A"},
		new Teste() { Codigo=2, Descricao="2222222222", Tipo= 4, Status = "B"},
		new Teste() { Codigo=3, Descricao="3333333333", Tipo= 1, Status = "C"},
		new Teste() { Codigo=4, Descricao="4444444444", Tipo= 2, Status = "A"},
		new Teste() { Codigo=5, Descricao="5555555555", Tipo= 3, Status = "A"},
		new Teste() { Codigo=6, Descricao="6666666666", Tipo= 3, Status = "A"},
		new Teste() { Codigo=7, Descricao="7777777777", Tipo= 1, Status = "B"},
		new Teste() { Codigo=8, Descricao="8888888888", Tipo= 4, Status = "C"}
	};

	ParameterExpression c = Expression.Parameter( typeof(Teste));
	
	Expression expressionWhereTipo = 
		Expression.Equal(Expression.Property(c, "Tipo"), Expression.Constant(1));
		
	Expression expressionWhereStatus = 
		Expression.Equal(Expression.Property(c, "Status"), Expression.Constant("C"));
		
	Expression<Func<Teste, bool>> expressionWhereTipoOuStatus = 
		Expression.Lambda<Func<Teste, bool>>(Expression.And(expressionWhereTipo, expressionWhereStatus), c);

	listaTeste	
		.Where(expressionWhereTipoOuStatus.Compile())
	.Dump();
		
}

public class Teste
{	
	public int Codigo;
	public string Descricao;
	public int Tipo {get;set;}
	public string Status {get;set;}
}

