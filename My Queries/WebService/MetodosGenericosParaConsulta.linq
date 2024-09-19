<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Excecao.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
  <Namespace>FGlobus.Componentes.WinForms.ws.controle</Namespace>
  <Namespace>Globus5.WPF.Comum</Namespace>
  <Namespace>System.Web.Services.Protocols</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{	
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");	
	
	#region Retornar todos
	
	var genericoRetornarTodos = WebServices.ControleWSApp.GenericoRetornarTodos<MenuDTO>()
		.OrderBy(o => o.Sistema)
		.Dump("Retornar todos")
		;
	
	// Pega o sistema com menos itens / Agrupa, conta, ordena e pega o 1º
	MenuDTO primeriroMenu = genericoRetornarTodos
		.GroupBy(g=> g.Sistema, (key,lista) => new { b=lista.Count(), c=lista.First()})
		.OrderBy(o=> o.b)
		.First().c;
		
	#endregion	
	
	#region Consulta por chave
	
	WebServices.ControleWSApp.GenericoConsultaPorChave<MenuDTO>(primeriroMenu)
		.Dump("Consulta por chave = (" + String.Concat("Sistema = ",primeriroMenu.Sistema,") e (IndiceMenu = ",primeriroMenu.IndiceMenu,") e (Nome = ",primeriroMenu.Nome ,")") );
	
	#endregion

	#region Consulta por condição
	
	List<sCondicaoAdicionalCriteria> condicoes = new List<sCondicaoAdicionalCriteria>();
	foreach (eOperador element in Enum.GetValues(typeof(eOperador)))
	{
		object valor = primeriroMenu.Sistema;
		if (element ==  eOperador.Contido)
			valor = new string[] {primeriroMenu.Sistema};
			
		sCondicaoAdicionalCriteria condicao = new sCondicaoAdicionalCriteria()
		{	
			Propriedade = "Sistema", 
			Operador = element, 
			Valor = valor,
			ValorInicial = (element == eOperador.Entre ? primeriroMenu.Sistema : null),
			ValorFinal = (element == eOperador.Entre ? primeriroMenu.Sistema : null)
		};
		condicoes.Add(condicao);
		WebServices.ControleWSApp.GenericoConsultaBasica<MenuDTO>(condicao)
			.Dump("Consulta por condição = " + String.Concat(
				"(",condicao.Propriedade
				," ",condicao.Operador
				," ", (condicao.Operador == eOperador.Contido 
							? ((string[])condicao.Valor).Aggregate((a1,b1)=> a1 + ", " + b1) 
							: (condicao.Operador == eOperador.Entre 
								? String.Concat(condicao.ValorInicial," e ", condicao.ValorFinal) 
								:  condicao.Valor) ),")") );		
	}
	
	#endregion
		
	#region Consulta por condições

	WebServices.ControleWSApp.GenericoConsultaBasica<MenuDTO>(condicoes
		.Where(w=> w.Operador != eOperador.Diferente)
		.ToArray())
		.Dump("Consulta por condições = " + 
		condicoes.Aggregate(
			String.Empty,
			(a,b) => 
			a + String.Concat("(", b.Propriedade
							 ," ", b.Operador
							 ," ", (b.Operador == eOperador.Contido 
							 		? ((string[])b.Valor).Aggregate((a1,b1)=> a1 + ", " + b1) 
									: (b.Operador == eOperador.Entre 
										? String.Concat(b.ValorInicial," e ", b.ValorFinal) 
										: b.Valor) )									
							 ,")", (b.Equals(condicoes.Last()) ? "" : " e ") )   ) );	
	
	#endregion
	
	#region Consulta por condições dos campos
	
	WebServices.ControleWSApp.GenericoConsultaBasicaDosCampos<MenuDTO>(new sCondicaoAdicionalCriteria()
	{	
		Propriedade = "Sistema", 
		Operador = eOperador.Igual,
		Valor = primeriroMenu.Sistema
	}
	,new string[] {"Caption","Sistema"})
	.Dump("Consulta por condição dos campos = " + 
		condicoes.Aggregate(
			String.Empty,
			(a,b) => 
			a + String.Concat("(", b.Propriedade
							 ," ", b.Operador
							 ," ", (b.Operador == eOperador.Contido 
							 		? ((string[])b.Valor).Aggregate((a1,b1)=> a1 + ", " + b1) 
									: (b.Operador == eOperador.Entre 
										? String.Concat(b.ValorInicial," e ", b.ValorFinal) 
										: b.Valor) )									
							 ,")", (b.Equals(condicoes.Last()) ? "" : " e ") )   ) );	
	
	#endregion
	
}