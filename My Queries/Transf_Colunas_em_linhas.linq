<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.DataAnnotations.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.ComponentModel.DataAnnotations</Namespace>
</Query>

void Main()
{
	var parametrosTela = new ParametrosTelaTeste{ Codigo = 1, Descricao = "Descricao", Desconto = 100};	
	var parametro = new Parametro
	{
	 	Chave = "1",
		Conteudo = JsonConvert.SerializeObject(parametrosTela),
		Id = 1,
		Tipo = 1
	}; 		
	
	var parametrosTela2 = new ParametrosTelaTeste2{ Descricao1 = "Descricao", Desconto1 = 100};	
	var parametro2 = new Parametro
	{
	 	Chave = "1;2;3",
		Conteudo = JsonConvert.SerializeObject(parametrosTela2),
		Id = 2,
		Tipo = 1
	}; 		
	
	var retronoParametros = CriarRetronoParametro(parametro, parametro2);
	GravarParametro(retronoParametros);			
}

public static class MyExtensions
{
//	public void PopularLista<T>(this IParametro parametro)
//	{
//	
//	}
	
}

private void GravarParametro(List<RetornoParametro> retornoParametros) 
{
	foreach (var retornoParametro in retornoParametros)
	{
		var tipoObjeto = retornoParametro.GetType().Assembly.GetTypes()
			.FirstOrDefault(w=> w.GetCustomAttribute(typeof(MyAttribute),true) != null );	
			
		var instance = Activator.CreateInstance(tipoObjeto);                          		
		foreach (var element in retornoParametro.Propriedades)
		{
			try
			{	    
				instance.GetType().GetProperty(element.Name).SetValue(instance,element.Value);
			}
			catch {}			
		}
	
		var parametro = new Parametro
		{
			Chave = retornoParametro.Chave,
			Id = retornoParametro.Id,
			Tipo = retornoParametro.Tipo,
			Conteudo = JsonConvert.SerializeObject(instance)
		};		
		parametro.Dump();
		
	}
}


private List<RetornoParametro> CriarRetronoParametro(params Parametro[] parametros) 
{
	var listaX1 = typeof(Parametro).GetType().Assembly.GetTypes()
		.Where(w=> w.GetCustomAttribute(typeof(MyAttribute),true) != null ).Dump();	
		
	

	var listaRetornoParametro = new List<RetornoParametro>();
	foreach (var parametro in parametros)
	{
		var objeto = JsonConvert.DeserializeObject(parametro.Conteudo);			
		
		
		
		var tipo = objeto.GetType();
		var retorno = new RetornoParametro
		{	  
		  	Chave = parametro.Chave,
			Id = parametro.Id,
			Tipo = parametro.Tipo,
			Descricao = (tipo.GetCustomAttribute(typeof(MyAttribute),true) as MyAttribute).Descricao,
			Propriedades = tipo.GetProperties()
				.Aggregate(new List<Propriedade>(),(lista,item) =>
				{	
					var displayAttribute = item.GetCustomAttribute(typeof(DisplayAttribute),true);
					var display = displayAttribute == null
						? item.Name
						: (displayAttribute as DisplayAttribute).Name;
					
					lista.Add(new Propriedade
					{
						 Tipo = item.PropertyType.Name,
						 Name = item.Name,
						 Caption = display,
						 Value = item.GetValue(objeto)
					});
					return lista;
				})
		};	
		listaRetornoParametro.Add(retorno);
	}
	
	return listaRetornoParametro;
}


	public class RetornoParametro : Parametro
	{	
		public String Descricao { get; set; }	
		public List<Propriedade> Propriedades { get; set; }	
		[JsonIgnore]
		public override string Conteudo { get; set; }	
	}
	
	public class Propriedade
	{	
		public string Caption { get; set; }	
		public object Value { get; set; }
		public string Tipo { get; set; }
		public string Name { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Dictionary<int,string> Lista { get; set; }
	}
	
	public class Parametro
	{
		public virtual int Id { get; set; }   	
		public virtual string Chave { get; set; }   	
		public virtual int Tipo { get; set; }   
		public virtual string Conteudo { get; set; }   
	}
	
	public interface IParametro
	{
		
	}
	
	[MyAttribute(1, "Parametros tela teste")]
	public class ParametrosTelaTeste : IParametro
	{
		[Display(Name = "Código")]
		public int Codigo { get; set; }   
		
		[Display(Name = "Descrição" )]
		public string Descricao { get; set; }   
		
		public decimal Desconto { get; set; }   	
		
		[Display(Name = "Dias Para Entrega", GroupName = "Dias")]	
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int DiasParaEntrega { get; set; }
	}
	
	[MyAttribute(2, "Parametros tela teste 2")]
	public class ParametrosTelaTeste2 : IParametro
	{	
		[Display(Name = "Descrição" )]
		public string Descricao1 { get; set; }   
		
		public decimal Desconto1 { get; set; }   		
	}
	
	[System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
	public sealed class MyAttribute : Attribute
	{
		private readonly string _descricao;
		private readonly int _tipo;
		
		public MyAttribute(int tipo, string descricao)
		{
			_tipo = tipo;
			_descricao = descricao;
		}
	
		public string Descricao
		{
			get { return _descricao; }
		}
	
		public int NamedInt { get; set; }
	
		public int Tipo
		{
			get { return _tipo; }
		}
	}

