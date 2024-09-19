<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\System.Windows.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Xml.Xsl</Namespace>
</Query>

void Main()
{
	System.Windows.Forms.WebBrowser webBrowser = new System.Windows.Forms.WebBrowser();

	string aaa = 
	
	
//	"<?xml version='1.0'?>"+
//    "<?xml-stylesheet href=\"dontwant.xsl\" type=\"text/xsl\"?>"+
	"<root>"+
	"<retConsReciCTe versao=\"1.04\" xmlns=\"http://www.portalfiscal.inf.br/cte\"><tpAmb>2</tpAmb><verAplic>SP-CTe-30-04-2013</verAplic><nRec>351000003170868</nRec><cStat>104</cStat><xMotivo>Lote processado</xMotivo><cUF>35</cUF><protCTe versao=\"1.04\"><infProt><tpAmb>2</tpAmb><verAplic>SP-CTe-09-05-2013</verAplic><chCTe>35130547888128000105570010009730771004369126</chCTe><dhRecbto>2013-05-21T14:46:42</dhRecbto><nProt>135130004927312</nProt><digVal>5XmLc9FMIRIzXBm5GG6V19Wrj5E=</digVal><cStat>100</cStat><xMotivo>Autorizado o uso do CT-e</xMotivo></infProt></protCTe><protCTe versao=\"1.04\"><infProt><tpAmb>2</tpAmb><verAplic>SP-CTe-09-05-2013</verAplic><chCTe>35130547888128000105570010009730781004369131</chCTe><dhRecbto>2013-05-21T14:46:42</dhRecbto><nProt>135130004927313</nProt><digVal>KQWQqOVYmdLXwStS+Et5ESxPAW0=</digVal><cStat>100</cStat><xMotivo>Autorizado o uso do CT-e</xMotivo></infProt></protCTe><protCTe versao=\"1.04\"><infProt><tpAmb>2</tpAmb><verAplic>SP-CTe-09-05-2013</verAplic><chCTe>35130547888128000105570010009730791004369147</chCTe><dhRecbto>2013-05-21T14:46:42</dhRecbto><nProt>135130004927314</nProt><digVal>WMEK61DBrnKCygcvJQvKCwQf+q0=</digVal><cStat>100</cStat><xMotivo>Autorizado o uso do CT-e</xMotivo></infProt></protCTe><protCTe versao=\"1.04\"><infProt><tpAmb>2</tpAmb><verAplic>SP-CTe-09-05-2013</verAplic><chCTe>35130547888128000105570010009730801004369156</chCTe><dhRecbto>2013-05-21T14:46:42</dhRecbto><nProt>135130004927315</nProt><digVal>dw7zH2eJKBwMqaTJPIhsFLAwhv8=</digVal><cStat>100</cStat><xMotivo>Autorizado o uso do CT-e</xMotivo></infProt></protCTe><protCTe versao=\"1.04\"><infProt><tpAmb>2</tpAmb><verAplic>SP-CTe-09-05-2013</verAplic><chCTe>35130547888128000105570010009730811004369161</chCTe><dhRecbto>2013-05-21T14:46:42</dhRecbto><nProt>135130004927316</nProt><digVal>FLlg3S1mbBj/U/3uOe0wbjfc7xc=</digVal><cStat>100</cStat><xMotivo>Autorizado o uso do CT-e</xMotivo></infProt></protCTe></retConsReciCTe>"+
	"</root>"+
	""
	;
	
	
	 		MemoryStream smmem = new MemoryStream();

            StreamWriter sw = new StreamWriter(smmem,Encoding.GetEncoding("windows-1252"));

			System.Xml.Xsl.XslCompiledTransform xct = new XslCompiledTransform();	
            //xct.Transform( smXML, null, sw);

            StreamReader sr = new StreamReader(smmem, Encoding.GetEncoding("windows-1252"));


            //File.AppendAllText(@"C:\smxml.xml",smXML.InnerXml);
            //webBrowser1.Url = new Uri(@"C:\smxml.xml");
            smmem.Seek(0, SeekOrigin.Begin);
            webBrowser.DocumentText = sr.ReadToEnd();
	
				
				
	
	//webBrowser.Document.OpenNew(true);
	//webBrowser.Document.Write(aaa);
	
	
	
	
//	byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(aaa);	
//	Stream s = new MemoryStream(byteArray);
//	XmlReader xr = XmlReader.Create(s);
//	XslCompiledTransform xct = new XslCompiledTransform();
//	xct.Load(xr);
//
//	StringBuilder sb = new StringBuilder();
//	XmlWriter xw = XmlWriter.Create(sb);
//	xct.Transform(aaa, xw);
//	wb.DocumentText = sb.ToString();


		
	
//	byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(aaa);	
//	wb.DocumentStream = new MemoryStream(byteArray);
//	
//	XmlDocument loadDoc = new XmlDocument();
//	loadDoc.Load( new MemoryStream(byteArray) );
//	//aaa = loadDoc.SelectSingleNode("/browser/home").Attributes["url"].InnerText;
//	loadDoc.InnerText.Dump();
//	//loadDoc.SelectSingleNode("/browser/home").Attributes["url"].InnerText.Dump();
//	
//	wb.Navigate( loadDoc.InnerXml );

	//XDocument doc = XDocument.Parse(aaa); 		
	//wb.Navigate("about:blank");
	//HtmlDocument doc = new XDocument(
	//doc.Write(string.Empty);
	//wb.DocumentText = xmlOutput;
	
//	//XMLInStream stream = new XMLInStream("<root><foo>3</foo><bar>baz</bar></root>");
//	XmlDocument xDoc = new XmlDocument();
//	XmlElement xElem = xDoc.CreateElement("Content");
//	xElem.InnerText = aaa ;
//	
//	HtmlDocument doc = new HtmlDocument();
//	doc.Write(aaa);
//	
//	wb.DocumentText = xmlOutput;
//	
	
	//byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(aaa);	
	//wb.DocumentStream = new MemoryStream(byteArray);
	
	//StreamReader stream = new StreamReader( new MemoryStream(byteArray).Dump());
	//wb.DocumentStream = stream.BaseStream.Dump();
	
	//wb.DocumentText = doc.ToString();
	
	
//byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(aaa);
//Stream s = new MemoryStream(byteArray);
//
//XmlReader xr = XmlReader.Create(s);
//XslCompiledTransform xct = new XslCompiledTransform();
//xct.Load(xr);
//StringBuilder sb = new StringBuilder();
//XmlWriter xw = XmlWriter.Create(sb);
//xct.Transform(aaa, xw);
//wb.DocumentText = sb.ToString();

	Form a = new Form();
	webBrowser.Dock = DockStyle.Fill;
    a.Controls.Add(webBrowser);
	a.ShowDialog();

}

