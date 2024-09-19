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

	lista.AgrupaPropriedade<int>("Tipo").Dump("1");
	
}

public class Item
{
	public int Tipo;
	public int Sequencial;	
}

public static class Enumerable1
{

    public static T[] AgrupaPropriedade<T>(this IEnumerable source, string nomePropriedade)
	{
		try
		{
			return source.Cast<object>()
				.GroupBy(g => g.GetType().GetField(nomePropriedade).GetValue(g))
				.Select(s=> (T)s.Key)
				.ToArray();
		}
		catch (Exception)
		{
			throw new Exception();
		}
	}
}