<Query Kind="Program" />

void Main()
{
	var data = DateTime.Now;	

	var modelosVigente = new List<ModeloVigenteData>
	{
		new ModeloVigenteData( new DateTime(2019,5,1), 10, new ModeloData(5,2)),
		//new ModeloVigenteData( new DateTime(2019,3,10), 10, new ModeloData(6,1)),		
		
		//new ModeloVigenteData( new DateTime(2019,3,10), 10, new ModeloData(eDiaDaSemana.Quinta)),				
		//new ModeloVigenteData( new DateTime(2019,3,10), 10, new ModeloData(eDiaDaSemana.Quinta, eDiaDaSemana.Sexta)),
		
		//new ModeloVigenteData( new DateTime(2019,5,1), 10, new ModeloData(eTipoFrequencia.Dia, 6, eDiaDaSemana.Quinta, eDiaDaSemana.Sexta, eDiaDaSemana.Sabado)),
	};

	var listaModVigente = modelosVigente
		.Where(w => w.Vigencia == modelosVigente
						.Where(w2 => w.Modelo.Tipo == w2.Modelo.Tipo &&
									 w.Modelo.QtdTrabalho == w2.Modelo.QtdTrabalho &&
									 w.Modelo.QtdFolga == w2.Modelo.QtdFolga &&
									 w.Modelo.TipoFrequencia == w2.Modelo.TipoFrequencia &&
									 w.Modelo.Frequencia == w2.Modelo.Frequencia &&
									 w.Modelo.Dias.All(a => w2.Modelo.Dias.Contains(a)) &&
									 w.Vigencia < data)
						.Max(m => m.Vigencia))
		.Select(s => new
		{
			s.Vigencia,
			s.Modelo,
			DiasDaSemana = s.Modelo.Dias
				.Select(s2 => s2.Dia),
			QtdeFuncionarios = s.Funcionarios.Count()
		})
		.ToList();

	var listaRetorno = new List<FolgaModel>();
	var pimeiroDiaMes = new DateTime(data.Year, data.Month, 1);
	var ultimoDiaMes = pimeiroDiaMes.AddMonths(1).AddDays(-1);

	foreach (var itemModVigente in listaModVigente)
	{
		var dataInicio = itemModVigente.Modelo.Tipo == eTipoDeFolga.Fixo
			? pimeiroDiaMes
			: itemModVigente.Vigencia;
		
		var contadorDia =  0;
		var contadorFreq = 0;
		var frequencia = (itemModVigente.Modelo.TipoFrequencia == eTipoFrequencia.Mes
			? 30
			: 1) * itemModVigente.Modelo.Frequencia;	
	
		Enumerable.Range(0, ultimoDiaMes.Subtract(dataInicio).Days)
			.AsParallel()
			.Aggregate(listaRetorno, (retorno, item) =>
			{
				var dia = dataInicio.AddDays(item);				
				
				contadorDia++;
				
				var incluir = 
					(itemModVigente.Modelo.Tipo == eTipoDeFolga.Corrido   && contadorDia > (itemModVigente.Modelo.QtdTrabalho ?? 0)) ||
		  			(itemModVigente.Modelo.Tipo == eTipoDeFolga.Fixo      && itemModVigente.DiasDaSemana.Contains((eDiaDaSemana)dia.DayOfWeek)) ||
		  			(itemModVigente.Modelo.Tipo == eTipoDeFolga.Alternada && itemModVigente.DiasDaSemana.Skip(contadorFreq).Take(1).Contains((eDiaDaSemana)dia.DayOfWeek));

				if (contadorDia == itemModVigente.Modelo.QtdTrabalho + itemModVigente.Modelo.QtdFolga ||
					contadorDia >= frequencia)
				{
					contadorDia = 0;
					if (++contadorFreq == itemModVigente.DiasDaSemana.Count())
						contadorFreq = 0;
				}

				if (incluir && dia >= pimeiroDiaMes)
				{
					((eDiaDaSemana)dia.DayOfWeek).Dump(dia.Day.ToString());	
					retorno.Add(new FolgaModel
					{
						Qtde = itemModVigente.QtdeFuncionarios,
						Dia = dia.Day,
						Tipo = itemModVigente.Modelo.Tipo,
						QtdTrabalho = itemModVigente.Modelo.QtdTrabalho,
						QtdFolga = itemModVigente.Modelo.QtdFolga,
						TipoFrequencia = itemModVigente.Modelo.TipoFrequencia,
						Frequencia = itemModVigente.Modelo.Frequencia,
						Semana = itemModVigente.DiasDaSemana
					});
				}

				return retorno;
			});	
		
	}
	
	listaRetorno.Dump();

}

class ModeloVigenteData
{
	public ModeloVigenteData(DateTime vigencia, int qtdeFunc, ModeloData modelo)
	{
		Vigencia = vigencia;
		Modelo = modelo;
		Funcionarios = Enumerable.Range(1, qtdeFunc);
	}

	public virtual DateTime Vigencia { get; set; }
	public virtual ModeloData Modelo { get; set; }
	public virtual IEnumerable<int> Funcionarios { get; set; }
}

class ModeloData
{	
	public ModeloData(
		int qtdTrabalho, 
		int qtdFolga)
	{
		Tipo = eTipoDeFolga.Corrido;
		QtdTrabalho = qtdTrabalho;
		QtdFolga = qtdFolga;
		Dias = RetornarSemana();
		Frequencia = 100;
	}

	public ModeloData(		
		params eDiaDaSemana[] diasDaSemana)
	{
		Tipo =  eTipoDeFolga.Fixo;
		Dias = RetornarSemana(diasDaSemana);
	}

	public ModeloData(
		eTipoFrequencia tipoFrequencia,
		int frequencia,	
		params eDiaDaSemana[] diasDaSemana)
	{		
		Tipo = eTipoDeFolga.Alternada;
		TipoFrequencia = tipoFrequencia;
		Frequencia = frequencia;
		Dias = RetornarSemana(diasDaSemana);
	}

	private ModeloDiaDaSemana[] RetornarSemana(params eDiaDaSemana[] diasDaSemana)
	{
		return (diasDaSemana ?? new eDiaDaSemana[0])
			.Select(s => new ModeloDiaDaSemana
			{
				Dia = s
			})
			.ToArray();
	}

	public virtual eTipoDeFolga Tipo { get; set; }
	public virtual int? QtdTrabalho { get; set; }
	public virtual int? QtdFolga { get; set; }
	public virtual int? Frequencia { get; set; }
	public virtual eTipoFrequencia? TipoFrequencia { get; set; }
	public virtual ModeloDiaDaSemana[] Dias { get; set; }
}

class ModeloDiaDaSemana
{
	public ModeloDiaDaSemana() 
	{
		
	}
	public virtual eDiaDaSemana Dia { get; set; }
}

public enum eTipoDeFolga : byte
{
	Corrido,
	Fixo,
	Alternada
}

public enum eDiaDaSemana : byte
{
	Domingo,
	Segunda,
	Terca,
	Quarta,
	Quinta,
	Sexta,
	Sabado
}

public enum eTipoFrequencia : byte
{
	Dia,
	Mes
}

class FolgaModel
{
	public int? Qtde { get; set; }
	public int Dia { get; set; }
	public eTipoDeFolga? Tipo { get; set; }
	public int? QtdTrabalho { get; set; }
	public int? QtdFolga { get; set; }
	public eTipoFrequencia? TipoFrequencia { get; set; }
	public int? Frequencia { get; set; }
	public IEnumerable<eDiaDaSemana> Semana { get; set; }
}