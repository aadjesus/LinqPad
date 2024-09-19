<Query Kind="Program" />

void Main()
{
	List<DTO1> lista1 = new List<DTO1>();
	lista1.Add(new DTO1(){ Codigo1 = 1, Codigo2 = 2, Codigo3 = 3, Codigo4 = 4, Codigo5= 5, Codigo6 = 6});
	
	List<DTO2> lista2 = new List<DTO2>();
	lista2.Add(new DTO2(){ Codigo1 = 11, Codigo2 = 22, Codigo3 = 33});
	
	List<DTO3> lista3 = new List<DTO3>();
	lista3.Add(new DTO3(){ Codigo1 = 111, Codigo2 = 222, Codigo3 = 333, Desc = "teste" });
	
	List<IDTO> aaa = new List<IDTO>();		
	aaa.AddRange(lista1.ToArray());	
	aaa.AddRange(lista2.ToArray());
	aaa.AddRange(lista3.ToArray());
	
	foreach (IDTO element in aaa)
	{
		DTO3 dTO3 = element as DTO3;
		
		string desc = String.Empty;
		if (dTO3 != null)
			desc = dTO3.Desc;
		
		String.Join(", ", new object[] 
		{
			element.Codigo1, 
			element.Codigo2, 
			element.Codigo3,
			desc			
		}).Dump();
	}
}

public int Teste<T>(List<T> lista)  where T : IDTO
{
	return 0;
}

public class DTO1 : DataTransferObject, IDTO
{
    int _codigo1;
    int _codigo2;
    int _codigo3;

	public int Codigo4{get;set;}
	public int Codigo5{get;set;}
	public int Codigo6{get;set;}
	
    public int Codigo1
    {
        get { return _codigo1; }
        set { _codigo1 = value; }
    }        

    public int Codigo2
    {
        get { return _codigo2; }
        set { _codigo2 = value; }
    }
    
    public int Codigo3
    {
        get { return _codigo3; }
        set { _codigo3 = value; }
    }
}

public class DTO2 : DataTransferObject, IDTO
{
    int _codigo1;
    int _codigo2;
    int _codigo3;

    public int Codigo1
    {
        get { return _codigo1; }
        set { _codigo1 = value; }
    }

    public int Codigo2
    {
        get { return _codigo2; }
        set { _codigo2 = value; }
    }

    public int Codigo3
    {
        get { return _codigo3; }
        set { _codigo3 = value; }
    }
}

public class DTO3 : DataTransferObject, IDTO
{
    int _codigo1;
    int _codigo2;
    int _codigo3;

	public string Desc {get;set;}
	
    public int Codigo1
    {
        get { return _codigo1; }
        set { _codigo1 = value; }
    }

    public int Codigo2
    {
        get { return _codigo2; }
        set { _codigo2 = value; }
    }

    public int Codigo3
    {
        get { return _codigo3; }
        set { _codigo3 = value; }
    }
}

public interface IDTO
{
    int Codigo1 { get; set; }
    int Codigo2 { get; set; }
    int Codigo3 { get; set; }
}

public class DataTransferObject : ICloneable
{

    public object Clone()
    {
        return null;
    }
}
