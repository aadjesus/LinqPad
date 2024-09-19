<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\netstandard.dll</Reference>
  <Reference Relative="..\..\..\..\.nuget\packages\newtonsoft.json\12.0.3\lib\netstandard2.0\Newtonsoft.Json.dll">c:\Users\AlessandroAugusto\.nuget\packages\newtonsoft.json\12.0.3\lib\netstandard2.0\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	using (var client = new HttpClient())
    {
		client.BaseAddress = new Uri("http://localhost:1941", UriKind.Absolute);
      	client.DefaultRequestHeaders.Accept.Clear();
      	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      	var content = new FormUrlEncodedContent(new []
      	{
        	new KeyValuePair<string, string>("client_id", "API_ARQUIVO"),
        	new KeyValuePair<string, string>("scope", "API_ARQUIVO"),
        	new KeyValuePair<string, string>("grant_type", "client_credentials"),
        	new KeyValuePair<string, string>("client_secret", "secret")
       	});	  
	  	var response = client.PostAsync("Connect/token",content).Result;	  
	  	response.Content.ReadAsStringAsync().Result.Dump();	  
   }
}