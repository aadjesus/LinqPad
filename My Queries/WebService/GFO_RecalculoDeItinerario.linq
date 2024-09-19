<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>C:\Globus5\WPF\Distribuicao\FGlobus.Excecao.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
  <Namespace>FGlobus.Componentes.WinForms.ws.controle</Namespace>
  <Namespace>Globus5.WPF.Comum</Namespace>
  <Namespace>System.Web.Services.Protocols</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.gestaoDeFrotaOnline</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.escala</Namespace>
</Query>

void Main()
{
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");	
	
	var escala = WebServices.EscalaWSApp.RetornarEscalaProgramadaDoDia(new DateTime(2011,10,5),
	new int[] {24669},
	new int[] {24669})
	.Select(s => new 
		{
	 		Sentido = (s.Sentido == eSentido.Ida ? "I" : "V"),
			CodHorDiaria = s.CodigoHorario, 
			CodIntServDiaria = s.CodigoServico,
			CodIntTurno = s.CodigoTurno,
			HoraChegada = s.HoraChegadaProg,
			HoraSaida = s.HoraSaidaProg,
			TempoTotalViagem = s.HoraChegadaProg.Ticks - s.HoraSaidaProg.Ticks
		})
	;
	
	List<string> listaRetorno = new List<string>();
	
	ItinerarioDTO[] listaItinerarioDTO = new ItinerarioDTO[] { new ItinerarioDTO() { CodIntLinha = 24669, IdItinerario = 5}};
	ItinerarioItensDTO[] listaItinerarioItensDTO = WebServices.GestaoDeFrotaOnLineWSApp.RetornarItinerarioItensPorCodigoInternoLinaEIdItinerario(24669,5);	
	ItinerarioServicoDTO[] listaItinerarioServicoDTO = WebServices.GestaoDeFrotaOnLineWSApp.RetornarItinerarioServico(5,24669);
	
	Func<string,int> delegateUltimaDistanciaPonto = 
		delegate(string sentido)
		{
			return listaItinerarioItensDTO
			  		.Where(w => w.Sentido.Equals(sentido))
					.Max(m => m.Distancia);
		};
	
	#region ItinerarioItensDTO
	
	String.Concat("\n","DistanciaPonto = Distancia do ponto",
				  "\n","DistanciaUltimoPonto = Ultimo ponto do sentido",
				  "\n","TempoViagem = HoraChegadaProg - HoraSaidaProg",
				   "\n","NovoTempo = (TempoViagem * DistanciaPonto) / DistanciaUltimoPonto",
				   "\n","NovoTempoVisualizacao = Visualizacao do cadastro de itinerario",
				   "\n"
				   ).Dump();
				   
	var resultadoItinerarioItensDTO = listaItinerarioItensDTO
		.Join(escala.GroupBy(g=> g.Sentido,(chave,lista) => lista.FirstOrDefault()) , 
			a=> a.Sentido,
			b=> b.Sentido,
			(a,b) => new 
			{
				a.Sentido,
				a.Sequencial,
				a.Distancia,
				b.HoraChegada,
				b.HoraSaida,
				b.TempoTotalViagem,
				distanciaTotal = delegateUltimaDistanciaPonto(a.Sentido)
			}) 
			.Select(s=> new 
			{
				s.Sentido,
				s.Sequencial,				
				DistanciaPonto = s.Distancia,
				DistanciaUltimoPonto = s.distanciaTotal,
				HoraChegada = s.HoraChegada.ToString("HH:mm:ss"),
				HoraSaida = s.HoraSaida.ToString("HH:mm:ss"),
				TempoViagem = DateTime.Now.Date.AddTicks(s.TempoTotalViagem).ToString("HH:mm:ss"),
				NovoTempo = DateTime.Now.Date.AddTicks((s.TempoTotalViagem * s.Distancia) / s.distanciaTotal).ToString("HH:mm:ss"),
				NovoTempoVisualizacao = DateTime.Now.Date.AddTicks((s.TempoTotalViagem * s.Distancia) / s.distanciaTotal).ToString("HH:mm"),
			});
				
		#endregion
		
	#region ItinerarioServicoDTO
	
	listaItinerarioServicoDTO
		.Join(escala, 
			a=> new {a.Sentido, a.CodHorDiaria,a.CodIntServDiaria,a.CodIntTurno},
			b=> new {b.Sentido, b.CodHorDiaria,b.CodIntServDiaria,b.CodIntTurno},
			(a,b) =>
			new 
			{
				a,
				b
			}).Dump();
	
	
	#endregion
	
	//resultadoItinerarioItensDTO.Dump();
	
}