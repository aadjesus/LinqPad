<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	RunAsync().Wait();	
}

static async Task RunAsync()
{
	using (var client = new System.Net.Http.HttpClient())
	{
	    client.BaseAddress = new Uri("http://localhost/MyTicket/");
	    client.DefaultRequestHeaders.Accept.Clear();
	    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		
		HttpResponseMessage response =  await client.GetAsync("api/ApiNotificacao?token=alessandro.augusto@bgmrodotec.com.br;aaaäãâá");
    	//if (response.IsSuccessStatusCode)
    	{		
        	var product = await response.Content.ReadAsStringAsync();
			var dados = JsonConvert.DeserializeObject<List<NotificacaoMlo>>(product.Dump());    
			
        	dados.Dump();
    	}
	}
}

public class NotificacaoMlo 
{
	public virtual int Id { get; set; }
	public virtual string Descricao { get; set; }
	public virtual TicketMlo Ticket { get; set; }	
	public virtual int TicketId { get; set; }	
	public virtual string Protocolo { get; set; }	
}

public class TicketMlo
{
	public virtual int Id { get; set; }
	public virtual string Protocolo { get; set; }
}