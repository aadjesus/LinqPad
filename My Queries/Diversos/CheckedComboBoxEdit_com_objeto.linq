<Query Kind="Program">
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\Frameworks\FGlobus\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\DevExpress 2011.2\Components\Bin\Framework\DevExpress.XtraEditors.v11.2.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <GACReference>DevExpress.Utils.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <Namespace>DevExpress.XtraEditors</Namespace>
  <Namespace>DevExpress.XtraEditors.Controls</Namespace>
  <Namespace>FGlobus.Componentes.WinForms</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <Namespace>FGlobus.Util.ExtensaoLinq</Namespace>
  <Namespace>FGlobus.Util.ExtensaoObject</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

void Main()
{
	CheckedComboBoxEdit x1 = new CheckedComboBoxEdit()
	{
	  Left = 30,
	  Top = 30,
	  Width = 200
	};
            x1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("AcessaTodosMenus ", "Acessa todos os menus", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Administrador", "Administrador", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("DigitaLinhaNaManutencao", "Digita linha na manutenção", System.Windows.Forms.CheckState.Checked)});
	
	MyClass myClass = new MyClass(){ x2 = true};
	//x1.AdicionarItens<MyClass>(p => p.x1, true);
	//x1.AdicionarItens<MyClass>(p => new { p.x1, p.x2 }, false);
	//x1.AdicionarItens<MyClass>(p => new { p.x1, p.x2 }, myClass);
	//x1.AdicionarItens<MyClass>(p => p.x1, myClass);
	x1.AdicionarItens<MyClass>(myClass);
	Label  label = new Label()
	{
	 	Left = 30,
	 	Top = 15, Width = 30
	};
	Form form = new Form();
	form.Controls.Add(x1);
	form.Controls.Add(label);
	
	form.ShowDialog();
	
	x1.PopularObjeto(myClass);
	myClass.Dump();
	
	
	
	
}

class MyClass
{
	public bool x1 {get;set;}
    public bool x2 {get;set;}
}

public static class ExtensionMethods1
{

		public static void PopularObjeto(
            this CheckedComboBoxEdit controle,
			object valor)
		{
			controle.Properties.Items
				.OfType<CheckedListBoxItem>()
				.Where(w=> w.Value != null)
				.ForEach(f=> 
				{
					valor.PopularPropriedade(f.Value.ToString(), f.CheckState == CheckState.Checked);	
				});		
		}
			
	
 		private static void AdicionarItens<TSource>(
            this CheckedComboBoxEdit controle,
            IEnumerable<string> listaPropriedade,
            object objeto)
        {
            Func<string, bool> funcValor =
                propriedadeObjeto => (typeof(bool) == objeto.GetType()
                    ? objeto
                    : objeto.RetornarValorPropriedade(propriedadeObjeto)).Converter<bool>();
					
			controle.Properties.Items
				.OfType<CheckedListBoxItem>()
				.Where(w=> w.Value != null)
				.ForEach(f=> 
				{
					bool condicao = funcValor(f.Value.ToString()).Converter<bool>();					
					f.CheckState = condicao
						? CheckState.Checked
						: CheckState.Unchecked;
				});
        }

        
        public static void AdicionarItens<TSource>(
            this CheckedComboBoxEdit controle,
            System.Linq.Expressions.Expression<Func<TSource, object>> propriedade,
            bool valor)
        {
            controle.AdicionarItens<TSource>(
                propriedade.RetornarNomeDosCampos(),
                valor);
        }

//        public static void AdicionarItens<TSource>(
//            this CheckedComboBoxEdit controle,
//            System.Linq.Expressions.Expression<Func<TSource, object>> propriedade,
//            object valor)
//        {
//            controle.AdicionarItens<TSource>(
//                propriedade.RetornarNomeDosCampos(),
//                valor);
//        }
        
        public static void AdicionarItens<TSource>(
            this CheckedComboBoxEdit controle,
            System.Linq.Expressions.Expression<Func<TSource, bool>> propriedade,
            TSource valor)
        {
            controle.AdicionarItens<TSource>(
                propriedade.RetornarNomeDosCampos(),
                valor);
        }
		
        public static void AdicionarItens<TSource>(
            this CheckedComboBoxEdit controle,
            TSource valor)
        {
            controle.AdicionarItens<TSource>(
                valor.GetType().GetProperties()
                    .Where(w => w.PropertyType == typeof(bool))
                    .Select(s => s.Name),
                valor);
        }
}