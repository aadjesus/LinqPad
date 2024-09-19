<Query Kind="Program" />

void Main()
{
	qtde = Environment.ProcessorCount.Dump("Qtde processador+núcleo");
	CriaLista();	
	
	Linq();	
	PLinq();	
}

private TimeSpan TotalTempo
{
	get
	{
		return DateTime.Now.TimeOfDay.Subtract(dataIni.TimeOfDay) ;
	}
}

private void CriaLista()
{	
	dataIni = DateTime.Now;
	for (Int32 i = 0; i < 10000000; i++)
	{
		sTeste item = new sTeste();
		item.Codigo = i;
		item.Descricao = i.ToString();		
		lista.Add(item);
	}	
	TotalTempo.Dump("Tempo criando lista") ;
	lista.Count.Dump("Qtde itens");
}

private void PLinq()
{
	dataIni = DateTime.Now;
	lista
					.AsParallel()
		.WithDegreeOfParallelism(qtde)
	
		.GroupBy(g => g.Codigo % 2)
		.Select(s=> new 
			{
				Valor = s.Key, 
				Qtde = s.Count()
			})


			.Dump("Qtde (par/impar) 'PLinq'");	
			
	TotalTempo.Dump("Tempo") ;
}

private void Linq()
{
	dataIni = DateTime.Now;	
	lista
		.GroupBy(g => g.Codigo % 2)
		.Select(s=> new 
				{
					Valor = s.Key, 
					Qtde = s.Count()
				})
		.Dump("Qtde (par/impar) 'Linq'") ;	
			
	TotalTempo.Dump("Tempo criando lista") ;

}


private List<sTeste> lista = new List<sTeste>();
private DateTime dataIni = DateTime.Now;
private int qtde = 0;

private struct sTeste
{
	public Int32 Codigo;
	public string Descricao;
}