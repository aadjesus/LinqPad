<Query Kind="Program">
  <Reference>C:\Praxio\PortalDoCliente\Main\Source\MyTicket\packages\Newtonsoft.Json.6.0.8\lib\net40\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

async Task Main()
{
	var login = await Post<LoginResponse>(
		"login",
		new LoginRequest("Praxio@Portal","Prx@2024")); 	
	login.Dump();
	
	
}

private async Task<TResult> Post<TResult>(string rota, object objeto)
{
	using (var httpClient = new HttpClient())
    {
		httpClient.BaseAddress = new Uri("http://172.16.0.9:5000/");
		
	    var post = await httpClient.PostAsync(
	        rota,
	        new StringContent(
	            JsonConvert.SerializeObject(
	                objeto,
	                new JsonSerializerSettings
	                {
	                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
	                    NullValueHandling = NullValueHandling.Ignore,
	                }),
	            System.Text.Encoding.UTF8,
	            "application/json"));

	    if (post.StatusCode != System.Net.HttpStatusCode.Created)
	        return default(TResult);

	    var retorno = await post.Content.ReadAsStringAsync();

	    return JsonConvert.DeserializeObject<TResult>(retorno);
	}
}

public class LoginRequest
{
	public LoginRequest(string usuario, string senha)
	{
		Usuario = usuario;
        Senha = senha;
	}
	
	[JsonProperty("nome")]
	public string Usuario { get; private set; }

	[JsonProperty("password")]
	public string Senha { get; private set; }
}

public class LoginResponse
{
    [JsonProperty("access_token")]
    public string Token { get; set; }

    public override string ToString()
    {
        return Token;
    }
}

public class PerguntaResponse
{
    public string Resposta { get; set; }
    public string Referencias { get; set; }
}

public class PerguntaRequest
{

    public string Usuario { get; private set; }
    public int Ticket { get; private set; }
    public string Cliente { get; private set; }
    public string Sistema { get; private set; }
    public string Modulo { get; private set; }
    public string Pergunta { get; private set; }
}