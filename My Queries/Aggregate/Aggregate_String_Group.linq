<Query Kind="Program" />

void Main()
{
	List<Deteccao> listaDeteccao = new List<Deteccao>() 
	{
		new Deteccao(){ DadosVeiculo="1", Latitude="11", Longitude="21", DataOcorrencia = new DateTime(2010, 1,1,10,10,1), Sentido="I" , Mensagem = "a" }, 
		new Deteccao(){ DadosVeiculo="2", Latitude="12", Longitude="22", DataOcorrencia = new DateTime(2010, 1,1,10,11,1), Sentido="I" , Mensagem = "b" }, 
		new Deteccao(){ DadosVeiculo="3", Latitude="12", Longitude="22", DataOcorrencia = new DateTime(2010, 1,1,10,12,1), Sentido="I" , Mensagem = "c" }, 
		new Deteccao(){ DadosVeiculo="4", Latitude="13", Longitude="23", DataOcorrencia = new DateTime(2010, 1,1,10,15,1), Sentido="I" , Mensagem = "d" }, 
		new Deteccao(){ DadosVeiculo="5", Latitude="14", Longitude="24", DataOcorrencia = new DateTime(2010, 1,1,10,20,1), Sentido="I" , Mensagem = "e" } 
	};
	
	var novaDeteccao = listaDeteccao
		.GroupBy(g => new
		{
			g.Latitude,
			g.Longitude
		})		
		.GroupJoin(listaDeteccao,
					a => new { a.Key.Latitude, a.Key.Longitude },
					b => new { b.Latitude, b.Longitude },
					(a, b) => 
					b.Aggregate(string.Empty, 
								(a1, b1) => a1 + String.Concat(a.Last().Equals(b1) 
																	? "" 
																	:  String.Concat("Qtde: ", a.Count(),  "\n"),
															   "Hora: ",     b1.DataOcorrencia.ToString("HH:mm:ss"),  "\n",
															   "Veiculo: ",  b1.DadosVeiculo,  "\n",
															   "Sentido: ",  b1.Sentido, "\n",
															   "Sentido: ",  b1.Latitude, " / ", b1.Longitude, "\n",
															   "Mensagem: ", b1.Mensagem , "\n",
																a.Last().Equals(b1) ? "" :"-----------------------------" +"\n"
														  	   )))
		.ToList()
		.Dump("Resultado");
		if (novaDeteccao == null)
		{
		
		}
}


private struct Deteccao
{
	public string DadosVeiculo;
	public string Latitude;
	public string Longitude;
	public DateTime DataOcorrencia;
	public string Sentido;
	public string Mensagem;
}