<Query Kind="Program" />

void Main()
{
	var x1 = new Foo[] 
	{
		new Foo(1,1,1,1),
		new Foo(1,1,2,2),
		new Foo(1,2,1,3),
		new Foo(1,2,3,4),
		new Foo(2,1,1,5)
	};
	
	//x1.Except
	x1
	.GroupBy(g=> g.Emp)
	.Select(s=> new Empresa(
						s.Key, 
						s.GroupBy(g => g.Fil)
							.Select(s2=> new Filial(
												s2.Key, 
												s2.Select(s3 => new Garagem(
																		s3.Gar, 
																		s3.Id)))))).Dump();	
	
}

class Empresa : ItemFoo
{
	public Empresa(int id, IEnumerable<ItemFoo> filiais) : base(id,"Empresa")
	{
		Filiais = filiais;
	}
	public IEnumerable<ItemFoo> Filiais;
}

class Filial : ItemFoo
{
	public Filial(int id, IEnumerable<ItemFoo> garagens) : base(id,"Filial")
	{
		Garagens = garagens;
	}
	public IEnumerable<ItemFoo> Garagens;
}

class Garagem : ItemFoo
{
	public Garagem(int id, int idDado) : base(id,"Garagem")
	{
		IdDado = idDado;
	}
	public int IdDado;
}

class ItemFoo
{
	public ItemFoo(int id, string descricao)
	{
		Codigo = id.ToString();
		Descricao = descricao + " - " + Codigo;
	}
	
	public string Codigo;
	public string Descricao;	
}

class Foo
{
	public Foo(int emp,	int fil,	int gar,	int id)
	{
		Emp = emp;
		Fil = fil;
		Gar = gar;	
		Id =  id ;
	}
	public int Emp;
	public int Fil;
	public int Gar;
	public int Id ;
}