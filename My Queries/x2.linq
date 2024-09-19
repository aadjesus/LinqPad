<Query Kind="Program" />

void Main()
{
	Foo.Lista.GroupBy(g=> new {g.Id, g.S})
		.Select(s=> new 
		{
			s.Key.Id,
			s.Key.S,
			TotalMinutes = s.Sum(s2 => s2.HoraFin.Subtract(s2.HoraIni).TotalMinutes)
		})
		.Select(s=> new 
		{
			s.Id,
			s.S,
			H =  s.TotalMinutes <= 0
				? 0
				: Math.Round( (s.TotalMinutes - (5 * 75)) / 60)
		})
		.Dump();
}

class Foo
{
	public string Id {get;set;}
	public int S {get;set;}
	public TimeSpan HoraIni {get;set;}
	public TimeSpan HoraFin {get;set;}
	
	public static List<Foo> Lista {
	get
	{
		var lista = new List<Foo>()
		{	
			new Foo{ Id = "O", S = 1, HoraIni = new TimeSpan(10,15,0),  HoraFin = new TimeSpan(18,20,00)},
			new Foo{ Id = "O", S = 1, HoraIni = new TimeSpan(10,10,0),  HoraFin = new TimeSpan(17,40,00)},
			new Foo{ Id = "O", S = 1, HoraIni = new TimeSpan(10,20,0),  HoraFin = new TimeSpan(18,00,00)},
			new Foo{ Id = "O", S = 1, HoraIni = new TimeSpan(10,30,0),  HoraFin = new TimeSpan(18,00,00)},
			new Foo{ Id = "O", S = 1, HoraIni = new TimeSpan(00,00,0),  HoraFin = new TimeSpan(00,00,00)},
			
			new Foo{ Id = "O", S = 2, HoraIni = new TimeSpan(10,30,0),  HoraFin = new TimeSpan(18,20,00)},
			new Foo{ Id = "O", S = 2, HoraIni = new TimeSpan(11,00,0),  HoraFin = new TimeSpan(17,40,00)},
			new Foo{ Id = "O", S = 2, HoraIni = new TimeSpan(00,00,0),  HoraFin = new TimeSpan(00,00,00)},
			new Foo{ Id = "O", S = 2, HoraIni = new TimeSpan(10,30,0),  HoraFin = new TimeSpan(18,05,00)},
			new Foo{ Id = "O", S = 2, HoraIni = new TimeSpan(00,00,0),  HoraFin = new TimeSpan(00,00,00)},		
			
			new Foo{ Id = "O", S = 3, HoraIni = new TimeSpan(00,00,0),  HoraFin = new TimeSpan(00,00,00)},
	     	new Foo{ Id = "O", S = 3, HoraIni = new TimeSpan(00,00,0),  HoraFin = new TimeSpan(00,00,00)},
			new Foo{ Id = "O", S = 3, HoraIni = new TimeSpan(08,40,0),  HoraFin = new TimeSpan(17,50,00)},
			new Foo{ Id = "O", S = 3, HoraIni = new TimeSpan(09,40,0),  HoraFin = new TimeSpan(18,00,00)},
			new Foo{ Id = "O", S = 3, HoraIni = new TimeSpan(09,40,0),  HoraFin = new TimeSpan(18,00,00)},
			
			new Foo{ Id = "N", S = 1, HoraIni = new TimeSpan(10,20,0),  HoraFin = new TimeSpan(18,00,00)},
			new Foo{ Id = "N", S = 1, HoraIni = new TimeSpan(09,25,0),  HoraFin = new TimeSpan(18,25,00)},
			new Foo{ Id = "N", S = 1, HoraIni = new TimeSpan(09,20,0),  HoraFin = new TimeSpan(18,10,00)},
			new Foo{ Id = "N", S = 1, HoraIni = new TimeSpan(10,15,0),  HoraFin = new TimeSpan(18,00,00)},
			new Foo{ Id = "N", S = 1, HoraIni = new TimeSpan(09,40,0),  HoraFin = new TimeSpan(18,30,00)},
			
			new Foo{ Id = "N", S = 2, HoraIni = new TimeSpan(10,20,0),  HoraFin = new TimeSpan(18,00,00)},
			new Foo{ Id = "N", S = 2, HoraIni = new TimeSpan(09,25,0),  HoraFin = new TimeSpan(18,00,00)},
			new Foo{ Id = "N", S = 2, HoraIni = new TimeSpan(09,20,0),  HoraFin = new TimeSpan(18,20,00)},
			new Foo{ Id = "N", S = 2, HoraIni = new TimeSpan(10,15,0),  HoraFin = new TimeSpan(18,05,00)},
			new Foo{ Id = "N", S = 2, HoraIni = new TimeSpan(09,40,0),  HoraFin = new TimeSpan(18,00,00)},		
			
			new Foo{ Id = "N", S = 3, HoraIni = new TimeSpan(10,40,0),  HoraFin = new TimeSpan(18,00,00)},
	     	new Foo{ Id = "N", S = 3, HoraIni = new TimeSpan(11,10,0),  HoraFin = new TimeSpan(18,00,00)},
			new Foo{ Id = "N", S = 3, HoraIni = new TimeSpan(09,30,0),  HoraFin = new TimeSpan(17,50,00)},
			new Foo{ Id = "N", S = 3, HoraIni = new TimeSpan(10,40,0),  HoraFin = new TimeSpan(18,00,00)},
			new Foo{ Id = "N", S = 3, HoraIni = new TimeSpan(10,00,0),  HoraFin = new TimeSpan(18,00,00)},			
		};
		
		return lista;
	}}
	
}