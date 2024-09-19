<Query Kind="Program">
  <Output>DataGrids</Output>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>System.Web.Services.Protocols</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{

    string a = new String(' ', 8);
    string b = String.Concat('|', new String(' ', 6),'|') ;
	
    List<Hand> lista = new List<Hand>();
    lista.Add(new Hand() { Finger = "", MiddleFinger = "+----+", Thumb = "" });
    lista.AddRange(Enumerable.Repeat(new Hand() { Finger = "", MiddleFinger = b, Thumb = "" }, 4).ToArray());
    lista.Add(new Hand() { Finger = "+----+", MiddleFinger = b, Thumb = "" });
    lista.AddRange(Enumerable.Repeat(new Hand() { Finger = b, MiddleFinger = b, Thumb = "" }, 3).ToArray());
    lista.Add(new Hand() { Finger = @"/       \", MiddleFinger = @"/      \", Thumb = String.Concat('+', new String('-', 21)) });
    lista.Add(new Hand() { Finger = a, MiddleFinger = a, Thumb = "|"});
    lista.Add(new Hand() { Finger = a, MiddleFinger = a, Thumb = String.Concat('+', new String('-', 15),'\\') });
    
	lista.AddRange(Enumerable.Range(1,5)
			.Select(s=> new Hand() { Finger = a, MiddleFinger = a, Thumb = String.Concat(new String(' ', 23+s),'|')}  )
			.ToArray());
	
	lista.Select((s,index)=> new 
		{
			T = s.Thumb, 
			F = s.Finger, 
			M = s.MiddleFinger, 
			R = s.Finger, 
			L = s.Finger,
			x = index > 9 ?"|" : ""
		}).Dump();
}



public struct Hand
{
	public string Thumb;
	public string Finger;
	public string Forefinger;
	public string MiddleFinger;
	public string Ring;
	public string LittleFinger;
}

public enum eTypeFinger
{
	Thumb,
	Forefinger,
	MiddleFinger,
	Ring,
	LittleFinger,
}