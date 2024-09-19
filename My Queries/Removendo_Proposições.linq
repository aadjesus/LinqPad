<Query Kind="Program">
  <Connection>
    <ID>0b5557e8-cf68-43ee-8976-2f98bfe36d94</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.Oracle</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA2+AkM5+tpU6rM+x3ArBg/wAAAAACAAAAAAADZgAAwAAAABAAAACScvCQgwiANAqCHl5oBqlWAAAAAASAAACgAAAAEAAAAO4BYrvSeW6l8yyKQ65KwV9AAAAAs2/UiPa+M8nrO51FTHmFU2pLOTGq/nTtPTwxOpS/kdgbYTTd2lhmh3kjR0q5I4PHq3UMmUkiHdZmPqCPMUlQghQAAACPmOdWFJ0L/cWFt95nFTZC6fZL4w==</CustomCxString>
    <Server>ora11g64</Server>
    <UserName>escalatesteale</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA2+AkM5+tpU6rM+x3ArBg/wAAAAACAAAAAAADZgAAwAAAABAAAAAkCWFg/rmraFaQLFooEYVsAAAAAASAAACgAAAAEAAAAB+LglqBBqsZLV9KTQ/vaMYQAAAAU5ZPUozr9SwdqFJCEN9t6hQAAADOTGGvo903j+4DnEuRSLwKx1AOrg==</Password>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>true</StripUnderscores>
      <QuietenAllCaps>true</QuietenAllCaps>
      <ConnectAs>Default</ConnectAs>
      <UseOciMode>true</UseOciMode>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	string texto = "aaaaaaaaaa de kkkkkk a iiii ";
	int tamanho = 3;
    var retorno = Regex.Split(texto.ToLower(), @"\W+").Dump()
        .Where(s => s.Length > tamanho )
		.Take(tamanho);
	retorno.Dump();
	
}

// Define other methods and classes here
