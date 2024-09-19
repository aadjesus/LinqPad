<Query Kind="Program">
  <NuGetReference>ImapX</NuGetReference>
  <Namespace>ImapX</Namespace>
  <Namespace>System.Net.Mail</Namespace>
  <Namespace>ImapX.Enums</Namespace>
</Query>

void Main()
{
	var x1 = BaixarEmails();
	x1.Dump();
	
	RemoverEmails(x1.Select(s=> s.Value.Item1));				
}

        private ImapClient _imapClient;

        private ImapClient ImapClient
        {
            get
            {
                if (_imapClient == null)
                {
                    try
                    {
                        _imapClient = new ImapClient("imap.bgmrodotec.com.br");
                        if (_imapClient.Connect() &&
                            _imapClient.Login("alessandro.augusto@bgmrodotec.com.br", "9251@ajic"))
                        {
                            _imapClient.Behavior.AutoPopulateFolderMessages = true;
                            _imapClient.Behavior.ExamineFolders = false;
                            _imapClient.Behavior.FolderTreeBrowseMode = FolderTreeBrowseMode.Lazy;
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.Dump();
                    }

                }
                return _imapClient;
            }
        }

        private IEnumerable<Message> RetornarEmails(IEnumerable<long> listaIdEmail = null)
        {
            if (ImapClient.IsConnected)
                foreach (var folder in ImapClient.Folders)
                {
                    var listaMensagem = listaIdEmail == null
                        ? folder.Messages.OfType<Message>()
                        : folder.Search(listaIdEmail.ToArray());

                    foreach (var mensagem in listaMensagem)
                    {
                        if (
							//!mensagem.Seen && 
							RetornarRegex(mensagem.Subject).Success)
                            yield return mensagem;
                    }
                }
        }

        private Match RetornarRegex(string texto)
        {
            var regex = Regex.Match(texto, @"\[Ticket:.*\]");
            return Regex.Match(regex.Value, @"\d{4}-\d{6}");
        }

        private System.Net.Mail.MailAddress RetornarEmail(ImapX.MailAddress endereco)
        {
            return new System.Net.Mail.MailAddress(
                endereco.Address,
                endereco.DisplayName);
        }

        public Dictionary<string, Tuple<long, string, byte[]>> BaixarEmails()
        {
            try
            {
                var directoryEmail = String.Concat(AppDomain.CurrentDomain.BaseDirectory, '\\', "email", '\\');
                if (!Directory.Exists(directoryEmail))
                    Directory.CreateDirectory(directoryEmail);

                Dictionary<string, Tuple<long, string, byte[]>> retorno = null;
                foreach (var mensagem in RetornarEmails())
                {
                    try
                    {
                        if (retorno == null)
                            retorno = new Dictionary<string, Tuple<long, string, byte[]>>();

                        var numeroTicket = RetornarRegex(mensagem.Subject).Value;

                        var mailMessage = new MailMessage(
                            RetornarEmail(mensagem.From),
                            RetornarEmail(mensagem.To.FirstOrDefault()))
                        {
                            Subject = mensagem.Subject,
                            Body = mensagem.Body.Text
                        };

                        var nomeArquivo = String.Concat(numeroTicket, '_', mensagem.UId);
						mensagem.Comments = nomeArquivo;						

                        foreach (var anexo in mensagem.Attachments)
                        {
                            anexo.Download();
                            var nomeAnexo = String.Concat(nomeArquivo, '_', anexo.FileName);
                            anexo.Save(directoryEmail, nomeAnexo);

                            var pathAnexo = String.Concat(directoryEmail, nomeAnexo);
                            mailMessage.Attachments.Add(new System.Net.Mail.Attachment(pathAnexo));
                        }

                        var pathEmail = String.Concat(directoryEmail, nomeArquivo, ".eml");
                        var arquivoEmail = RetornarArquivoDeEmail(mailMessage, pathEmail);
						mensagem.Save(pathEmail);

                        retorno.Add(
                            numeroTicket,
                            Tuple.Create(
                                mensagem.UId,
                                mailMessage.From.Address,
                                arquivoEmail));
                    }
                    catch (Exception ex)
                    {
                        ex.Dump();
                    }

                    return retorno;
                }

                ImapClient.Disconnect();
            }
            catch (Exception ex)
            {
                ex.Dump();
            }

            return null;
        }

        public byte[] RetornarArquivoDeEmail(MailMessage mailMessage, string nomeArquivo)
        {
            var assembly = typeof(SmtpClient).Assembly;
            var type = assembly.GetType("System.Net.Mail.MailWriter");
            byte[] result;
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

                result = new byte[fileStream.Length];
                fileStream.Read(result, 0, result.Length);

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

            return result;
        }

        private void RemoverEmails(IEnumerable<long> listaIdEmail)
        {
            if (listaIdEmail == null || listaIdEmail.Count() == 0)
                return;

            try
            {
                foreach (var mensagem in RetornarEmails())
                    mensagem.Seen = true;

                ImapClient.Disconnect();
            }
            catch (Exception ex)
            {
                ex.Dump();
            }
        }