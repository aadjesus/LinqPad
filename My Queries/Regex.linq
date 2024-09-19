<Query Kind="Program" />

void Main()
{
	string texto = "BGM[SSSSSSSSSS+SSSSSSSSSSAS+SSSSSS1]";
	
	string pattern = @"BGM\[(.*?)\]";		
	pattern =  @"(BGM\[(.*?)\])([A])";
	//pattern =  @"(?>(\w)\1+)A\b";
					   
	var regex =  Regex.Match(texto, pattern);		
	regex.Groups.Dump();		
	
	
	
}

// Define other methods and classes here