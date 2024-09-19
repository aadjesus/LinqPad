<Query Kind="Program" />

void Main()
{
	var x1 = new[] 
	{
		new Foo("Alocada",     new TimeSpan(-11,40,45), 1), 
		new Foo("Aberta",      new TimeSpan(-11,40,42), 2), 
		new Foo("Em execução", new TimeSpan(-11,40,45), 3), 
		
		new Foo("Aberta",      new TimeSpan( 09,18,59), 4), 
		new Foo("Aberta",      new TimeSpan( 09,18,57), 5), 
		new Foo("Aberta",      new TimeSpan( 10,18,59), 6), 
		
		new Foo("Em execução", new TimeSpan( 09,18,59), 7), 
		new Foo("Alocada",     new TimeSpan( 09,18,58), 8), 
		new Foo("Alocada",     new TimeSpan( 09,18,59), 10), 
		
		new Foo("Em execução", TimeSpan.MaxValue, 11), 
		new Foo("Alocada",     TimeSpan.MaxValue, 12), 
		new Foo("Aberta",      TimeSpan.MaxValue, 12), 
	};
	
	
	x1
		.GroupBy(g => (g.TempoRestanteTmp.Ticks < 0 ? 0 : g.TempoRestanteTmp == TimeSpan.MaxValue ? 2 : 1))
		.OrderBy(o=> o.Key)
		.SelectMany(s=> (s.Key == 0 
							? s.OrderBy(o=> o.TempoRestanteTmp).ThenBy(t=> t.Status)
							: s.OrderByDescending(o=>  o.Status).ThenBy(t=> t.TempoRestanteTmp) ))		
		.Dump();
}

class Foo
{
	private const string EM_EXECUCAO = "Em execução";
	private const string ALOCADA = "Alocada";
	private const string ABERTA = "Aberta";

	public Foo(string status, TimeSpan tempoRestante, int contador)
	{
		Status = status;
		TempoRestanteTmp = tempoRestante;
		Contador = contador;
	}
	public string Status;	
	public TimeSpan TempoRestanteTmp;
	
	public string TempoRestante
	{
		get 
		{		
			string retorno = null;
            if (TempoRestanteTmp != TimeSpan.MaxValue)
                retorno = string.Format(
                    "{0:00}:{1:00}:{2:00}",
                    TempoRestanteTmp.TotalHours,
                    Math.Abs(TempoRestanteTmp.Minutes),
                    Math.Abs(TempoRestanteTmp.Seconds));

            return retorno;
		}
	}
	public int Contador;
	
}