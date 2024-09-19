<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\netstandard.dll</Reference>
  <Reference Relative="..\..\..\..\.nuget\packages\newtonsoft.json\13.0.1\lib\netstandard2.0\Newtonsoft.Json.dll">c:\Users\Ale\.nuget\packages\newtonsoft.json\13.0.1\lib\netstandard2.0\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
</Query>

async Task Main()
{
	var _httpClientEmail = new HttpClient();
	_httpClientEmail.DefaultRequestHeaders.Add("Authorization", "Bearer " + await RetornarToken());
	
	//    int IdConfiguration
    // string FromEmail
    // string FromDisplayName
    // string ToEmail
    // string ToDisplayName
    // string Subject
    // string Body
    //   bool HtmlBody
    //    int IdControle
	   
	var emails = new [] 
	{ 
		new 
		{
		   ToEmail = "h@h11.com",
		   Body = "aaaaa",
		   IdControle = 1
		}
	};
	
	var contentString = new StringContent(
		JsonConvert.SerializeObject(emails),
		Encoding.UTF8,
		"application/json");
	
	var responseMessage = await _httpClientEmail.PostAsync("https://praxio-email.azurewebsites.net/email/EnviarEmails", contentString);
	var readAsString = await responseMessage.Content.ReadAsStringAsync();	  
	readAsString.Dump();
	//responseMessage.Dump();
}

private async Task<string> RetornarToken()
{
    using (var httpClient = new HttpClient())
    {
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", "API_EMAIL"),
            new KeyValuePair<string, string>("scope", "API_EMAIL"),
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_secret", "secret")
           });
        var response = await httpClient.PostAsync("https://identity.globus7.com.br/Connect/token", content);
        var readAsString = await response.Content.ReadAsStringAsync();

        var token = JsonConvert.DeserializeAnonymousType(
            readAsString,
            new
            {
                access_token = string.Empty
            });

        return token.access_token;
    }
}