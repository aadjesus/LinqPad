<Query Kind="Program">
  <NuGetReference>ImapX</NuGetReference>
  <Namespace>ImapX</Namespace>
  <Namespace>System.Net.Mail</Namespace>
  <Namespace>ImapX.Enums</Namespace>
  <Namespace>ImapX.Authentication</Namespace>
  <Namespace>System.Security.Authentication</Namespace>
</Query>

void Main()
{
	var retorno = BaixarEmails();

	retorno.Dump();
	if (retorno != null)
		_listaIdMessage = retorno.Select(s=> s.Value.Item1);
		
	_listaIdMessage.Dump();
	ManipularRetorno();
}

#region Atributos

private ImapClient _imapClient;
private IEnumerable<long> _listaIdMessage;
private List<Message> _listaMessage;
private ImapClient ImapClient
{
    get
    {
        if (_imapClient == null)
        {
            try
            {
                _imapClient = new ImapClient();
                _imapClient.Host = AppSettings.ServidorImap;
                if (_imapClient.Connect() &&
                    _imapClient.Login(AppSettings.Email, AppSettings.Senha))
                {
                    _imapClient.Behavior.ExamineFolders = false;
                    _imapClient.Behavior.FolderTreeBrowseMode = FolderTreeBrowseMode.Lazy;
                    _imapClient.Behavior.MessageFetchMode = MessageFetchMode.Full;
                }
                else
                    throw new Exception("ImapClient: Não conseguiu conectar ou fazer o login.");
            }
            catch (Exception ex)
            {
                LogManager.Debug(ex.ToString());
                LogManager.Error(ex);
            }
        }
        return _imapClient;
    }
}
private string DiretorioEmail
{
    get
    {
        var directoryEmail = String.Concat(AppDomain.CurrentDomain.BaseDirectory, '\\', "email", '\\');

        if (!Directory.Exists(directoryEmail))
            Directory.CreateDirectory(directoryEmail);

        return directoryEmail;
    }
}

#endregion

public AnexoMlo CriarArquivoDeEmail(MailMessage mailMessage, string nomeArquivo)
{
    try
    {
        ExcluirArquivo(nomeArquivo);

        var assembly = typeof(SmtpClient).Assembly;
        var type = assembly.GetType("System.Net.Mail.MailWriter");
        using (var fileStream = new FileStream(nomeArquivo, FileMode.Create))
        {
            var constructorInfo = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new Type[] { typeof(Stream) },
                null);

            var mailWriter = constructorInfo.Invoke(new object[] { fileStream });

            var methodInfoSend = typeof(MailMessage).GetMethod(
                "Send",
                BindingFlags.Instance | BindingFlags.NonPublic);
            methodInfoSend.Invoke(
                mailMessage,
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new object[] { mailWriter, true, true },
                null);

            var methodInfoClose = mailWriter.GetType().GetMethod(
                "Close",
                BindingFlags.Instance | BindingFlags.NonPublic);
            methodInfoClose.Invoke(
                mailWriter,
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new object[] { },
                null);
        }

        if (File.Exists(nomeArquivo))
        {
            var fileInfo = new FileInfo(nomeArquivo);
            return new AnexoMlo()
            {
                Anexo = File.ReadAllBytes(nomeArquivo),
                Nome = fileInfo.Name,
                Tipo = fileInfo.Extension,
                Tamanho = (int)fileInfo.Length
            };
        }

        throw new Exception(String.Format(MyTicket.Comum.Properties.Mensagens.NaoFoiPossivelCriarArquivo, nomeArquivo));
    }
    catch (Exception ex)
    {
        throw new Exception(mailMessage.Subject, ex);
    }
}

private IEnumerable<Message> RetornarMensagens()
{
    if (ImapClient.IsConnected && ImapClient.IsAuthenticated)
        foreach (var folder in ImapClient.Folders)
        {
            folder.Messages.Download(
                String.Concat("SUBJECT ", AppSettings.TextoContidoNoAssunto),
                MessageFetchMode.Minimal,
                AppSettings.QtdeEmail);

            var listaMensagem = folder.Messages
                .Where(w => !w.Seen &&
                            RetornarProtocolo(w.Subject).Success);

            foreach (var mensagem in listaMensagem)
                yield return mensagem;
        }
}

private Match RetornarProtocolo(string texto)
{
    var regex = Regex.Match(texto, (AppSettings.TextoContidoNoAssunto + @" \[.*\]"));
    regex = Regex.Match(regex.Value, @"\d{4}-\d{6}");

    if (!regex.Success)
        LogManager.Error(String.Concat("Texto do assunto invalido: ", texto));

    return regex;
}

