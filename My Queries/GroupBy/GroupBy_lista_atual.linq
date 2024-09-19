<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	List<Classe> listaClasse = new List<Classe>
		{ 
			new Classe { Nome="Nome1", Valor=8.3, Tipo=1 },
			new Classe { Nome="Nome2", Valor=4.9 , Tipo=2},
			new Classe { Nome="Nome3", Valor=1.5 , Tipo=3},
			new Classe { Nome="Nome1", Valor=4.3 , Tipo=1} 
		};
	
	var query = listaClasse
		.GroupBy(g => g.Tipo,
			     (key, lista) => new 
				 {
				 	 
				 	a = lista.FirstOrDefault(),
					b = lista.Count()
				 }).OrderBy(o=> o.b).Dump() ;
}

class Classe
{
	public string Nome { get; set; }
	public double Valor { get; set; }
	public int Tipo { get; set; }
}