<Query Kind="Program" />

static void Main()
{
	List<int> numeros = new List<int>();
	numeros.Add(1);
	numeros.Add(11);
	numeros.Add(7);
	numeros.Add(56);
	numeros.Add(80);

	RecuperaNumerosMaioresQue10_1(numeros).Dump();
	RecuperaNumerosMaioresQue10_2(numeros).Dump();
}

public static IEnumerable RecuperaNumerosMaioresQue10_1(IList numeros)
{
	IList<int> numerosMaioresQue10 = new List<Int32>();
	foreach (int item in numeros)
		if (item > 10)
			numerosMaioresQue10.Add(item);
	return numerosMaioresQue10;
}

public static IEnumerable RecuperaNumerosMaioresQue10_2(IList<int> numeros)
{
	foreach (var item in numeros)
		if (item > 10)
			yield return item;
}