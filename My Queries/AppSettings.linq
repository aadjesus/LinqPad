<Query Kind="Program">
  <Namespace>System.Dynamic</Namespace>
</Query>

void Main()
{
	var appSettings = new AppSettings();
	appSettings.Parametros.Paginacoes.Add("A1","xxxxx");
	
	//var x2 = x1.Paginacoes.Get();
	//appSettings.Dump();
	appSettings.Parametros.Paginacoes["A1"].Dump();
	
	var x1 = appSettings.Parametros.Paginacoes.Item1.A1.Dump();
	
	
	//appSettings.Parametros.Paginacoes.aaaa.Dump();
	
}

public class Item 
{
    public Item() { }
    public Item(string chave, string valor)
    {
        Chave = chave;
        Valor = valor;
    }
    public string Chave { get; set; }
    public string Valor { get; set; }
}

public class ItemCollection : List<Item>
{
	DynamicDictionary aaaaa = null;
    public ItemCollection()
    { 
	    aaaaa = new DynamicDictionary(); 
		Item1 = aaaaa;
    } 
	
	public dynamic Item1 { get ;set; }	
	
	public string this[string chave]
	{
		get 
		{
			return (this.FirstOrDefault(f=> f.Chave == chave) ?? new Item()).Valor ;
		}
	}
	
	
	public void Add(string chave, string valor)
	{
		aaaaa.Add(chave, valor);
		//Item1.chave = valor;
	}
}

public class DynamicDictionary : DynamicObject
{
    Dictionary<string, object> dictionary = new Dictionary<string, object>();

    public int Count
    {
        get
        {
            return dictionary.Count;
        }
    }

	public void Add(string chave, string valor)
	{
		dictionary.Add(chave.ToLower(),valor);
		//Item1.chave = valor;
	}
	
	
    public override bool TryGetMember(
        GetMemberBinder binder, out object result)
    {
        string name = binder.Name.ToLower();
        return dictionary.TryGetValue(name, out result);
    }

    public override bool TrySetMember(
        SetMemberBinder binder, object value)
    {
        dictionary[binder.Name.ToLower()] = value;
        return true;
    }
}

public class Opcoes
{
	public Opcoes()
	{
		Outros = new ItemCollection();
		Paginacoes = new ItemCollection();
		Tarefas = new ItemCollection();
		Schemas = new ItemCollection();
		Integracao = new ItemCollection();		
		CargaInicial = true;
        IgnorarMigrations = new long[0];
	}
	
	public IList<long> IgnorarMigrations { get; set; }
	public bool CargaInicial { get; set; }
	public ItemCollection Outros { get; set; }
	public ItemCollection Paginacoes { get; set; }	
	public ItemCollection Tarefas { get; set; }
	public ItemCollection Schemas { get; set; }
	public ItemCollection Integracao { get; set; }
}

public class AppSettings 
{
	public AppSettings()
	{		
		Parametros = new Opcoes();
	}	
	
	public Opcoes Parametros { get; set; }
}

