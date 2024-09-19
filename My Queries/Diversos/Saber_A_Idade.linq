<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	Dictionary<string,DateTime> dictionary = new Dictionary<string,DateTime>();
	dictionary.Add("Eu         ",new DateTime(1977,06,24));
	dictionary.Add("*BGM       ",new DateTime(1995,06,22)); 
	dictionary.Add("*BGMRodotec",new DateTime(2004,01,02)); 
	dictionary.Add("*Praxio    ",new DateTime(2018,07,01));
	dictionary.Add("*Praxio2   ",new DateTime(2020,06,08));
	dictionary.Add("Xande      ",new DateTime(1977,06,24));
	dictionary.Add("Bel        ",new DateTime(1975,02,08));
	dictionary.Add("João Paulo ",new DateTime(1997,09,25));
	dictionary.Add("Nicollas   ",new DateTime(2003,06,15));
	dictionary.Add("Kamila     ",new DateTime(1996,01,09));
	dictionary.Add("Danda      ",new DateTime(1980,07,30));
	dictionary.Add("Mãe        ",new DateTime(1953,12,20));
	dictionary.Add("BelAle     ",new DateTime(2008,09,20));
	dictionary.Add("Joaquin    ",new DateTime(2015,06,21));
	dictionary.Add("Bernado    ",new DateTime(2018,12,25));
	
	Func<DateTime,Tuple<int,bool>> funcDias =
		data =>
		{
			DateTime atual = DateTime.Now;
			//atual = new DateTime(2015,9,26);
			int dias = new DateTime(atual.Year ,data.Month,data.Day).Subtract( atual ).Days;
			
			bool anoQueVem =dias < 0;
			if (anoQueVem)
				dias = new DateTime(atual.Year+1,data.Month,data.Day).Subtract( atual ).Days;
			
			return Tuple.Create(dias,anoQueVem);
		};	

	dictionary
		.OrderBy(o=> o.Value)
		.Select(s=> new 
		{
			Nome = s.Key,
			Data = s.Value.ToString("dd/MM/yyyy"),
			Idade = DateTime.Now.Date.Year - s.Value.Date.Year
		})
		.Dump()
		.Select(s=> new 
		{
	  		s.Nome,			
		    Idade = DateTime.Now.Year - Convert.ToDateTime(s.Data).Year,
			DiasAno =  funcDias(Convert.ToDateTime(s.Data))
	  	})
		.OrderBy(o=> o.DiasAno.Item1)
		.GroupBy(g=> g.DiasAno.Item2 
						? "Ano que vem" 
						: "Esse ano", (chave,list) => new
		{
			chave, 
			Lista = list
				.Select(s=> new 
				{
					s.Nome,
					Idade = s.Idade + (chave == "Ano que vem"? 1 : 0),
					Dias = s.DiasAno.Item1
				})
				.ToArray()
		})
		.Dump();
}