<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Namespace>FGlobus.Util</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	"1".All(Char.IsDigit).Dump();	
	"1234a".All(Char.IsDigit).Dump();
	
	TypeCode typeCode = Type.GetTypeCode(typeof(int));

  	((int)typeCode).Entre(5,15).Dump();
  	((int)typeCode >= 5 && (int)typeCode <= 15).Dump();
}

// Define other methods and classes here