<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\netstandard.dll</Reference>
  <Reference Relative="..\..\..\..\.nuget\packages\newtonsoft.json\13.0.1\lib\netstandard2.0\Newtonsoft.Json.dll">c:\Users\Alessandro.Augusto\.nuget\packages\newtonsoft.json\13.0.1\lib\netstandard2.0\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
</Query>

async Task Main()
{
	var emailClient = new EmailClient("http://localhost/BgmRodotec.Framework.Configuration.Api");
	
	var retorno = emailClient.Gravar(
		new EmailRequest() { Body = "aaaaaaaa"});
		
	retorno.Dump();
}

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	public class EmailClient
    
    {
        protected readonly HttpClient _httpClientConfiguration;
        protected readonly string _urlApiConfiguration;
        protected HttpClient _httpClientEmail;
        protected HttpClient _httpClientAuthority;
        protected string _urlAuthority;
        protected string _urlEmail;


        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="urlApiConfiguration">Url da API de configuração</param>
        public EmailClient(
            string urlApiConfiguration)
        {
			Uri outUri = null;
            if (Uri.TryCreate(urlApiConfiguration, UriKind.Absolute, out outUri))
                _httpClientConfiguration = new HttpClient
                {
                   // BaseAddress = outUri
                };
            else
                throw new Exception("Url de configuração invalida: {_urlApiConfiguration}");

            _urlApiConfiguration = urlApiConfiguration;
        }


        /// <summary>
        /// Grava os e-mail's enviados na lista
        /// </summary>
        /// <param name="emails">Lista ou um</param>
        /// <returns><see cref="RetornoResponse"/></returns>
        public async Task<RetornoResponse> Gravar(params EmailRequest[] emails)
        {
		//if (!(emails?.Any() ?? false))
				//return HttpStatusCode.NotFound;
			
			_httpClientAuthority = RetornarHttpClient("AUTHORITY_URL");
			_httpClientEmail = RetornarHttpClient("API_EMAIL_URL") ;
			RetornarHttpClient("ENVIRONMENT").Dump();

            if (_httpClientEmail.DefaultRequestHeaders.FirstOrDefault().Key == null)
                await PopularToken();

            var estagio = string.Empty;
            try
            {
                estagio = "Serializando objeto;";
                var contentString = new StringContent(
                    JsonConvert.SerializeObject(emails),
                    Encoding.UTF8,
                    "application/json");

                estagio = "Enviando objeto;";
				_httpClientEmail.BaseAddress.Dump("a");
                var responseMessage = await _httpClientEmail.PostAsync("Email/EnviarEmails", contentString);

                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    estagio = "Lendo retorno;";
                    var readAsString = await responseMessage.Content.ReadAsStringAsync();

                    estagio = "Deserializando retorno;";
                    var retorno = JsonConvert.DeserializeObject<RetornoResponse>(readAsString);
                    retorno.StatusCode = responseMessage.StatusCode;

                    return retorno;
                }
                else
                    return responseMessage.StatusCode;
            }
            catch (Exception ex)
            {
                return new Exception(estagio, ex);
            }
        }

         private HttpClient RetornarHttpClient(string parametro)
        {
            try
            {
                var url = _httpClientConfiguration
                    .GetStringAsync(_urlApiConfiguration+"/Api/Config/"+parametro)
                    .Result;

				url.Dump("URL");
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(url), 
                };

                return httpClient;
            }
            catch (Exception ex)
            {
				ex.Dump();
                return null;
            }

        }

        private async Task PopularToken()
        {
            _httpClientAuthority.DefaultRequestHeaders.Accept.Clear();
            _httpClientAuthority.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("client_id", "API_EMAIL"),
                    new KeyValuePair<string, string>("scope", "API_EMAIL"),
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_secret", "secret")
                   });
            var response = await _httpClientAuthority.PostAsync("Connect/token", content);
            var readAsString = await response.Content.ReadAsStringAsync();

            var token = JsonConvert.DeserializeAnonymousType(
                readAsString,
                new
                {
                    access_token = string.Empty
                });
			
			token.access_token.Dump();
            _httpClientEmail.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);
        }
    }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Objeto com os atributos para gravar o email
    /// </summary>
    public partial class EmailRequest
    {
        /// <summary>
        /// Configuração do servidor de e-mail
        /// </summary>
        public virtual int IdConfiguration { get; set; }

        /// <summary>
        /// Email de origem
        /// </summary>
        /// <example>EmailDeOrigem@praxio.com.br</example>
        public virtual string FromEmail { get; set; }

        /// <summary>
        /// Descrição da origem
        /// </summary>
        /// <example>Descrição da origem</example>
        public virtual string FromDisplayName { get; set; }

        /// <summary>
        /// Email de destino
        /// </summary>
        /// <example>EmailDeDestino@praxio.com.br</example>
        public virtual string ToEmail { get; set; }

        /// <summary>
        /// Descrição da destino
        /// </summary>
        /// <example>Descrição da destino</example>
        public virtual string ToDisplayName { get; set; }

        /// <summary>
        /// Titulo do e-mail
        /// </summary>
        /// <example>Titulo</example>
        public virtual string Subject { get; set; }

        /// <summary>
        /// Corpo do e-mail
        /// </summary>
        /// <example>Documentação do e-mail</example>
        public virtual string Body { get; set; }

        /// <summary>
        /// Se o corpo do email é um HTML
        /// </summary>
        /// <example>false</example>
        public virtual bool HtmlBody { get; set; }

        /// <summary>
        /// Id externo
        /// </summary>
        /// <example>1</example>
        public virtual int IdControle { get; set; }
    } 
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   /// <summary>
    /// Objeto com os atributos de retorno
    /// </summary>
    public class RetornoResponse
    {
        /// <summary/>
        public RetornoResponse() { }

        /// <summary/>
        public RetornoResponse(HttpStatusCode statusCode)
        {
            Sucesso = statusCode == HttpStatusCode.OK;
			StatusCode = statusCode;
        }

        /// <summary/>
        public RetornoResponse(Exception ex)
        {
            Erro = ex.ToString();
            StatusCode = HttpStatusCode.InternalServerError;
        }

        /// <summary>
        /// Lista com os Id gerados
        /// </summary>
        public int[] Dados { get; set; }

        /// <summary>
        /// Sucesso
        /// </summary>
        public bool Sucesso
        {
            get { return StatusCode == HttpStatusCode.OK; }
            private set { }
        }

        /// <summary>
        /// Exceção
        /// </summary>
        public string Erro { get; private set; }

        /// <summary>
        /// Código <see cref="HttpStatusCode"/> da ação executada
        /// </summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary/>
        public static implicit operator RetornoResponse(HttpStatusCode statusCode) { return new RetornoResponse(statusCode);}

        /// <summary/>
        public static implicit operator RetornoResponse(Exception ex) {return new RetornoResponse(ex);}
    }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------