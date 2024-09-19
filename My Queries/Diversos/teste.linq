<Query Kind="Program" />

void Main()
{
	long minu = 4000;
	string dataHota = "30/01/2015 14:10";
	
	dataHota.Dump("Atual");
	AlterarData(dataHota,'+', minu).Dump("Resultado");
	Convert.ToDateTime(dataHota).AddMinutes(minu).ToString("dd/MM/yyyy HH:mm").Dump("Prova real");
}

public static string AlterarData(string dataHora, char operacao, long valor)
{
	string[] listaDataHora = dataHora.Split('/',' ',':');
	
	int dia = Convert.ToInt32(listaDataHora[0]);
	int mes = Convert.ToInt32(listaDataHora[1]);
	int ano = Convert.ToInt32(listaDataHora[2]);
	
	int hora = Convert.ToInt32(listaDataHora[3]);
	int minu = Convert.ToInt32(listaDataHora[4]);	

 	int[] mes31 = new int[] { 1, 3, 5, 7, 8, 10, 12 };
    int[] mes30 = new int[] { 4, 6, 9, 11 };
	
	for (int i = 1; i <= valor; i++)
	{
		++minu;
		if (minu==60)
		{
			minu = 0;
			++hora;	
		}
		
		if (hora==24)
		{
			minu = 0;
			hora = 0;	
			++dia;
		}
		
		bool somaMes = false;
		if (mes31.Contains(mes))
			somaMes = dia == 32;
		else if (mes31.Contains(mes))
			somaMes = dia == 31;
		else
			somaMes = dia == 29;
				
		if (somaMes)
		{
			++mes;
			dia=1;	
			if (mes == 13)
			{
				++ano;
				mes = 1;
			}
		}		
	}
	
	return String.Concat(
		dia.ToString("00"),'/',
		mes.ToString("00"),'/',
		ano.ToString("00"),' ',
		hora.ToString("00"),':',
		minu.ToString("00"));
}