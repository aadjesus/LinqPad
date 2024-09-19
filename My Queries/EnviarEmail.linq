<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Framework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Tasks.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Utilities.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.VisualBasic.Activities.Compiler.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.VisualBasic.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\netstandard.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Activities.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.DataAnnotations.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.Protocols.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.EnterpriseServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Caching.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.DurableInstancing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Internals.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceProcess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.RegularExpressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\WindowsBase.dll</Reference>
  <Namespace>System.Activities.Debugger</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Mail</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows.Documents</Namespace>
</Query>

async Task Main()
{
	var random = new Random();
	var listaEmail = Enumerable.Range(1,10)
		.Select(s=> new 
		{
		 	From = "99kote@99kote.com.br",
			FromDisplay = "FromDisplay",			
			To = "destino"+ random.Next(0,60) +"@praxio.com.br",
			ToDisplay = "ToDisplay" + new Random().Next(0,60),
			Subject = "Subject" + (s / 20),
			Body = "Body: " + (s / 20)
		})
		;	
	
	listaEmail.Dump();
	//var x1 = new System.Web.Mail.SmtpMail();
	//var oServer = new SmtpServer("smtp.emailarchitect.net");
		
	var smtpClient = new SmtpClient()
    {
        Host = "smtplw.com.br",
        Port = 587,
        EnableSsl = false,
        Credentials = new NetworkCredential("bgmrodotec", "@Ecommerce2022"),				
    };
	
	var timer = new Stopwatch();
	
	smtpClient.SendCompleted += (sender, args) => 
	{
		if (args.Error == null)
		{
			timer.Stop();
			Console.WriteLine(timer.Elapsed);
			timer.Reset();
		}
	};

	var mailAddressFrom = new MailAddress(
		listaEmail.First().From, 
		listaEmail.First().FromDisplay);	
		
	var listaAgrupada = listaEmail
		.GroupBy(g=> new 
		{	
			g.Body,
			g.Subject
		}, (a1,b1) => new 
		{
			email = new MailMessage
			{	
        		Subject = a1.Subject,
        		Body = a1.Body,
			},
			destinos = b1
				.GroupBy(g=> new 
				{
					To = g.To, 
					ToDisplay = g.ToDisplay
				}, (a2,b2) => new MailAddress(a2.To, a2.ToDisplay))		
		})
		;
	
	foreach (var itemAgrupado in listaAgrupada)
	{		
		itemAgrupado.email.From = mailAddressFrom;
		foreach (var itemDestino in itemAgrupado.destinos)	
			itemAgrupado.email.Bcc.Add(itemDestino);	
	
		timer.Start();		
		await smtpClient.SendMailAsync(itemAgrupado.email);
	}
}