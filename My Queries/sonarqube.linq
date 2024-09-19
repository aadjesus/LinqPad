<Query Kind="Program">
  <Reference Relative="..\..\..\..\.nuget\packages\newtonsoft.json\13.0.1\lib\net20\Newtonsoft.Json.dll">C:\Users\alessandro.augusto\.nuget\packages\newtonsoft.json\13.0.1\lib\net20\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

async Task Main()
{
	var token   = "sqa_31d0da34e60b5a9fe4991c3b100a118327f25c28";
	var projeto = "Plantao.Web.UI";
	var servidor= "http://179.191.123.126:9000";
	var url     = servidor + "/api/qualitygates/project_status";
	

	using (var httpClient = new HttpClient())
    {
		httpClient.BaseAddress = new Uri(url);
		httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
		
		var response = await httpClient.GetAsync("?projectKey=" + projeto);		
		var retorno = await response.Content.ReadAsStringAsync();
		httpClient.BaseAddress.Dump();
		
		//[![Quality Gate Status](http://179.191.123.126:9000/api/project_badges/measure?project=Plantao.Web.API&metric=alert_status&token=sqb_22bb9f479bd9353f55bd700b7c437eab603775d7)](http://172.16.0.16:9000/dashboard?id=Plantao.Web.API)		
		//http://172.16.0.16:9000/api/measures/component?componentKey={your_project_key}&metricKeys=ncloc
		
		JsonConvert.DeserializeAnonymousType(
			retorno.Dump(),
			new 
			{	
				projectStatus = new {
					status = default(string),
					ignoredConditions = default(bool)
				}				
			})
			.projectStatus.Dump();			
	}
	
	using (var httpClient = new HttpClient())
    {
		httpClient.BaseAddress = new Uri(servidor + "/api/measures/component");
		httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);		
		var response2 = await httpClient.GetAsync("?component=" + projeto + "&metricKeys=ncloc");		
		var retorno2 = await response2.Content.ReadAsStringAsync();			
		retorno2.Dump("a");
	}
	
	using (var httpClient = new HttpClient())
    {
		httpClient.BaseAddress = new Uri(servidor );
		httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);		
		var response2 = await httpClient.GetAsync("/api/qualitygates/show?name=Sonar way - Not Coverage");		
		var retorno2 = await response2.Content.ReadAsStringAsync();			
		retorno2.Dump("b");

	}
}