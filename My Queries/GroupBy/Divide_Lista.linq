<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
</Query>

void Main()
{
	IEnumerable<Item> lista = Enumerable
		.Range(0,13)
		.Select((s,index)=> new Item()
		{ 
			Codigo =  index,
			Descricao = "Descricao" + index.ToString()
		});

	IEnumerable<Item> lista2 = lista
		.Select((s,index) => new 
		{
			Grupo = index / 5,
			Item = s
		})
		.GroupBy(g => g.Grupo ,(chave, listaGrupo) => listaGrupo.Select(s=> s.Item).ToArray().Dump() )
		.Aggregate(new List<Item>(), (a,b) => 
		{
		 	a.AddRange( RetornarItens(b) );
			return a;
		})		
		.Dump()
		;	
	
}


	public Item[] RetornarItens(Item[] itens)
	{
		return itens
			.Where((w,index)=> (index % 2).Equals(0) )
			.ToArray();
	}
	

	public class Item
	{
		public int Codigo;
		public string Descricao;	
	}