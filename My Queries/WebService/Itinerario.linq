<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
  </Connection>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>Globus5.WPF.Comum</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");	
	
	string[] diasDaSemana = new string[] {"Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sabado" };
	
	var aa = Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarItinerarioDiasPorLinha(1207)
		.Aggregate(new Dictionary<int,string>(),(lista,item)=>
		{	
			var itinerario = lista.Where(w => w.Key.Equals(item.IdItinerario)).SingleOrDefault();
			string dia = diasDaSemana[item.Dia-1];
			if (itinerario.Key != 0)
			{
			 	lista.Remove(itinerario.Key);
				dia = itinerario.Value +", "+ dia;
			}
		
			lista.Add(item.IdItinerario,dia);
				
			return lista;
		})
		.OrderBy(o=> o.Key).Dump("1")	
		.Join(Globus5.WPF.Comum.WebServices.GestaoDeFrotaOnLineWSApp.RetornarItinerariosPorCodigoInternoDaLinha(1207),
				a=> a.Key,
				b=> b.IdItinerario,
				(a,b) => new 
				{
					b.CodIntLinha,
					b.Ativo,
					b.IdItinerario,
					b.VigenciaInicial,
					a.Value
				})	
		.ToArray()
		.Dump("2");


var dic = aa[1].GetType()
			 .GetProperties()
			 .ToDictionary(a=> a.Name, a=> a.GetValue(aa[1],null)).Dump(1);	
	
}

// Define other methods and classes here