<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
  </Connection>
</Query>

void Main()
{
	Objeto1 objeto1 = new Objeto1(){ Codigo1="Objeto1 - Codigo1", Codigo2= "Objeto1 - Codigo2"};
	Type tipo = typeof(Objeto1);
	tipo.InvokeMember("Codigo1", BindingFlags.GetProperty| BindingFlags.GetField , null, objeto1, null).Dump();
	tipo.InvokeMember("Codigo2", BindingFlags.GetProperty| BindingFlags.GetField , null, objeto1, null).Dump();
	 
	Objeto2 objeto2 = new Objeto2(){ Codigo1="Objeto2 - Codigo1", Codigo2= "Objeto2 - Codigo2"};
	tipo = typeof(Objeto2);
	tipo.InvokeMember("Codigo1", BindingFlags.GetProperty| BindingFlags.GetField , null, objeto2, null).Dump();
	tipo.InvokeMember("Codigo2", BindingFlags.GetProperty| BindingFlags.GetField , null, objeto2, null).Dump();	 
	
}

public struct Objeto1
{	
	public string Codigo1 ;
	public string Codigo2 {get;set;}
}

public class Objeto2
{
	public string Codigo1;
	public string Codigo2 {get;set;}
}