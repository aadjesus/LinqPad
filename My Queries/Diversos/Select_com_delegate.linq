<Query Kind="Program" />

void Main()
{
	int a1=0;
	Enumerable
		.Range(0,10).Dump()
		.Select(delegate(int a)
		{
			if (a1==5)
			{
				a1 = 10;
			}
			
			return new ItinerarioHorarioItens()
			{ 
				CodIntLinha = ++a1,
				IdItinerario = a
			};
		})	
	.Dump();

}


public class ItinerarioHorarioItens
{
	public int CodIntLinha;
	public int IdItinerario;
	public string Sentido ;
	public int Sequencial ;
	public int CodLocalidade;
	public int Distancia ;
	public DateTime Tempo;

}