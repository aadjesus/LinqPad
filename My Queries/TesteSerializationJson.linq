<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Entity.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>NServiceBus.Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

void Main()
{
	var teste =  @"{'codigogrpservi': 5,  'descricaogrpservi': 'xxxxxxxxxxxx', 'utilizacaogrpservi': 'F'}";	
	var x1 = JsonConvert.DeserializeObject<GrupoServicoVMI>(teste);
	
	x1.Dump();
}

[JsonConverter(typeof(ComplexTypeConverter))]
public class GrupoServicoVMI : IVMI
{
    [JsonProperty(PropertyName = "codigogrpservi")]
    public short Codigo { get; set; }
	
    [JsonProperty(PropertyName = "descricaogrpservi")]	
    public string Descricao { get; set; }
	
	[JsonIgnore]
	[JsonProperty(PropertyName = "utilizacaogrpservi")]
    public bool UtilizaNoFechamento { get; set; }
	
	public void PopularUtilizaNoFechamento(string valor)
	{
		UtilizaNoFechamento = "A_F".Contains(valor);		
	}	
	
	public Dictionary<Expression<Func<GrupoServicoVMI,object>>, Func<object>> Popular(string valor)
	{
		var x1 = new Dictionary<Expression<Func<GrupoServicoVMI,object>>, Func<object>>();		
		x1.Add(p=> p.UtilizaNoFechamento, () => "A_F".Contains(valor));				
		return x1;	
	}	
}

public interface IVMI : IVM
{
}

public interface IVM
{
}


public class ComplexTypeConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        throw new NotImplementedException();   
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
		var jObject = JObject.Load(reader);
		
		var retorno = Activator.CreateInstance(objectType) as GrupoServicoVMI;
    	serializer.Populate(jObject.CreateReader(), retorno);
		
		Func<PropertyInfo,JsonPropertyAttribute> funcJsonProperty = 
			propriedade => propriedade.GetCustomAttribute(typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;
		
		Predicate<PropertyInfo> predicate = 
			propriedade => 
			{	
				if (propriedade.GetCustomAttribute(typeof(JsonIgnoreAttribute)) == null )
					return false;
				
				var jsonProperty = funcJsonProperty(propriedade);	
			
				return jObject.Properties()
					.Any(a=> a.Name == jsonProperty.PropertyName);
			};		
		
//		var propriedades = retorno.GetType().GetProperties()
//			.Where(w=> predicate(w));
		
		foreach (var item in retorno.Popular("F"))
		{
			var x1 = (((item.Key.Body as UnaryExpression).Operand as System.Linq.Expressions.MemberExpression).Member as PropertyInfo);
			
			var xx1 = Convert.ChangeType( item.Value.Invoke(),x1.PropertyType);			
			retorno.GetType().GetProperty(x1.Name).SetValue(retorno, xx1 );
		}
		
//		foreach (var element in propriedades)
//		{
//			var metodo = retorno.GetType().GetMethod("Popular" + element.Name);			
//			if (metodo != null)
//				metodo.Invoke(
//					retorno, 
//					new object[] 
//					{ 
//						jObject[funcJsonProperty(element).PropertyName].ToString() 
//					});
//		}
		
		return retorno; 		
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
     	throw new NotImplementedException();   
    }
}