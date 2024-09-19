<Query Kind="Program" />

void Main()
{
	var x1 = "Data Source=ora11G;Persist Security Info=True;User ID=OSASCO180417;Password=OSASCO180417";
	
	Regex.Match(x1,"ID=(.*);").Groups.OfType<Group>().FirstOrDefault(f=> f.Name == "1").Value.Dump();
	Regex.Match(x1,"ID=(.+?);").Groups.Dump();
	Regex.Match(x1,"ID=(.+?);").Groups[1].Value.Dump();
	
	Regex.Match(x1, "ID=(.+?);").Groups.OfType<Group>().Last().Value.Dump();
}

// Define other methods and classes here
