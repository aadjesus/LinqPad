<Query Kind="Program">
  <Namespace>System.Net.Mail</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

async Task Main()
{
	var itemEmail = new 
	{
		From = "99kote@99kote.com.br",
		FromDisplay = "FromDisplay: " + DateTime.Now,			
		To = "camila.cipriano@praxio.com.br",
		ToDisplay = "ToDisplay: " + DateTime.Now,			
		Subject = "Subject: " + DateTime.Now,			
		Body = "Body: " + DateTime.Now,			
	};		

	var smtpClient = new SmtpClient()
    {
        Host = "smtplw.com.br",
        Port = 587,
        EnableSsl = false,
        Credentials = new NetworkCredential("bgmrodotec", "GLOBUSNET10MEI"),//"@Ecommerce2022"),		
    };	
	
	smtpClient.SendCompleted += (sender, args) => 
	{
	 	args.Dump();	
		sender.Dump();	
	};		
	
	var mailAddressFrom = new MailAddress(itemEmail.From, itemEmail.FromDisplay);
	
	var mailMessage = new MailMessage
	{
		From = mailAddressFrom,
    	Subject = itemEmail.Subject,
    	Body = itemEmail.Body
	};
	
	mailMessage.To.Add(new MailAddress(itemEmail.To, itemEmail.ToDisplay));
	
	await smtpClient.SendMailAsync(mailMessage);						
}