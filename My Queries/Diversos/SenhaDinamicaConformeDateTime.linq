<Query Kind="Program" />

void Main()
{
	Dictionary<int,char> lista = new Dictionary<int,char>();
	lista.Add(0 ,'O');
	lista.Add(1 ,'I');
	lista.Add(2 ,'2');
	lista.Add(3 ,'3');
	lista.Add(4 ,'4');
	lista.Add(5 ,'S');
	lista.Add(6 ,'b');
	lista.Add(7 ,'T');
	lista.Add(8 ,'8');
	lista.Add(9 ,'9');	
	
	string senhaDinamica = String.Concat(
		DateTime.Now.ToString(@"ddMMyyhhmm").Dump()
			.ToCharArray()
			.Select(s=> new 
			{
				a =	lista[Convert.ToInt32(s.ToString())],
				b = s,
				c = s,
			}
			).Dump());
			
	//senhaDinamica.Dump();
	
}