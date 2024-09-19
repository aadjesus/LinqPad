<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\netstandard.dll</Reference>
  <Reference Relative="..\..\..\..\.nuget\packages\newtonsoft.json\13.0.1\lib\netstandard2.0\Newtonsoft.Json.dll">c:\Users\Ale\.nuget\packages\newtonsoft.json\13.0.1\lib\netstandard2.0\Newtonsoft.Json.dll</Reference>
  <Reference>C:\Praxio\Praxio.Email\src\Praxio.Email.Client\bin\Debug\netstandard2.0\Praxio.Email.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Praxio.Email.Client</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var fileName = @"c:\Users\Ale\Downloads\BodyEmail.txt"; 
    var text = File.ReadAllText(fileName);	 	
	var email = Newtonsoft.Json.JsonConvert.DeserializeObject<EmailRequest>(text);
	//email.Body = "sssssssssssssssssssssssss";
	email.Dump();
	
	var emailClient = new EmailClient("http://localhost/BgmRodotec.Framework.Configuration.Api");	
	var retorno = emailClient.Gravar(email);
		
	retorno.Dump();	
}
// HttpUtility.HtmlDecode(text).Dump();
// HttpUtility.HtmlEncode(text).Dump("encode");
// var x1 = "\"aaaa\"";

//2188-route-newlist