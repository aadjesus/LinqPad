<Query Kind="Program">
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
</Query>

void Main()
{
	var certificado = new X509Certificate2(
		@"c:\TMP\Certificado\Transtassi.pfx",
        "12345678"//"1875"//"06091966",
        //X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet
		);
	
	 X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
     store.Open(OpenFlags.ReadWrite);
     store.Add(certificado);
     store.Close();
	
	certificado.Dump();
	store.Dump();
}