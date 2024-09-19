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
	
}

class GeradorDeNotaFiscal
    {
         private EnviadorDeEmail email;
         private NotaFiscalDao dao;

         public GeradorDeNotaFiscal(EnviadorDeEmail email, NotaFiscalDao dao) {
            this.email = email;
            this.dao = dao;
         }

        public NotaFiscal Gera(Fatura fatura) {

            double valor = fatura.ValorMensal;

            NotaFiscal nf = new NotaFiscal(valor, ImpostoSimplesSobreO(valor));

            email.EnviaEmail(nf);
            dao.Persiste(nf);

            return nf;
        }

        private double ImpostoSimplesSobreO(double valor) {
            return valor * 0.06;
        }
    }


 public class EnviadorDeEmail : IAcaoAposGerarNota
    {
        public void EnviaEmail(NotaFiscal nf)
        {
            Console.WriteLine("Enviando email");
        }
    }

 class NotaFiscalDao : IAcaoAposGerarNota
    {
        public void Persiste(NotaFiscal nf)
        {
            Console.WriteLine("Persistindo nota");
        }
    }
 class Fatura
    {
        public double ValorMensal { get; set; }
        public string Cliente { get; private set; }

        public Fatura(double valorMensal,string cliente)
        {
            this.ValorMensal = valorMensal;
            this.Cliente = cliente;
        }
    }

public class NotaFiscal
    {
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public double ValorLiquido
        {
            get
            {
                return this.ValorBruto - this.Impostos;
            }

        }

        public NotaFiscal(double valorBruto, double impostos)
        {
            // TODO: Complete member initialization
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
        }
    }
