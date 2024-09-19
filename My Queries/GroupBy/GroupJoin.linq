<Query Kind="Program" />

void Main()
{
	List<Itinerario> listaItinerario = new List<Itinerario>() 
	{
		new Itinerario(){ CodIntLinha=1, IdItinerario=3, VigenciaInicial = new DateTime(2010, 1,2) }, 
		new Itinerario(){ CodIntLinha=1, IdItinerario=2, VigenciaInicial = new DateTime(2010, 2,1) }, 
		new Itinerario(){ CodIntLinha=2, IdItinerario=1, VigenciaInicial = new DateTime(2010, 1,1) }, 
		new Itinerario(){ CodIntLinha=3, IdItinerario=1, VigenciaInicial = new DateTime(2010, 1,1) }, 
		new Itinerario(){ CodIntLinha=4, IdItinerario=1, VigenciaInicial = new DateTime(2010, 1,1) } 
	};
	
  	List<Itinerario> novalistaItinerario = listaItinerario
		.GroupBy(g => g.CodIntLinha)
		.GroupJoin(listaItinerario,
					o => o.Key,
					od => od.CodIntLinha,
					(o, od) => new
					{
						CodIntLinha = o.Key,
					 	VigenciaInicial = od.Max(m => m.VigenciaInicial)
					})
					.GroupJoin(listaItinerario,
								o => new { o.CodIntLinha, o.VigenciaInicial },
								od => new { od.CodIntLinha, od.VigenciaInicial },
								(o, od) => new Itinerario()
								{
									CodIntLinha = o.CodIntLinha,
									VigenciaInicial = o.VigenciaInicial,
									IdItinerario = od.Max(m => m.IdItinerario)
								})
					.ToList().Dump("Resultado");
					
			if (novalistaItinerario == null)
			{

			}
	
}


private struct Itinerario
{
	public int CodIntLinha;
	public int IdItinerario;
	public DateTime VigenciaInicial;	
}