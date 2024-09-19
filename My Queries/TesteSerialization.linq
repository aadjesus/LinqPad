<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WebReferences\WebReferences\Distribuicao\BgmRodotec.Globus5.WebReferences.dll</Reference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var lista = new List<Foo>();
	lista.Add(new Foo(){ CodGrpRev = 1, CodigoCategoriaVeic = 1, CodigoEmpresa=1, CodigoFl=1, CodigoGa=1, CodigoModCarroc=1, CodigoModChassi=1, CodigoTpFrota =1, CodigoTpVeic = 1, CodigoUf="1", CodigoVeic = 1});
	lista.Add(new Foo(){ CodGrpRev = 1, CodigoCategoriaVeic = 1, CodigoEmpresa=1, CodigoFl=1, CodigoGa=1, CodigoModCarroc=1, CodigoModChassi=1, CodigoTpFrota =1, CodigoTpVeic = 1, CodigoUf="1", CodigoVeic = 2});
	lista.Add(new Foo(){ CodGrpRev = 1, CodigoCategoriaVeic = 1, CodigoEmpresa=1, CodigoFl=1, CodigoGa=1, CodigoModCarroc=1, CodigoModChassi=1, CodigoTpFrota =1, CodigoTpVeic = 1, CodigoUf="1", CodigoVeic = 3});
	lista.Add(new Foo(){ CodGrpRev = 1, CodigoCategoriaVeic = 1, CodigoEmpresa=1, CodigoFl=1, CodigoGa=1, CodigoModCarroc=1, CodigoModChassi=1, CodigoTpFrota =1, CodigoTpVeic = 1, CodigoUf="1", CodigoVeic = 4});
	lista.Add(new Foo(){ CodGrpRev = 1, CodigoCategoriaVeic = 1, CodigoEmpresa=1, CodigoFl=1, CodigoGa=1, CodigoModCarroc=1, CodigoModChassi=1, CodigoTpFrota =1, CodigoTpVeic = 1, CodigoUf="1", CodigoVeic = 5});

	
	string json = JsonConvert.SerializeObject(lista).Dump();
	
	
	
	var listaVeiculoDTO = JsonConvert.DeserializeObject<List<Globus5.WPF.Comum.ws.veiculo.VeiculoDTO>>(json)
		.Dump();
		


}	

class Foo
{
	public Int32 CodigoVeic{get;set;} 
	public Int32 CodigoTpVeic{get;set;} 
	public Int32 CodigoGa{get;set;} 
	public String CodigoUf{get;set;} 
	public Int32 CodigoEmpresa{get;set;} 
	public Int32 CodigoFl{get;set;} 
	public Int32 CodigoCategoriaVeic{get;set;} 
	public Int32 CodGrpRev{get;set;} 
	public Int32 CodigoModCarroc{get;set;} 
	public Int32 CodigoModChassi{get;set;} 
	public Int32 CodigoTpFrota{get;set;} 

}


