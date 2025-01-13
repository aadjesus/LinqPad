<Query Kind="Program">
  <Reference Relative="..\..\..\.nuget\packages\newtonsoft.json\13.0.3\lib\netstandard2.0\Newtonsoft.Json.dll">C:\Users\alessandro.augusto\.nuget\packages\newtonsoft.json\13.0.3\lib\netstandard2.0\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\netstandard.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	Converter<EstornoRecebimentoJuroResponse>("{'success': true, 'code': 200,  'result': {'mensagem': 'Amortização(s) realizada(s) com sucesso.',    'amortizacoes': 10001  }}");
	Converter<EstornoRecebimentoJuroResponse>("{'success': true, 'code': 200,  'result': {'mensagem': 'Desconto(s) estonado(s) com sucesso.',    'desconto_id': 10001  }}");
	Converter<EstornoRecebimentoJuroResponse>("{'success': true, 'code': 200,  'result': {'mensagem': 'Juro(s) estornado(s) com sucesso.',    'juro_id': 10001  }}");
	Converter<AlterarRecebimentoResponse>("{ 'success': true,  'code': 200,  'result': { 'success': 'true'  } }");
}

public static void Converter<TResult>(string json) where TResult : RetornoResponse
{
	try
    {
		var retorno = JsonConvert.DeserializeObject<BaseResponse<TResult>>(json);	
		retorno.Dump();
	}
	catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }	
}


	public class EstornoRecebimentoJuroResponse : RetornoResponse
    {
        [JsonProperty("amortizacoes")]
        public int IdAmortizacoes
        {
            set
            {
                AddIdApi(0, value);
            }
        }

        [JsonProperty("desconto_id")]
        public int IdDesconto
        {
            set
            {
                AddIdApi(0, value);
            }
        }

        [JsonProperty("juro_id")]
        public int IdAcrescimo
        {
            set
            {
                AddIdApi(0, value);
            }
        }
    }

    public class AlterarRecebimentoResponse : RetornoResponse
    {
        [JsonProperty("success")]
        public bool SucessoAPI
        {
            set
            {
				if (value)
					AddIdApi(0, 0);
				else                
					AddIdApi(0, null);
            }
        }
    }
	
	public class RetornoResponse
    {
        public RetornoResponse()
        {
            ListaIdApi = new Dictionary<int?, int?>();
        }

        public Dictionary<int?, int?> ListaIdApi { get; set; }

        public void AddIdApi(int? tipo, object idApi)
        {
			int outIdApi;
            if (!int.TryParse((idApi ?? string.Empty).ToString(), out outIdApi))
                return;

			if (!ListaIdApi.ContainsKey(tipo))
				ListaIdApi.Add(tipo, outIdApi);
        }

        public bool Sucesso 
		{ 
			get 
			{ 			
				return ListaIdApi != null && ListaIdApi.Count() > 0;
			}
		}

        public string IdIntegracao { get; set; }
    }

	public class BaseResponse<TResult> where TResult : RetornoResponse
    {
        public BaseResponse() { }

        public BaseResponse(string readAsString) { }

        [JsonProperty("result")]
        public TResult Retorno { get; set; }
    }

