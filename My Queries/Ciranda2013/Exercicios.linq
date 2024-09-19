<Query Kind="Program" />

void Main()
{
	Environment.UserName.Select(s=> s).Dump("3.a");
	Environment.UserName.Select((s, index)=> (char)(s+index)).Dump("3.b");	
	Environment.UserName
		.SelectMany(s=> Environment.MachineName ,(a,b) => new{a,b}).Dump("3.c");
		
	Environment.UserName.Where(w=> w =='a' || w =='e' || w =='i'|| w =='o'|| w =='u').Dump("4.a");
	Environment.UserName.Where((w,index) =>  (index % 2) == 1).Dump("4.b");
	Environment.UserName
		.Where(s=> Environment.MachineName.Contains(s)).Dump("4.c");
		
	Environment.UserName.OrderBy(o => o).Dump("5.a");
	Environment.UserName.OrderByDescending(o => o).Dump("5.b");
	Environment.UserName.Reverse().Dump("5.c");
	
	
	//---------- Na pratica
	
	

}

public enum eTeste
{
	A,
	B,
	C	
}