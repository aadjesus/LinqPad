<Query Kind="Program" />

async Task Main()
{
	var listaEmail = Enumerable.Range(1,50)
		.Select(s=> new 
		{
		 	From = "99kote@99kote.com.br",
			FromDisplay = "FromDisplay" + (s / 100),			
			To = "destino"+ (s / 10) +"@praxio.com.br",
			ToDisplay = "ToDisplay" + (s / 10),
			Subject = "Subject: 1111" + (s / 50) ,
			Body = "Body 2" + (s / 25)			
		})
		.Dump()
		;	
	
	//var x1 = new System.Web.Mail.SmtpMail();
	//var oServer = new SmtpServer("smtp.emailarchitect.net");
	
	var smtpClient = new SmtpClient()
    {
        Host = "smtplw.com.br",
        Port = 587,
        EnableSsl = false,
        Credentials = new NetworkCredential("bgmrodotec", "GLOBUSNET10MEI"),		
    };	
	
	smtpClient.SendCompleted += (sender, args) => 
	{
		//args.Error
	 //args.Dump();	   
	};
	
	var timeout = Policy.TimeoutAsync(30, TimeoutStrategy.Pessimistic);
    var retry = Policy.Handle<Exception>()
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
		
	var retryWithTimeout = timeout.WrapAsync(retry);	
	
	var mailAddressFrom = new MailAddress(listaEmail.First().From, listaEmail.First().FromDisplay);
	
	var timer = new Stopwatch();
	foreach (var itemEmail in listaEmail)
	{
		var mailMessage = new MailMessage
		{
			From = mailAddressFrom,
        	Subject = itemEmail.Subject,
        	Body = itemEmail.Body
		};
		
		//mailMessage.To.Add(new MailAddress(itemEmail.To_Email, itemEmail.To_Display_Name));
		
		mailMessage.Bcc.Add(new MailAddress(itemEmail.To, itemEmail.ToDisplay));
		mailMessage.Bcc.Add("aadjesus1@outlook.com");
		//mailMessage.Bcc.Add("alessandroaugustodejesus1@outlook.com");
	
		//timer.Start();
		//await smtpClient.SendMailAsync(mailMessage);
		//timer.Stop();
		//timer.Elapsed.Dump();
		
		timer.Start();
		var envio = await retryWithTimeout.ExecuteAndCaptureAsync(() => smtpClient.SendMailAsync(mailMessage));
		if (envio.FinalException != null)
        	smtpClient.SendAsyncCancel();		
		
		timer.Stop();
		timer.Elapsed.Dump();
	}
}

//00:00:00.5121252
//00:00:00.7811039
//00:00:00.9089320
//00:00:01.0220697
//00:00:01.1925267
//00:00:01.3515687
//00:00:01.4716414
//00:00:01.5907449
//00:00:01.7094091
//00:00:01.8912694
//00:00:02.0005254
//00:00:02.1506644
//00:00:02.3159733
//00:00:02.4334163
//00:00:02.5323188