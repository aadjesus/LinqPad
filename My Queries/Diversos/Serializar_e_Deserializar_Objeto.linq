<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Namespace>FGlobus.Util.ExtensaoObject</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
    LogCampoVO[] listaCampos = new LogCampoVO[] 
    {
        new LogCampoVO() {Nome ="txtEdtCodigoIbgeEstado", Tipo ="TextEditBGM", Mascara ="\\d{0,3}", Titulo ="Código IBGE", Valor ="1"},
        new LogCampoVO() {Nome ="txtEdtDescricaoEstado", Tipo ="TextEditBGM", Titulo ="Descrição", Valor ="1231321"},
        new LogCampoVO() {Nome ="spnEdtQtdDigFinalPlaca", Tipo ="SpinEdit", Mascara ="d", Titulo ="Dígitos placa", Valor ="1"},
        new LogCampoVO() {Nome ="clcPrestacaoServTransExterna", Tipo ="CalcEditBGM", Mascara ="n", Titulo ="Alíquota ICMS &gt; Prestação de serviço de transporte &gt; Externa", Valor ="11,00"},
        new LogCampoVO() {Nome ="clcPrestacaoServTransInterna", Tipo ="CalcEditBGM", Mascara ="n", Titulo ="Alíquota ICMS &gt; Prestação de serviço de transporte &gt; Interna", Valor ="1,00"},
        new LogCampoVO() {Nome ="clcMercadoriaInterna", Tipo ="CalcEditBGM", Mascara ="n", Titulo ="Alíquota ICMS &gt; Mercadorias &gt; Interna", Valor ="1,00"},
        new LogCampoVO() {Nome ="clcMercadoriaExterna", Tipo ="CalcEditBGM", Mascara ="n", Titulo ="Alíquota ICMS &gt; Mercadorias &gt; Externa", Valor ="1,00"}
    };

	LogVO logVO = new LogVO(){ ListaCampos = listaCampos};
	//logVO.SerializarObjetoParaString().Dump();

	
	string campos = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<ArrayOfLogCampoVO xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <LogCampoVO>\r\n    <Nome>txtEdtCodigoIbgeEstado</Nome>\r\n    <Tipo>TextEditBGM</Tipo>\r\n    <Mascara>\\d{0,3}</Mascara>\r\n    <Titulo>Código IBGE</Titulo>\r\n    <Valor>1</Valor>\r\n  </LogCampoVO>\r\n  <LogCampoVO>\r\n    <Nome>txtEdtDescricaoEstado</Nome>\r\n    <Tipo>TextEditBGM</Tipo>\r\n    <Mascara />\r\n    <Titulo>Descrição</Titulo>\r\n    <Valor>1231321</Valor>\r\n  </LogCampoVO>\r\n  <LogCampoVO>\r\n    <Nome>spnEdtQtdDigFinalPlaca</Nome>\r\n    <Tipo>SpinEdit</Tipo>\r\n    <Mascara>d</Mascara>\r\n    <Titulo>Dígitos placa</Titulo>\r\n    <Valor>1</Valor>\r\n  </LogCampoVO>\r\n  <LogCampoVO>\r\n    <Nome>clcPrestacaoServTransExterna</Nome>\r\n    <Tipo>CalcEditBGM</Tipo>\r\n    <Mascara>n</Mascara>\r\n    <Titulo>Alíquota ICMS &gt; Prestação de serviço de transporte &gt; Externa</Titulo>\r\n    <Valor>11,00</Valor>\r\n  </LogCampoVO>\r\n  <LogCampoVO>\r\n    <Nome>clcPrestacaoServTransInterna</Nome>\r\n    <Tipo>CalcEditBGM</Tipo>\r\n    <Mascara>n</Mascara>\r\n    <Titulo>Alíquota ICMS &gt; Prestação de serviço de transporte &gt; Interna</Titulo>\r\n    <Valor>1,00</Valor>\r\n  </LogCampoVO>\r\n  <LogCampoVO>\r\n    <Nome>clcMercadoriaInterna</Nome>\r\n    <Tipo>CalcEditBGM</Tipo>\r\n    <Mascara>n</Mascara>\r\n    <Titulo>Alíquota ICMS &gt; Mercadorias &gt; Interna</Titulo>\r\n    <Valor>1,00</Valor>\r\n  </LogCampoVO>\r\n  <LogCampoVO>\r\n    <Nome>clcMercadoriaExterna</Nome>\r\n    <Tipo>CalcEditBGM</Tipo>\r\n    <Mascara>n</Mascara>\r\n    <Titulo>Alíquota ICMS &gt; Mercadorias &gt; Externa</Titulo>\r\n    <Valor>1,00</Valor>\r\n  </LogCampoVO>\r\n</ArrayOfLogCampoVO>";
	
	var reader = new StringReader(campos);
    var serializer = new XmlSerializer(typeof(LogCampoVO[]));
    var instance = serializer.Deserialize(reader);
	instance.Dump();
}

[Serializable()]
[System.Xml.Serialization.XmlRoot("LogCampoVOCollection")]
public class LogVO
{
	public  LogVO(){}
    public double ID { get; set; }
    public string Sistema { get; set; }
    public string Usuario { get; set; }
    public DateTime Data { get; set; }
    public int TipoBotao { get; set; }
    public string ItemDeMenu { get; set; }
    public string NomeAssembly { get; set; }
    public string TituloCamposChave { get; set; }
    public string ValorCamposChave { get; set; }
    public string Complemento { get; set; }
    [XmlIgnore]
    public string CheckSum { get; set; }
    [XmlIgnore]
    public string Campos { get; set; }
	
//	[XmlArray("ListaCampos")]
//    [XmlArrayItem("LogCampoVO", typeof(LogCampoVO))]
    public LogCampoVO[] ListaCampos { get; set; }
	
    public LogSACVO UsuarioSAC { get; set; }
}

public class LogCampoVO
{
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public string Mascara { get; set; }
    public string Titulo { get; set; }
	public string Valor { get; set; }
}

public class LogSACVO
{
	public LogSACVO(){}
	
    [XmlIgnore]
    public double ID { get; set; }
    public double IDLog { get; set; }
    public string CodigoFuncionario { get; set; }
    public string UsuarioSO { get; set; }
    public string Motivo { get; set; }
}