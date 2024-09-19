<Query Kind="Program">
  <Connection>
    <ID>e9685810-2d30-4e55-aa6c-da36844470a0</ID>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.Oracle</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAYjypxDDLc0SVxfgHg2/fXwAAAAACAAAAAAADZgAAwAAAABAAAABMjDpo6Qg0nIiHMotfYkz0AAAAAASAAACgAAAAEAAAAC5aoJYkv/KRoWLnA1IapRA4AAAAkyqHsVGY8AEaQYgorl5FXUGi4cY/pyvVpwD1/e8qUmESkOK6d7P4t1bvAkrhnsYhYFoBgF8om78UAAAAJ/lGubIxRBDKCG69xEh2Qq2r0sI=</CustomCxString>
    <Server>ORA11g64</Server>
    <UserName>BB150219</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAYjypxDDLc0SVxfgHg2/fXwAAAAACAAAAAAADZgAAwAAAABAAAABuCDSYlW74qmc/oiaHzcJEAAAAAASAAACgAAAAEAAAAHIWWfCzxmcLSY3oJsn3Y38QAAAA5e3o5sXmi7EbQRfYnd4/AhQAAADwipecHpPZ+BdTTfJqgMrpnAuiBg==</Password>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>true</StripUnderscores>
      <QuietenAllCaps>true</QuietenAllCaps>
      <ConnectAs>Default</ConnectAs>
      <UseOciMode>true</UseOciMode>
    </DriverData>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationTypes.dll</Reference>
</Query>

void Main()
{
	//// Atualiza os dados do Dump
	var dc = new DumpContainer().Dump();
	for (int i = 0; i < 100; i++)
	{
		Thread.Sleep(10);
		dc.Content = i;
	}
	
	//-----------------------------------------------------------------------------------------------------------------------------
	////Mostra um hiper linq
	////Executar no modo C# Expression
	//new Hyperlinq (() => System.Windows.Forms.MessageBox.Show ("Teste"), "Clique aqui")
	//new Hyperlinq (() => System.Security.Cryptography.RSA.Create().ToXmlString (true).Dump(), "Generate keypair")
	
	//-----------------------------------------------------------------------------------------------------------------------------			
	//// Mostra barra de progresso
	//var prog = new Util.ProgressBar ("Processing").Dump();
	//for (int i = 0; i < 101; i++)
	//{
	//		Thread.Sleep(50);
	//		prog.Percent = i;
	//}
	//prog.Caption = "Done";
	
	//-----------------------------------------------------------------------------------------------------------------------------
	////nao esta funcando
	//Observable.Interval(TimeSpan.FromSeconds(0.2)).Dump ("200 ms");
	
	//-----------------------------------------------------------------------------------------------------------------------------
	////Salva os dados em um arquivo
	//Util.WriteCsv(Enumerable.Range(1,10), @"c:\temp\customers.csv"); 
	
	//-----------------------------------------------------------------------------------------------------------------------------
	//// limpa a janela de resultados
	//"a".Dump();
	//Util.ClearResults (); 
	
	//-----------------------------------------------------------------------------------------------------------------------------
	//	// Habilita linha para inserir valores
	//	DateTime dt = Util.ReadLine ("Data de nascimento", DateTime.Now);
	//	int idade = Util.ReadLine<int>("Informe a sua idade (opcional)");
	//string name = Util.ReadLine ("Sua cor favorita", "", new [] {"Red", "Yellow", "Green", "Blue"});
	//name.Dump();
	
	//-----------------------------------------------------------------------------------------------------------------------------
	//	// Mostra a imagem
	//Util.Image(@"c:\GlobusMais\Frameworks\FGlobus\Componentes.WinForms\Resources\IconeGlobusMais_64x64.png").Dump();
	
	
	
	
}

// Define other methods and classes here