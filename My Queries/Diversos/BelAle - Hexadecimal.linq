<Query Kind="Program" />

void Main()
{
	string belale = "BelAle";
	String.Concat(
		String.Join("-", belale.ToCharArray()
							.Select(s=> String.Format("{0:X}", (int)s)).Dump()).Dump()
		.Split('-')
		.Select(s=> (char)Int32.Parse(s, System.Globalization.NumberStyles.HexNumber)).Dump()).Dump()
		.ToCharArray()
		.Select(s=> Fatorial((int)s)).Dump();
	
	
	
}

static long Fatorial(int number)
{
	number.Dump();
    if (number <= 1)
    	return 1;
    else return number * Fatorial(number - 1);
}