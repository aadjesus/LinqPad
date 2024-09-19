<Query Kind="Program" />

void Main()
{
	var input = "a aaaa aa aaa aaaa";
	var minLength = 3;
	var pattern = string.Format(@"(?<=(^|[.!?])\s*)\w|\b\w(?=[-\w]{{0}})",minLength);
	var output = Regex.Replace(input, pattern, m => m.Value.ToUpperInvariant());
	output.Dump();
}

