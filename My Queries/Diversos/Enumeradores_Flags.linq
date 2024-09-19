<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Excecao.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Mensagens.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WebReferences\WebReferences\Distribuicao\BgmRodotec.Globus5.WebReferences.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <GACReference>DevExpress.Utils.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <Namespace>FGlobus.Componentes.WinForms</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <Namespace>FGlobus.Util.ExtensaoBoolean</Namespace>
  <Namespace>FGlobus.Util.ExtensaoDateTime</Namespace>
  <Namespace>FGlobus.Util.ExtensaoDTO</Namespace>
  <Namespace>FGlobus.Util.ExtensaoEnum</Namespace>
  <Namespace>FGlobus.Util.ExtensaoException</Namespace>
  <Namespace>FGlobus.Util.ExtensaoImagens</Namespace>
  <Namespace>FGlobus.Util.ExtensaoLinq</Namespace>
  <Namespace>FGlobus.Util.ExtensaoObject</Namespace>
  <Namespace>FGlobus.Util.ExtensaoString</Namespace>
  <Namespace>FGlobus.Util.ExtensaoValoresFlutuante</Namespace>
  <Namespace>FGlobus.Util.ExtensaoWeb</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	Xisto(eFoo1.a | eFoo1.b);
	Xisto(eFoo2.a | eFoo2.b);
	Xisto(eFoo3.a | eFoo3.b);
}

static void Xisto(Enum foo1)
{
	foo1.ToString().Dump();
}

[Flags]
enum eFoo1
{
	a,
	b,
	c,
	d	
}

[Flags]
enum eFoo2
{
	a=1 << 0,
	b=1 << 1,
	c=1 << 2,
	d=1 << 3
}	

[Flags]
enum eFoo3
{
	a=1,
	b=2,
	c=4,
	d=8
}	

