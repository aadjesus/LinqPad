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
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>FGlobus.Util</Namespace>
  <Namespace>Globus5.WPF.Comum</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.manutencao</Namespace>
  <Namespace>System.Web.Services.Protocols</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{	
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");	
	
    var _listaVeiculoDTO = WebServices.FrotaWSApp.RetornarTodosVeiculosDaEmpresaFilial(1,1)
	 	.Where(w => !w.CondicaoVeic.Equals("V"));
	
	var _listaKmRevisaoDTO = WebServices.ManutencaoWSApp.GenericoConsultaBasica<KmRevisaoDTO>(
                    new Globus5.WPF.Comum.ws.manutencao.sCondicaoAdicionalCriteria()
                    {
                        Operador = eOperador.Igual,
                        Propriedade = "CodigoPlanoRevisao",
                        Valor = 1
                    })
                    .ToList();	
	
	List<PrefixoEscalaManualDTO> _listaDispoPrefixoEscalaManualDTO = new List<PrefixoEscalaManualDTO>();
					
	_listaDispoPrefixoEscalaManualDTO.AddRange(_listaKmRevisaoDTO
                        .Join(_listaVeiculoDTO,
                                a => a.CodigoPlanoRevisao,
                                b => b.CodGrpRev,
                                (a, b) => new
                                {
                                    a,
                                    b
                                })
                        //.Where(w => !_listaAssociadasVeiculoDTO.Contido(p => p.CodigoVeiculo, w.b.CodigoVeic))
                        .Select(s => new Globus5.WPF.Comum.ws.manutencao.PrefixoEscalaManualDTO()
                        {
                            CodigoVeiculo = s.b.CodigoVeic,
                            CodigoPlanoRevisao = 1,
                            CodigoInterno = s.a.CodigoGrupoRevisao,
                        }));

	
}