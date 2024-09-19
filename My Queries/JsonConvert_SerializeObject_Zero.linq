<Query Kind="Program">
  <NuGetReference>nest-factory</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	//var test = JsonConvert.DeserializeObject<Test>("{\"IntValue\":null}");
	//Console.WriteLine("IntValue:{0}", test.IntValue);
	
	var x1 = new FuncionarioVO
	{
	 Id = 2,
	 Matricula = "aaa"
	};
	
	JsonConvert.SerializeObject(x1).Dump();
		
}

		public class FuncionarioVO
        {            
        
//            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
//            [DefaultValue(1)]
			[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        	[Nest.Number(NullValue = 0)]
            public int? OSId { get; set;}

			[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Situacao { get; set; }

			[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        	[Nest.Number(NullValue = 2)]			
            public int? Id { get; set; }
			
			[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Matricula { get; set; }
			
			[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Nome { get; set; }
        }
