<Query Kind="Program" />

void Main()
{
	List<string> lista = new List<string>() {"1I","1V","2I","2V","3I","3V"}.Dump("Lista atual");
	
	var retornoLista = lista
		.Select((s,index)=> new 
		{  
		    Index = index+1,
			Tabela = (index+1) % 2 == 0,
		 	Sentido = String.Concat("<tr>",s,"</tr>")
		}).Dump("Lista1")
		.Aggregate(string.Empty, 
				   (a,b) => (b.Index.Equals(1) ? "<tb>":"") 
				   		  + a 
						  +	b.Sentido 
						  + (b.Tabela && b.Index > 1 ? "</tb>" + (b.Index < lista.Count() ? "<tb>" : "") : ""))
		.Dump("Lista2")
	;
}