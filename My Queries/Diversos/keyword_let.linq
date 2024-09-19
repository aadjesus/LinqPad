<Query Kind="Program" />

void Main()
{
	int[] lista = new int[] {1,2,3,4,5};
	
	var query = from num in lista
 	let soma = lista.Sum()
 	select new
	{
		somatorio = soma,
		numero_somatorio = num + soma,
		numero_subtracao = soma - num
	};
	
	query.Dump();
}

public class Item
{
	public int Tipo;
	public int Sequencial;	
}
