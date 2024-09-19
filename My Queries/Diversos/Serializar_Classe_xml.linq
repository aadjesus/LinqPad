<Query Kind="Program">
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
   Teste[] listaTeste = new Teste[] 
	{
		new Teste() { Codigo=1, Descricao="1111111111", Tipo= 1, Status = "A"},
		new Teste() { Codigo=2, Descricao="2222222222", Tipo= 4, Status = "B"},
		new Teste() { Codigo=3, Descricao="3333333333", Tipo= 1, Status = "C"},
		new Teste() { Codigo=4, Descricao="4444444444", Tipo= 2, Status = "A"},
		new Teste() { Codigo=5, Descricao="5555555555", Tipo= 3, Status = "A"},
		new Teste() { Codigo=6, Descricao="6666666666", Tipo= 3, Status = "A"},
		new Teste() { Codigo=7, Descricao="7777777777", Tipo= 1, Status = "B"},
		new Teste() { Codigo=8, Descricao="8888888888", Tipo= 4, Status = "C"}
	};

  XmlSerializer serializer = new XmlSerializer(listaTeste.GetType());
  TextWriter textWriter = new StreamWriter(@"C:\movie.xml");
  serializer.Serialize(textWriter, listaTeste);
  textWriter.Close();
  
  
   XmlSerializer deserializer = new XmlSerializer(typeof(List<Teste>));
   TextReader textReader = new StreamReader(@"C:\movie.xml");
   List<Teste> movies;
   movies = (List<Teste>)deserializer.Deserialize(textReader);
   textReader.Close();

   movies.Dump();
}


public class Teste
{	
	public int Codigo;
	public string Descricao;
	public int Tipo {get;set;}
	public string Status {get;set;}
}