private System.Net.Mail.MailAddress RetornarEmail(ImapX.MailAddress endereco)
{
    return new System.Net.Mail.MailAddress(
        endereco.Address,
        endereco.DisplayName);
}

private Dictionary<string, Tuple<long, string, AnexoMlo>> BaixarEmails()
{
    _listaMessage = new List<Message>(RetornarMensagens());
    if (_listaMessage.Count == 0)
        return null;

    var retorno = new Dictionary<string, Tuple<long, string, AnexoMlo>>();
	
	_listaMessage.Select(s=> new {s.From, s.Cc, s.Bcc}).Where(w=> w.Cc.Count > 0).Dump();
    foreach (var mensagem in _listaMessage.OrderBy(o => o.Date))
    {
        try
        {		
            var numeroTicket = RetornarProtocolo(mensagem.Subject).Value;
            if (retorno.ContainsKey(numeroTicket))
                continue;

            var mailMessage = new MailMessage(
                RetornarEmail(mensagem.From),
                RetornarEmail(mensagem.To.FirstOrDefault()))
            {
                Subject = mensagem.Subject,
                Body = mensagem.Body.Text
            };
            var nomeEmail = String.Concat(numeroTicket, '_', mensagem.UId);

            foreach (var anexo in mensagem.Attachments)
                mailMessage.Attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(anexo.FileData), anexo.FileName));

            var pathEmail = String.Concat(DiretorioEmail, nomeEmail, ".eml");
            var anexoMlo = CriarArquivoDeEmail(mailMessage, pathEmail);

            retorno.Add(
                numeroTicket,
                Tuple.Create(
                    mensagem.UId,
                    mensagem.From.Address,
                    anexoMlo));
        }
        catch (Exception ex)
        {
            LogManager.Debug(ex.ToString());
            LogManager.Error(ex);
        }
    }

    return retorno;
}

private void ManipularRetorno()
{
    if (_listaIdMessage == null || _listaIdMessage.Count() == 0)
        return;

    try
    {
        if ((new int[] { 1, 2 }).Contains(AppSettings.AcaoComEmail))
            foreach (var idEmail in _listaIdMessage)
            {
                var mensagem = _listaMessage
                    .FirstOrDefault(f => f.UId == idEmail);

                if (mensagem == null)
                    continue;

                if (AppSettings.AcaoComEmail == 1)
                    mensagem.Seen = true;
                else
                    mensagem.Remove();
            }
    }
    catch (Exception ex)
    {
        LogManager.Error(ex);
    }
    finally
    {
        ExcluirArquivosGerados();
    }
}

private void ExcluirArquivosGerados()
{
    foreach (var item in _listaIdMessage)
        foreach (string arquivo in Directory.GetFiles(DiretorioEmail, String.Concat(item, "*")))
            ExcluirArquivo(arquivo);
}

private void ExcluirArquivo(string arquivo)
{
    try
    {
        if (File.Exists(arquivo))
            File.Delete(arquivo);
    }
    catch (Exception ex)
    {
        LogManager.Error(arquivo, ex);
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#region xxxxxxxxxxxx

public static class LogManager
{
	public static void Debug(string message)
	{
    	message.Dump();
	}
	
	public static void Error(string message)
	{
		message.Dump();
	}
	
	public static void Error(Exception exception)
    {
    	exception.ToString().Dump();
    }
	
	public static void Error(string message, Exception exception)
    {
		message.Dump();
    	exception.ToString().Dump();
    }
}

public static class MyTicket
{
	public static class Comum
	{
		public static class Properties
		{
			public static class Mensagens
			{
				public static string NaoFoiPossivelCriarArquivo = "NaoFoiPossivelCriarArquivo";
			}	
		}
	}
}

public class AnexoMlo 
{
	public virtual int Id { get; set; }
	public virtual string Nome { get; set; }
	public virtual string Tipo { get; set; }
	public virtual int Tamanho { get; set; }
	public virtual byte[] Anexo { get; set; }
}

public static class AppSettings
{
	public static string ServidorImap="cpanel5.molservidores.com";
	public static string Email="portaldocliente@myticket.net.br";
	public static string Senha="@portaldocliente2016";
	public static int AcaoComEmail = 0;
	public static string TextoContidoNoAssunto="ticket:";
	public static int QtdeEmail = 50;
}


#endregion