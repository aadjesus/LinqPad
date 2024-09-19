<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>c:\GlobusMais\Frameworks\Referencias\Castle.Core.dll</Reference>
  <Reference>c:\GlobusMais\Frameworks\Referencias\Castle.DynamicProxy.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\FGlobus.Controle.DTO.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\FGlobus.Seguranca.DTO.dll</Reference>
  <Reference>c:\GlobusMais\Classes\Distribuicao\GLB.DTO.dll</Reference>
  <Reference>c:\GlobusMais\Frameworks\Referencias\Iesi.Collections.dll</Reference>
  <Reference>c:\GlobusMais\Frameworks\Referencias\log4net.dll</Reference>
  <Reference>c:\GlobusMais\Frameworks\Referencias\NHibernate\NHibernate.dll</Reference>
  <Namespace>FGlobus.Comum</Namespace>
  <Namespace>FGlobus.Comum.DAL</Namespace>
  <Namespace>NHibernate</Namespace>
  <Namespace>NHibernate.Cfg</Namespace>
</Query>

void Main()
{
	ISession sessao = FGlobus.Comum.ChaveCRUD.ConectaLinqPad(@"c:\Servers\Globus5\Web.config");
	//ISession sessao = FGlobus.Comum.ChaveCRUD.ConectaLinqPad("ORA11G64","COMPORTE121126","COMPORTE121126");
	//ISession sessao = FGlobus.Comum.ChaveCRUD.ConectaLinqPad();
	
	ICriteria crit = sessao.CreateCriteria(typeof(FGlobus.Controle.DTO.SistemaDTO))	
		.Add(Expressao.Igual("Sistema","CGS"));
	
    IList<FGlobus.Controle.DTO.SistemaDTO> lista = crit.List<FGlobus.Controle.DTO.SistemaDTO>();		
	sessao.Close();	
	lista.Dump();	
}