<Query Kind="Program" />

void Main()
{
	Func<string,string> funcTemplete = 
		arquivo=>
		{
			string texto;
    		using (var streamReader = new StreamReader(arquivo, Encoding.UTF8))
    			texto = streamReader.ReadToEnd();
			return texto;
		};
	
	var file1 = @"c:\Users\alessandro.augusto\Box Sync\Aplicativos\LinqPad\Exemplos\a2_Substituir_valores_template.linq1.html";
	var texto1 = funcTemplete(file1);
	var texto2 = funcTemplete(file1.Replace("1","2"));
	var texto3 = funcTemplete(file1.Replace("1","3"));
	
	var linkUrlImg              = "1linkUrlImg"; 
	var UsuarioResponsavelNome  = "2UsuarioResponsavelNome";
	var ProdutoCodigoOriginal   = "3ProdutoCodigoOriginal";
	var ProdutoDescricao        = "4ProdutoDescricao";
	var MarcaDescricao          = "5MarcaDescricao";
	var PrecoPadraoAntigo       = "6PrecoPadraoAntigo";
	var PrecoPadraoAtual        = "7PrecoPadraoAtual";
	
	Util.Substituir(
		ref texto1,
		Tuple.Create("%linkUrlImg%",							 linkUrlImg),
		Tuple.Create("%UsuarioResponsavel.Nome%",			     UsuarioResponsavelNome),
		Tuple.Create("%Produto.CodigoOriginal%",				 ProdutoCodigoOriginal),
		Tuple.Create("%Produto.Descricao%",						 ProdutoDescricao),
		Tuple.Create("%Marca.Descricao%",                        MarcaDescricao),
		Tuple.Create("%CatalogoProdutoMarca.PrecoPadraoAntigo%", PrecoPadraoAntigo),
		Tuple.Create("%CatalogoProdutoMarca.PrecoPadraoAtual%",  PrecoPadraoAtual));
	
	Util.Substituir(
		ref texto2,
		Tuple.Create("%linkUrlImg%",linkUrlImg),
		UsuarioResponsavelNome,
		ProdutoCodigoOriginal ,
		ProdutoDescricao,      
		MarcaDescricao  ,      
		PrecoPadraoAntigo,     
		PrecoPadraoAtual);			
	
	Util.Substituir(
		ref texto3,
		Tuple.Create("%TAG1%", linkUrlImg),
		Tuple.Create("%TAG2%", UsuarioResponsavelNome),
		Tuple.Create("%TAG3%", ProdutoCodigoOriginal),
		Tuple.Create("%TAG4%", ProdutoDescricao),
		Tuple.Create("%TAG5%", MarcaDescricao),
		Tuple.Create("%TAG6%", PrecoPadraoAntigo),
		Tuple.Create("%TAG7%", PrecoPadraoAtual)
		);		
	
	var x1 = new List<Tuple<string,string, string>>();		
	Func<string, string, string> func1 = 
		(texto,tag) => texto.Substring(texto.IndexOf(tag)-10,100);
	
	x1.Add(Tuple.Create(func1(texto1,linkUrlImg),            func1(texto2,linkUrlImg),              func1(texto3,linkUrlImg)));
	x1.Add(Tuple.Create(func1(texto1,UsuarioResponsavelNome),func1(texto2,UsuarioResponsavelNome),  func1(texto3,UsuarioResponsavelNome)));
	x1.Add(Tuple.Create(func1(texto1,ProdutoCodigoOriginal), func1(texto2,ProdutoCodigoOriginal),   func1(texto3,ProdutoCodigoOriginal)));
	x1.Add(Tuple.Create(func1(texto1,ProdutoDescricao),		 func1(texto2,ProdutoDescricao),		func1(texto3,ProdutoDescricao)));
	x1.Add(Tuple.Create(func1(texto1,MarcaDescricao),		 func1(texto2,MarcaDescricao),			func1(texto3,MarcaDescricao)));
	x1.Add(Tuple.Create(func1(texto1,PrecoPadraoAntigo),	 func1(texto2,PrecoPadraoAntigo),		func1(texto3,PrecoPadraoAntigo)));
	x1.Add(Tuple.Create(func1(texto1,PrecoPadraoAtual),		 func1(texto2,PrecoPadraoAtual),		func1(texto3,PrecoPadraoAtual)));	
	
	x1.Dump().Select(s=> s.Item1 == s.Item2 && s.Item1 == s.Item3).Any(a=>a).Dump();	
}

public static class Util
{
	public static void Substituir(
		ref string template,
		params object[] valores)
	{	
		var retorno = template;
		Func<int> funcIndexOf = () =>
        	retorno.IndexOf("%TAG%" , StringComparison.CurrentCulture);	
		
		foreach (var element in valores)
		{
			var tuple = element as Tuple<string,string>;
			if (tuple == null)
			{
				var posIni = funcIndexOf();
				if (posIni == -1)
					continue;
					
				retorno = retorno
					.Remove(posIni, 5)
					.Insert(posIni, element.ToString());
			}
			else
			{
				retorno = retorno.Replace(tuple.Item1,tuple.Item2);
			}
		}
			
		template = retorno;
	}
}