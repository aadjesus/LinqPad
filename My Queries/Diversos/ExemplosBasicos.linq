<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>System.Web.Services.Protocols</Namespace>
  <Namespace>System.Linq</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	#region ************* SequenceEqual *************
		int[] sequenceEqual1 = new int[] {1,2,3};
	int[] sequenceEqual2 = new int[] {1,2,3};
	
	sequenceEqual1.SequenceEqual(sequenceEqual2).Titulo("SequenceEqual","Compra duas listas. Obs: Os itens tem que estar ordenados");
	
	
	#endregion

	#region ************* Repeat ************* 
	
	Enumerable
		.Repeat("Texto ", 2).Titulo("Repeat", "Repete um objeto conforme a quantidade informada");

	#endregion
	
	#region ************* Reverse *************	
	
	(new char[] {'A','l','e','s','s','a','n','d','r','o'})
		.Reverse().Titulo("Reverse", "Inverte a ordem da lista");
	
	#endregion
	
	#region ************* Range *************	
	
	Enumerable
		.Range(0, 5).Titulo("Range","Cria um lista de int");	
	
	#endregion
	
	#region ************* DefaultIfEmpty *************
	
	(new string[] {"Texte1", "Texte2", "Texte3", "Texte4"})
		.Where(n => n.Equals("Texte5"))
		.DefaultIfEmpty("Texte5").Titulo("DefaultIfEmpty","Define um valor se o mesmo ñ existe em um retorno");	
		
	#endregion

	#region ************* Except *************
	
	int[] listaExcept1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	int[] listaExcept2 = new int[] {          4, 5, 6,       10 };
 
//	int[] listaExcept1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
//	int[] listaExcept2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
 
	listaExcept1
		.Except(listaExcept2).Titulo("Except","Cria lista sem os itens duplicados ");	
		
	listaExcept2
		.Except(listaExcept1).Titulo("Except","Cria lista sem os itens duplicados ");	
	
	#endregion
	
	#region ************* Intersect *************
	
	string[] listaIntersect1 = { "a","b","c","e","f","g" }; 
	string[] listaIntersect2 = { "a","e","f","a","b","a" };   
//	string[] listaIntersect1 = { "a","b","c","e","f","g" }; 
//	string[] listaIntersect2 = { "a","b","c","e","f","g" }; 

	listaIntersect1
		.Intersect(listaIntersect2).Titulo("Intersect","Cria lista com os itens comuns nas duas listas");	

	#endregion
	
	#region ************* Any *************
	
	(new string[] { "Texte1", "Texte2", "Texte3", "Texte4" })
		.Any(a => a.Equals("Texte1") ).Titulo("Any","Verifica se um determidado valor existe na lista");	
		
	#endregion
	
	#region ************* LongCount *************
	
	(new string[] { "Texte1", "Texte2", "Texte3", "Texte4" })
		.LongCount().Titulo("LongCount","Retorna a quantidade de itens de uma lista");	
			
	#endregion
	
	#region ************* Array *************
	
	Array
		.Find(new string[] { "a", "b", "c", "d" }, item => item.Equals("a")).Titulo("Array.Find","Procura um determinado item na lista");	
		
	Array
		.FindAll(new int[] {1,2,3,4,5} , item => item <= 3).Titulo("Array.FindAll","Retorna itens conforme condição");	
		
	#endregion
	
	#region ************* ZIP *************
		
	int[] listaCodigo = { 1, 2, 3, 4 };
	string[] listaDesc = { "aaaaa", "bbbbbb", "ccccc"};
	listaCodigo
		.Zip(listaDesc, (a, b) => String.Concat(a, " - " , b)).Titulo("ZIP", "Junta as listas");

	#endregion	
	
	#region ************* ALL *************
	
	(new string[] {"A","A","a"})
		.All(a => a == "A").Titulo("All", "Testa se TODOS itens da lista satisfazem uma condição");
	
	#endregion		
	
	
}

public static class Util
{

	public static TSource Titulo<TSource>(this TSource source, string titulo, string descicao)
    {
	   source.Dump(String.Concat(titulo, Environment.NewLine, descicao));
	   
	   return source;
    }
}

