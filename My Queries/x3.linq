<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\netstandard.dll</Reference>
  <Reference Relative="..\..\..\..\.nuget\packages\newtonsoft.json\13.0.1\lib\netstandard2.0\Newtonsoft.Json.dll">C:\Users\AlessandroAugusto\.nuget\packages\newtonsoft.json\13.0.1\lib\netstandard2.0\Newtonsoft.Json.dll</Reference>
</Query>



void Main()
{
	JToken expected = JToken.Parse(@"{ ""Name"": ""20181004164456"", ""objectId"": ""4ea9b00b-d601-44af-a990-3034af18fdb1%>"" }");
    JToken actual = JToken.Parse(@"{ ""Name"": ""AAAAAAAAAAAA"", ""objectId"": ""4ea9b00b-d601-44af-a990-3034af18fdb1%>"" }");

    actual.Should().BeEquivalentTo(expected);
}

// Define other methods and classes here
