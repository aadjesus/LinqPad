<Query Kind="Program" />

// Teste de agrupamento
void Main()
{
	 List<sServicos> lista = new List<sServicos>()
	 {
	 	new sServicos() { Filial=1, Linha = 2, Servico = "10A", Horario =2},
		new sServicos() { Filial=1, Linha = 4, Servico = "10A", Horario =1},
		new sServicos() { Filial=1, Linha = 4, Servico = "10A", Horario =2},
		new sServicos() { Filial=1, Linha = 4, Servico = "10A", Horario =2},
		new sServicos() { Filial=1, Linha = 4, Servico = "11A", Horario =1},
		new sServicos() { Filial=1, Linha = 4, Servico = "11A", Horario =2},
		new sServicos() { Filial=1, Linha = 4, Servico = "11A", Horario =2},
		new sServicos() { Filial=1, Linha = 4, Servico = "11A", Horario =3},
	}.Dump("Lista atual");
	
	var newLista = lista
		.GroupBy(g => new 
		{
			g.Filial, 
			g.Linha, 
			g.Servico 
		})
		.SelectMany(s => lista
							.Where(w => w.Filial.Equals(s.Key.Filial) &&
							  	        w.Linha.Equals(s.Key.Linha) &&
										w.Servico.Equals(s.Key.Servico))
						    .GroupBy(g => g.Horario)
							.Select((s1, index) => new
							{
								Index = index + 1,
								Filial = s.Key.Filial,
								Linha = s.Key.Linha,
								Servico = s.Key.Servico,
								Horario = s1.Key
						    }))
							.Dump("Resultado");
	
}

private struct sServicos
{
	public int Filial;
	public int Linha;
	public string Servico;
	public int Horario;
}