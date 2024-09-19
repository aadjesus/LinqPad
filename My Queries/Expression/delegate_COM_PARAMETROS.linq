<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>C:\Globus5\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
</Query>

void Main()
{
	Func<IEnumerable<ItinerarioVO>, string, bool, ItinerarioVO> PrimeiroOuUltimoPontoSentido =
			delegate(IEnumerable<ItinerarioVO> lista, string sentido, bool primeiroPonto)
			{
				ItinerarioVO[] listaItinerarioVO = lista
					.Where(w => w.Sentido.Equals(sentido))
					.OrderBy(o => o.Sequencial)
					.ToArray();
				if (primeiroPonto)
					return listaItinerarioVO.First();
				else
					return listaItinerarioVO.Last();
			};
	
	List<ItinerarioVO> lista1 = new List<ItinerarioVO>();
	lista1.Add(new ItinerarioVO() { Sequencial=1, Sentido="I", Distancia=1} );
	lista1.Add(new ItinerarioVO() { Sequencial=2, Sentido="I", Distancia=2} );
	lista1.Add(new ItinerarioVO() { Sequencial=1, Sentido="V", Distancia=1} );
	lista1.Add(new ItinerarioVO() { Sequencial=2, Sentido="V", Distancia=2} );
	lista1.Add(new ItinerarioVO() { Sequencial=3, Sentido="V", Distancia=3} );
	
	PrimeiroOuUltimoPontoSentido(lista1, "I", false).Distancia.Dump("1");
	PrimeiroOuUltimoPontoSentido(lista1, "V", false).Distancia.Dump("2");

	PrimeiroOuUltimoPontoSentido(lista1, "I", true).Distancia.Dump("3");
	PrimeiroOuUltimoPontoSentido(lista1, "V", true).Distancia.Dump("4");


}

public class ItinerarioVO
{
	public int CodIntLinha;
	public int IdItinerarioVO;
	public DateTime HorarioInicial;
	public string Sentido ;
	public int Sequencial ;
	public int CodLocalidade;
	public int Distancia ;
	public DateTime Tempo;
}