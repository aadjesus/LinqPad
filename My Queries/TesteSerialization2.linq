<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var x1 = new Foo<Foo1>()
		.Add("aaa1","bbbb1")
		.Add("aaa2","bbbb2")
		.Add("aaa3","bbbb3")
		.Add(p=> p.Codigo,50)
		.Add(p=> p.Descricao,"asdasdas")
		.Add(p=> p.xxxxxxx,new Foo1(){ Codigo = 100, Descricao = "fffffff"})
		;
		
	x1.Retornar<List<Foo1>>().Dump();
}

class Foo1
{
	public int Codigo {get;set;}
	public string Descricao {get;set;}
	public Foo1 xxxxxxx {get;set;}
}

class Foo<T>
{
	private Dictionary<string,object>  _dictionary;
	
	private Dictionary<string,object> Prorpiedade 
	{
		get 
		{
			if (_dictionary == null)
				_dictionary = new Dictionary<string,object>();
				
			return _dictionary;
		}
	}
	
	public Foo<T> Add<Key>(Expression<Func<T,Key>> nome, Key valor)
	{
		Prorpiedade.Add((nome.Body as MemberExpression).Member.Name,valor);
		
		return this;
	}	
	
	public Foo<T> Add(string nome, string valor)
	{
		Prorpiedade.Add(nome,valor);
		
		return this;
	}
	
	public TReturn Retornar<TReturn>()
	{
		var x1 = JsonConvert.SerializeObject(_dictionary).Dump();
		
		JsonConvert.DeserializeObject<Dictionary<string,object>>(x1).Dump();
		JsonConvert.DeserializeObject<Foo1>(x1).Dump();
		
		return default(TReturn);
	}
}