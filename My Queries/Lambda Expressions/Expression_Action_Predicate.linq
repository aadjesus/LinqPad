<Query Kind="Program" />

void Main()
{	
	int codigo = 3;
	
	List<Cadastro> lista = new List<Cadastro>();
	lista.Add(new Cadastro() { Codigo=1, Data= DateTime.Now, Descricao="A"});
	lista.Add(new Cadastro() { Codigo=1, Data= DateTime.MaxValue, Descricao="A"});
	lista.Add(new Cadastro() { Codigo=1, Data= DateTime.Now, Descricao="B"});
	lista.Add(new Cadastro() { Codigo=3, Data= DateTime.Now, Descricao="B"});
	lista.Add(new Cadastro() { Codigo=4, Data= DateTime.Now, Descricao="A"});

	#region Expression simples
	
	Func<Cadastro, bool> Filtro1 = cadastro => cadastro.Codigo.Equals(codigo);		
	
	#endregion
	
	#region Expression com delegate
	
	Func<Cadastro, bool> Filtro2  = delegate(Cadastro cadastro) 
	{							       
		return cadastro.Codigo.Equals(codigo); 
	};
	
	#endregion

	#region Expression com parametros genericos

	Func<Cadastro, Expression<Func<Cadastro, object>>, object, bool> Filtro3 = delegate(Cadastro cadastro, Expression<Func<Cadastro, object>> campo, object valor)
	{
		MemberExpression memberExpression = null;
		UnaryExpression unaryExpression = campo.Body as UnaryExpression;
		
		if (unaryExpression == null)
			memberExpression = campo.Body as MemberExpression;
		else
			memberExpression = unaryExpression.Operand as MemberExpression;

		var valor1 = Convert.ChangeType(cadastro.GetType().GetProperty(memberExpression.Member.Name).GetValue(cadastro, null), memberExpression.Type);
		var valor2 = Convert.ChangeType(valor, memberExpression.Type);

		return valor1.Equals(valor2);
	};

	#endregion
						
	#region Predicate
	
	// Utilizando quando a expressão tiver um unico parametro
	Predicate<Cadastro> Filtro4 = p => p.Codigo.Equals(codigo) ;	
	
	#endregion	
	
	#region Action
	
	Action<bool> Mostra = p => Console.WriteLine(p) ;	
	
	#endregion

	lista
	    .Where(Filtro1)
		.Dump("Expression simples");
		
	lista
		.Where(Filtro2)
		.Dump("Expression com delegate");
		
	lista
		.Where(w=> Filtro3(w, f=> f.Codigo,1))
		.Dump("Expression com parametros genericos = Codigo")
		.Where(w=> Filtro3(w, f=> f.Descricao,"A"))
		.Dump("Expression com parametros genericos = Descricao")
		.Where(w=> Filtro3(w, f=> f.Data, DateTime.MaxValue))
		.Dump("Expression com parametros genericos = Data")
		;
	
	lista
		.Where(w=> Filtro4(w))
		.Dump("Predicate");	
	
	lista
		.Select(delegate(Cadastro cad)
		{
			Mostra(Filtro4(cad));			
			return 0;
		}).Dump();
	
}

public class Cadastro
{
	public int Codigo {get;set;}
	public string Descricao {get;set;}
	public DateTime Data {get;set;}
}