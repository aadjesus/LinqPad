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
	var calculadoraDeSalario  = new CalculadoraDeSalario();	
	
	Console.WriteLine(calculadoraDeSalario
		.Calcula(new Funcionario(new Desenvolvedor(new DezOuVintePorcento()),2000)));
	
	Console.WriteLine(calculadoraDeSalario
		.Calcula(new Funcionario(new Dba(new QuinzeOuVinteCincoPorcento()),2000)));
}

public class CalculadoraDeSalario
    {
        public double Calcula(Funcionario funcionario)
        {
			return funcionario.Calcular();
        }      
    }

public class QuinzeOuVinteCincoPorcento : IRegraDeCalcula
	{
		public double Calcular(Funcionario funcionario)
		{
			return funcionario.SalarioBase * ( funcionario.SalarioBase > 2000.0 
				? 0.75 
				: 0.85);
		}
	}
	
public class DezOuVintePorcento	: IRegraDeCalcula
	{
		public double Calcular(Funcionario funcionario)
		{
			return funcionario.SalarioBase * ( funcionario.SalarioBase > 3000.0 
				? 0.8 
				: 0.9);
		}		
	}
	
public interface IRegraDeCalcula
{
	double Calcular(Funcionario funcionario);
}

public abstract class Cargo
    {
		public IRegraDeCalcula Regra {get; private set;}
		public Cargo(IRegraDeCalcula regra)
		{
			this.Regra = regra;
		}
    }

public class Desenvolvedor : Cargo
	{
		public Desenvolvedor(IRegraDeCalcula regra): base(regra)
		{
			//*this.Regra = regra;
		}
	}
	
public class Dba : Cargo
	{
		public Dba(IRegraDeCalcula regra): base(regra)
		{
			//this.Regra = regra;
		}
	}
	
public class Tester : Cargo
	{
		public Tester(IRegraDeCalcula regra): base(regra)
		{
			//this.Regra = regra;
		}	
	}	

public class Funcionario
    {

        public Cargo Cargo { get; private set; }

        public double SalarioBase { get; private set; }

        public Funcionario(Cargo cargo, double salarioBase)
        {
            this.Cargo = cargo;
            this.SalarioBase = salarioBase;
        }
		
		public double Calcular()
		{
			return this.Cargo.Regra.Calcular(this);
		}

    }