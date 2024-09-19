<Query Kind="Program" />

void Main()
{
    // acronimo recursivo
	var alfabeto = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
	
	var nome = "";
	//for (int i = 0; i < 1; i++)
	{
		
		//nome += i.ToString() +": ";
		var letras = new List<char>();
		foreach (var element in "ALE".ToCharArray())
		{
			var x2 = ((int)element)
				.ToString().Dump()
				.ToCharArray().Dump()
				.Sum(s=> int.Parse(s.ToString()));
				
			"".Dump(element + "= "+ x2);
			
			var index = Array.IndexOf(alfabeto, element);
			letras.Add(alfabeto[index+x2]);
		}
		string.Concat(letras).Dump();
	}
	nome.Dump();
	
}

// Define other methods and classes here