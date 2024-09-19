<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>C:\Globus5\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
</Query>

void Main()
{
	List<Item> lista = new List<Item>();
	lista.Add( new Item(){ Tipo=0, Sequencial=1});
	lista.Add( new Item(){ Tipo=0, Sequencial=2});
	lista.Add( new Item(){ Tipo=0, Sequencial=3});
	lista.Add( new Item(){ Tipo=0, Sequencial=4});
	lista.Add( new Item(){ Tipo=1, Sequencial=1});
	lista.Add( new Item(){ Tipo=2, Sequencial=2});
	
 	Expression<Func<int, IEnumerable<Item>, int>> expressao = 
		(
			(a, b) => b.Where(w => w.Tipo.Equals(a))
//			(a, b) => b.Where(w => w.GetType().GetField("Tipo").GetValue(w).Equals(a))
					   .OrderBy(o => o.Sequencial)
					   .Last()
					   .Sequencial
		);

	int seq0 = expressao.Compile().Invoke(0, lista);
	int seq1 = expressao.Compile().Invoke(1, lista);
	seq0.Dump("Ultima sequencial do tipo = 0");
	seq1.Dump("Ultima sequencial do tipo = 1");
	
	
	Expression<Func<IEnumerable<object>,string, int[]>> expressao1 = 
		(
			(a,b) => a.GroupBy(g => g.GetType().GetField(b).GetValue(g) ).Select(s=> (int)s.Key).ToArray()
		);
	
	expressao1.Compile().Invoke(lista,"Sequencial").Dump("xxx");
}

public class Item
{
	public int Tipo;
	public int Sequencial;	
}