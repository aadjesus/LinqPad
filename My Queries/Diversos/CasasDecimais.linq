<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Namespace>FGlobus.Util.ExtensaoBoolean</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	List<decimal> valores = new List<decimal>();
	valores.Add(0M);
	valores.Add(12M);
	valores.Add(12.100M);
	valores.Add(12.1234567890M);
	
	valores
		.ForEach(f=> 
		{
			(BitConverter.GetBytes( 
				Decimal.GetBits(f)
					.LastOrDefault())
				.Max())
			.Dump();
		});		
}

