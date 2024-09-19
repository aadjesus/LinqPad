<Query Kind="Program" />

void Main()
{
	List<Cadastro> listaCadastro = new List<Cadastro>();
	listaCadastro.Add(new Cadastro(){ Codigo = 1, Data = DateTime.Now.AddDays(1), Descricao= "a"});
	listaCadastro.Add(new Cadastro(){ Codigo = 2, Data = DateTime.Now.AddDays(2), Descricao= "b"});
	listaCadastro.Add(new Cadastro(){ Codigo = 3, Data = DateTime.Now.AddDays(3), Descricao= "c"});
	listaCadastro.Add(new Cadastro(){ Codigo = 4, Data = DateTime.Now.AddDays(3), Descricao= "d"});
	
	List<Associados> listaAssociados = new List<Associados>();
	listaAssociados.Add(new Associados() { Codigo = 1, CodigoCadastro =1});
	listaAssociados.Add(new Associados() { Codigo = 1, CodigoCadastro =2});
	listaAssociados.Add(new Associados() { Codigo = 2, CodigoCadastro =3});
	listaAssociados.Add(new Associados() { Codigo = 3, CodigoCadastro =1});
	listaAssociados.Add(new Associados() { Codigo = 3, CodigoCadastro =2});
	listaAssociados.Add(new Associados() { Codigo = 3, CodigoCadastro =3});
	
	List<ColunaAutorizaBGM> _colunas = new List<ColunaAutorizaBGM>();	
	_colunas.Add(new ColunaAutorizaBGM() { FieldName="Codigo", FieldNameAssociado="CodigoCadastro"} );
	_colunas.Add(new ColunaAutorizaBGM() { FieldName="Descricao" } );
	
	 Func<object, string, string> funcCamposAssociados =
        (dataRow, campo) => String.Join("_", _colunas
        	.OfType<ColunaAutorizaBGM>()
            .Where(w => !String.IsNullOrEmpty(w.FieldNameAssociado))
            .Aggregate(new List<object>(), (retorno, item) =>
            {
				var x1 = dataRow.GetType().GetProperty(campo );
            	retorno.Add(x1.GetValue(dataRow,null));
                return retorno;
            })
            .ToArray());
	
	listaCadastro
		.Where(w=> listaAssociados
						.Select(s=> funcCamposAssociados(s,"Codigo"))
						.Contains( funcCamposAssociados(w,"Codigo"))  ).Dump();

}

private class ColunaAutorizaBGM
{
	public string FieldNameAssociado{get;set;}
	public string FieldName{get;set;}
}

private class Cadastro
{
	public int Codigo{get;set;}
	public string Descricao{get;set;}
	public DateTime Data{get;set;}
}

private class Associados
{
	public int Codigo{get;set;}
	public int CodigoCadastro{get;set;}
}