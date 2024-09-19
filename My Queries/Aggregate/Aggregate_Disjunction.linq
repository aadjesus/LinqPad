<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\Referencias\NHibernate\NHibernate.dll</Reference>
  <Namespace>NHibernate.Expression</Namespace>
</Query>

void Main()
{
	
	Disjunction disjunction = Enumerable.Range(1,12)
		.Select((s,index) => new 
		{
			Grupo = index / 10,
			Item =  s
		})
		.GroupBy( g => g.Grupo)
		.Aggregate(new Disjunction(), (retorno,item) =>
		{
	    	retorno.Add(NHibernate.Expression.Expression.In(
				"aaaa", 
				item
					.Select(s=> s.Item)
					.ToArray()));
			return retorno;
		})		
		.Dump();	
	
	
	
	
	
	
}