<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Namespace>FGlobus.Util.ExtensaoObject</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
	System.Net.WebClient webClient = new System.Net.WebClient();
	string retorno = webClient.DownloadString(@" http://www.ctaplus.com.br:8080/SvWebSincronizaCarregamentos?token=23d8f6120a&data_inicio=01/03/2014")
	//.Dump()
	;	
		
	Foo1 foo1 = retorno.DeserializarStringParaObjeto<Foo1>();
	foo1.Dump();		
}




[XmlRootAttribute("CTAPLUS")]
public class Foo1
{
	[XmlElementAttribute("STATUS")]
	public Foo2 Status {get;set;}
	
	[XmlElementAttribute("CARREGAMENTOS")]
	public Foo3 Carregamentos {get;set;}
}

public class Foo2
{
	[XmlElementAttribute("CODIGO")]
 	public string Codigo {get;set;}
	
	[XmlElementAttribute("MENSAGEM")]
    public string Mensagem {get;set;}
}

public class Foo3
{
	[XmlElementAttribute("CARREGAMENTO")]
	public Foo4[] Carregamento {get;set;}
}

public class Foo4
{
	[XmlElementAttribute("ID")]
	public string Codigo {get;set;}	
	[XmlElementAttribute("DATA_HORA")]
    public DateTime DataHora{get;set;}	
	[XmlElementAttribute("VOLUME")]
    public string Volume {get;set;}
	[XmlElementAttribute("NOTA_FISCAL")]
    public string NotaFiscal {get;set;}
	
	[XmlElementAttribute("EMPRESA")]
    public Foo5 Empresa {get;set;}
	
	[XmlElementAttribute("POSTO")]
	public Foo6 Posto {get;set;}
	
	[XmlElementAttribute("TANQUE")]
	public Foo7 Tanque {get;set;}
}

public class Foo5
{
    public string CODIGO {get;set;}
    public string NOME{get;set;}
    public string CNPJ{get;set;}
    public string FILIAL{get;set;}
}

public class Foo6
{
	public string CODIGO {get;set;}
    public string NOME{get;set;}
}
	  
public class Foo7	  
{
   public string CODIGO {get;set;}
   public string NOME {get;set;}
}

