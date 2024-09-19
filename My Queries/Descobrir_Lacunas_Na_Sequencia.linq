<Query Kind="Program" />

void Main()
{
	var seq = (new int [] {15,12,1,2,3,5,6,8,20,21,50}).OrderBy(o=> o);	
	
	seq.Aggregate(new List<string>(),(retorno,item)=>
	{
		var ultimo = seq.FirstOrDefault(f=> f > item);
		var promixo = item+1;
		if (promixo != ultimo && ultimo != 0)
		{
			var x1 = Enumerable.Range(promixo,ultimo-promixo).Select(s=>s.ToString());
			if (x1.Count() > 3)			
				x1 = new []  { string.Concat( x1.First(),"...", x1.Last())};
			retorno.Add(string.Join(",", x1));
		}
			
		return retorno;
	}).Dump();
		
		
}

// Define other methods and classes here
