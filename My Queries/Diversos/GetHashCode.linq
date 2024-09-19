<Query Kind="Program" />

void Main()
{
	List<Classe_Com_GetHashCode> listaClasse_Com_GetHashCode = new List<Classe_Com_GetHashCode>();
	listaClasse_Com_GetHashCode.Add(new Classe_Com_GetHashCode { Nome="Nome1", Valor=0,  Tipo=1});
	listaClasse_Com_GetHashCode.Add(new Classe_Com_GetHashCode { Nome="Nome1", Valor=0,  Tipo=1});
	listaClasse_Com_GetHashCode.Add(new Classe_Com_GetHashCode { Nome="Nome1", Valor=0,  Tipo=1});
	listaClasse_Com_GetHashCode.Add(new Classe_Com_GetHashCode { Nome="Nome1", Valor=0 , Tipo=1});
	listaClasse_Com_GetHashCode.Add(new Classe_Com_GetHashCode { Nome="Nome2", Valor=0 , Tipo=1});
	listaClasse_Com_GetHashCode.Add(new Classe_Com_GetHashCode { Nome="Nome3", Valor=0 , Tipo=1});	
		
	List<Classe_Sem_GetHashCode> listaClasse_Sem_GetHashCode = new List<Classe_Sem_GetHashCode>();
	listaClasse_Sem_GetHashCode.Add(new Classe_Sem_GetHashCode { Nome="Nome1", Valor=0,  Tipo=1});
	listaClasse_Sem_GetHashCode.Add(new Classe_Sem_GetHashCode { Nome="Nome1", Valor=0 , Tipo=1});
	listaClasse_Sem_GetHashCode.Add(new Classe_Sem_GetHashCode { Nome="Nome2", Valor=0 , Tipo=1});
	listaClasse_Sem_GetHashCode.Add(new Classe_Sem_GetHashCode { Nome="Nome3", Valor=0 , Tipo=1});		
			
	listaClasse_Com_GetHashCode
		//.Dump("Lista original - Com GetHashCode")
		.Select(s=> s.GetHashCode())
		.GroupBy(g=> g,(key,lista) => new {key, qtde = lista.Count()})
		.Dump("Lista agrupada - Com GetHashCode");
	
	listaClasse_Sem_GetHashCode
		//.Dump("Lista original - Com GetHashCode")
		.Select(s=> s.GetHashCode())
		.GroupBy(g=> g,(key,lista) => new {key, qtde = lista.Count()})
		.Dump("Lista agrupada - Com GetHashCode");
}

class Classe_Sem_GetHashCode
{
	public string Nome { get; set; }
	public double Valor { get; set; }
	public int Tipo { get; set; }
}

class Classe_Com_GetHashCode
{
	public string Nome { get; set; }
	public double Valor { get; set; }
	public int Tipo { get; set; }
	
	public override bool Equals( object obj )
	{
		if( this == obj ) 
			return true;
		if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) 
			return false;
		Classe_Com_GetHashCode castObj = (Classe_Com_GetHashCode)obj; 
		return ( castObj != null ) &&
			  ( this.Nome == castObj.Nome );
	}
		
	public override int GetHashCode()
	{
		int hash = 57; 
		hash = 27 * hash * Nome.GetHashCode();
		return hash; 
	}
	
}