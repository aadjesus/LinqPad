<Query Kind="Program" />

void Main()
{	
	Func<string,string,int> funcMinutos = 
	(ini,fin)=>
	{
		var dataIni = DateTime.Now.Date.Add(TimeSpan.Parse(ini));
		var dataFin = DateTime.Now.Date.Add(TimeSpan.Parse(fin));
		if (dataFin < dataIni)
			dataIni = dataIni.AddDays(1).Dump();		
		
		return dataIni.Hour * 60 + dataIni.Minute;		
	};
	
	Func<string,int> funcMinutos1 = 
	(ini)=>
	{
		var dataIni = DateTime.Now.Date.Add(TimeSpan.Parse(ini));		
		return dataIni.Hour * 60 + dataIni.Minute;
		
	};
	
	var lista2 = new List<Foo1>();
	lista2.Add(new Foo1{ Id=1, Ini = 00, Fin = 15 , DataIni = "00:01", DataFin = "15:43" });
	lista2.Add(new Foo1{ Id=2, Ini = 00, Fin = 16 , DataIni = "00:01", DataFin = "16:43" });
	lista2.Add(new Foo1{ Id=3, Ini = 16, Fin = 18 , DataIni = "16:47", DataFin = "18:43" });
	lista2.Add(new Foo1{ Id=4, Ini = 19, Fin = 20 , DataIni = "19:14", DataFin = "20:43" });
	lista2.Add(new Foo1{ Id=5, Ini = 21, Fin = 23 , DataIni = "21:10", DataFin = "23:43" });
	lista2.Add(new Foo1{ Id=6, Ini = 00, Fin = 02 , DataIni = "00:01", DataFin = "02:43" });
	lista2.Add(new Foo1{ Id=7, Ini = 00, Fin = 17 , DataIni = "00:01", DataFin = "17:43" });
	lista2.Add(new Foo1{ Id=8, Ini = 09, Fin = 20 , DataIni = "09:07", DataFin = "20:43" });	
	lista2.Add(new Foo1{ Id=8, Ini = 09, Fin = 20 , DataIni = "22:00", DataFin = "02:43" });
	
	var itemDataIni = "16:47".Dump();
	var itemDataFin = "20:43".Dump();
	
	
	//lista2
	//	.Where(w=> 				   
	//			   !lista2.Any(a => a.Id == w.Id && 
	//			   					(a.Ini >= item.Ini && a.Ini <= item.Fin  ||	
	//				  		         a.Fin >= item.Ini && a.Fin <= item.Fin) ))		;	
	
	lista2
		.Dump()
		.Where(w=> 
					lista2
						.Any(a => a.Id == w.Id && 									
						
				   				  (funcMinutos1(itemDataIni) < funcMinutos1(a.DataFin) && 
								   funcMinutos1(itemDataFin) > funcMinutos1(a.DataIni)  
								   )))
	.Dump();

	

}

class Foo1
{
	public int Id {get;set;}
	public int Ini {get;set;}
	public int Fin {get;set;}
	public string DataIni {get;set;}
	public string DataFin {get;set;}
	
}