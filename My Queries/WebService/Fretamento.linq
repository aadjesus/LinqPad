<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Excecao.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Mensagens.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WebReferences\WebReferences\Distribuicao\BgmRodotec.Globus5.WebReferences.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>FGlobus.Util</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.funcionario</Namespace>
  <Namespace>System.Web.Services.Protocols</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.fretamento</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{	
	Globus5.WebReferences.Util.CarregarConfigWebServices();
	Globus5.WebReferences.Util.EnderecoWebService.Dump();
	
	ContratoDTO[] contratos = WebServiceGenerico<ContratoDTO>.ConsultaBasica().ToArray();
	
	Globus5.WPF.Comum.ws.cliente.ClienteDTO[] _listaCliente = WebServiceGenerico<Globus5.WPF.Comum.ws.cliente.ClienteDTO>
		.CondicaoContido(c => c.CodCli, contratos.Select(s => s.CodigoCliente).Distinct().ToArray())
		.Consultar()
		.ToArray();			 
		
 	ContratoFuncionariosDTO[] funcao = WebServiceGenerico<ContratoFuncionariosDTO>
		.CondicaoContido(c => c.CodigoCliente, _listaCliente.Select(s => s.CodCli).ToArray())
        .Condicoes(c => c.Quantidade, 1, FGlobus.Comum.DAL.eOperador.MaiorOuIgual)
        .Consultar()
        .ToArray();
							
 	Globus5.WPF.Comum.ws.funcionario.FuncionarioDTO[] auxiliar = WebServiceGenerico<Globus5.WPF.Comum.ws.funcionario.FuncionarioDTO>
		.Condicao(c => c.Situacaofunc, "A")
        .CondicoesContido(c => c.Codfuncao, funcao.Select(s => s.CodigoFuncao).Distinct().ToArray())
        .Consultar()
        .ToArray();
		
	ContratoProgramacaoDTO[] listaServicos = Globus5.WPF.Comum.WebServices.FretamentoWSApp.RetornarProgramacaoServicosAtivosPorClientes(
		_listaCliente
			.Select(s => s.CodCli)
			.ToArray())
		.ToArray();
	
 	string[][] listaParametros = listaServicos
		.Select(s => new string[] 
        {
        	s.IdContrato.ToString(),
        	s.Codintlinha.ToString(),
            s.CodigoServico
		})
        .ToArray();
		
	string aa = String.Join(",",listaParametros
		.Select(s=> String.Concat("new string[] {\"",  s[0].ToString(),"\",\"", s[1].ToString(),"\",\"", s[2].ToString() ,"\"}" )));
	aa.Dump();
	
//	listaParametros
//		.GroupBy(g=> g[2])
//		.Select(s=> new 
//		{
//			a = s.Count(),
//			Lista = s
//		}).Dump();
	//EscalaPadraoServicosDTO[] listaEscalaPadrao = Globus5.WPF.Comum.WebServices.FretamentoWSApp.RetornarEscalaPadraoServico(listaParametros);		
	//listaEscalaPadrao.Dump();
		
}