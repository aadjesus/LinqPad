<Query Kind="Program">
  <Reference Relative="..\Dll\BgmRodotec.FGlobus.Util.dll">c:\Users\Ale\Box Sync\Aplicativos\LinqPad\My Queries\Dll\BgmRodotec.FGlobus.Util.dll</Reference>
  <Namespace>System.Net.Mail</Namespace>
  <Namespace>System.Net.Mime</Namespace>
</Query>

void Main()
{
	//var diretorio = new DirectoryInfo(string.Concat("c:\\temp\\" + DateTime.Now.ToString("#ddMMyyyy_HHmmssffff_")));	
	//if (!diretorio.Exists)
	//    diretorio.Create();	    
	//diretorio.Refresh();
	//
	//var arquivo = String.Concat(diretorio, "\\", "xxxx.txt");				
	//var sw = File.Create(arquivo);
	//sw.Write( new byte[] {0}, 0, 1);			
	//sw.Close();	
	
	//	Servidor SMTP: smtp.office365.com
	//	Porta: 587 (saiba mais sobre os portas SMTP)
	//	Requer SSL: Sim
	//	Requer TLS: Sim (se disponível)
	//	Autenticação: Sim (escolha Login se houver várias opções disponíveis)
	//	Nome de usuário: Seu endereço de e-mail Outlook completo (ex.: salman123@outlook.com)
	//	Senha: Sua senha Outlook – a mesma que você usa para acessar o site Outlook

	var enviarEmail = FGlobus.Util.Email.EnviarEmail(
		new FGlobus.Util.Email.ParametrosDeEmail()
		{
			Assunto = "teste",
			//ListaDeAnexos = new ArrayList(new string[] {arquivo}),
			ListaDestinatario = new List<FGlobus.Util.Email.Destinatario>(new FGlobus.Util.Email.Destinatario[] 
			{
				new FGlobus.Util.Email.Destinatario(){ EmailDestinatario = "alessandro.augusto@praxio.com.br", NomeApresentacaoDestinatario = "ale"}	
			}),
			HTML = false,			
			Mensagem = "xxxxxxxxxxxxx",
			Remetente = new FGlobus.Util.Email.Remetente()
			{ 
			 	EmailRemetente = "cargas.bgm@ig.com.br",
			 	NomeApresentacaoRemetente = "ale",
			 	Porta = 587, 
				SenhaEmail = "cargas123",
				SMTP = "smtp.ig.com.br", 
				UtilizarSslEnvio = true
			}				
		});
	
	enviarEmail.Dump();
}