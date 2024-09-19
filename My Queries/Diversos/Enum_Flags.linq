<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
</Query>

void Main()
{
	Options opcao = Options.Option0 | Options.Option3 | Options.Option2;
	
	((opcao & Options.Option0) == Options.Option0).Dump();	
	((opcao & Options.Option1) == Options.Option1).Dump();
	((opcao & Options.Option2) == Options.Option2).Dump();
	
	//(opcao | Options.Option0).Dump();
	//opcao.Dump();
	Options.Option2.HasFlag(opcao).Dump();
	
	GetFlags(opcao).Dump();	
}


static IEnumerable<Enum> GetFlags(Enum input)
{
    foreach (Enum value in Enum.GetValues(input.GetType()))
        if (input.HasFlag(value))
            yield return value;
}



[Flags]
public enum Options
{
//    Option0=0x1,
//    Option1=0x2,
//    Option2=0x4,
//	  Option3=0x8,
	
    Option0=1 << 0,
    Option1=1 << 1,
    Option2=1 << 2,
	Option3=1 << 3,

	
}