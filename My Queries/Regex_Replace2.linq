<Query Kind="Program" />

void Main()
{
	var x1 = "AA,BB,sssss";
	var x2 = "aa,";
	
	x1.LastIndexOf(',',4 ).Dump();
	
	Regex regex = new Regex("^([A-Z]+)([^A-Z])?$");
	
	regex.Replace(x1, "$1").Dump();
	
	
	
	var xx1 = aaa(x1);
	var xx2 = aaa(x2);
	
	xx1.Intersect(xx2).Dump().Any().Dump();
}

IEnumerable<string> aaa(string a) 
{
	return a.Split(',').Where(w => !string.IsNullOrEmpty(w));
}