<Query Kind="Program" />

void Main()
{
	List<Foo> lista = new List<Foo>();
	lista.Add(new Foo(){ cod1 = 1, cod2=1, desc = "a-1-1 "});
	lista.Add(new Foo(){ cod1 = 1, cod2=2, desc = "c-1-2 "});
	lista.Add(new Foo(){ cod1 = 1, cod2=3, desc = "c-1-3 "});
	lista.Add(new Foo(){ cod1 = 1, cod2=3, desc = "c-1-33"});
	lista.Add(new Foo(){ cod1 = 2, cod2=1, desc = "a-2-1 "});
	lista.Add(new Foo(){ cod1 = 3, cod2=1, desc = "b-3-1 "});
	lista.Add(new Foo(){ cod1 = 3, cod2=2, desc = "a-3-2 "});
	
	lista
		.GroupBy(g=> g.cod1, (a,b) => b.FirstOrDefault(f=> f.cod2 == b.Max(m=> m.cod2)))
		.Dump();
}

class Foo
{
	public int cod1;
	public int cod2;
	public string desc;
}
