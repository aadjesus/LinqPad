<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Namespace>FGlobus.Util.ExtensaoLinq</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{	
	DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
    Calendar cal = dfi.Calendar;

	DateTime data = new DateTime(2013,10,10);
	int numeroSemana = 0;
	Enumerable.Range(data.Day, DateTime.Now.Subtract(data).Days + 1)
        .Select((s, index) => data.AddDays(index))
        .GroupBy(g => g.Year)
        .ForEach(itemAno =>
        {
			string ano = String.Concat(new string(' ',0),"Ano",'-', itemAno.Key);
			ano.Dump();
			
            itemAno
				.GroupBy(g => g.Month)
            	.ForEach(itemMes =>
	            {
					string mes = String.Concat(new string(' ',3), "Mes",'-', itemMes.Key);
					mes.Dump();
					
	                itemMes
						.GroupBy(g => cal.GetWeekOfYear(g, dfi.CalendarWeekRule, dfi.FirstDayOfWeek))						
	                	.ForEach(itemSemana =>
						{
							string semana = String.Concat(new string(' ',6),"Semana",'-', ++numeroSemana);
							semana.Dump();
							
							itemSemana
								.ForEach(itemDia =>
								{
									string dia = String.Concat(new string(' ',9),"Dia",'-', itemDia.Day);
									dia.Dump();
								});	// ...ForEach(itemDia =>
						}); // ...ForEach(itemSemana =>
	            }); // ...ForEach(itemMes =>
        }); // ...ForEach(itemAno =>
}