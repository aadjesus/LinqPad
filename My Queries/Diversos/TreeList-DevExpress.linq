<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <GACReference>DevExpress.Data.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.Design.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.Printing.v11.2.Core, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.Projects.v11.2.Installers, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.Utils.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.Win.Projects.v11.2.Design, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.XtraEditors.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.XtraEditors.v11.2.Design, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.XtraPrinting.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.XtraPrinting.v11.2.Design, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.XtraTreeList.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <GACReference>DevExpress.XtraTreeList.v11.2.Design, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</GACReference>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>DevExpress.XtraEditors.Repository</Namespace>
</Query>

void Main()
{

	List<Teste> lista = new List<Teste>();
	lista.Add(new Teste() { Codigo = "1", ParentCodigo = "0"});
	lista.Add(new Teste() { Codigo = "2", ParentCodigo = "1"});
	lista.Add(new Teste() { Codigo = "3", ParentCodigo = "2"});
	lista.Add(new Teste() { Codigo = "4", ParentCodigo = "1"});
	lista.Add(new Teste() { Codigo = "5", ParentCodigo = "3"});
	lista.Add(new Teste() { Codigo = "6", ParentCodigo = "1"});

	lista.Add(new Teste() { Codigo = "10", ParentCodigo = "00"});
	lista.Add(new Teste() { Codigo = "20", ParentCodigo = "10"});
	lista.Add(new Teste() { Codigo = "30", ParentCodigo = "20"});
	lista.Add(new Teste() { Codigo = "40", ParentCodigo = "10"});
	lista.Add(new Teste() { Codigo = "50", ParentCodigo = "30"});
	lista.Add(new Teste() { Codigo = "60", ParentCodigo = "10"});
		
	DevExpress.XtraTreeList.TreeList treeList = new DevExpress.XtraTreeList.TreeList()
	{
		Dock = DockStyle.Fill,	
		KeyFieldName = "Codigo",
		ParentFieldName = "ParentCodigo"		
	};	
	treeList.DataSource = lista;	
	treeList.OptionsBehavior.EnableFiltering = true;
    treeList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
    treeList.OptionsMenu.EnableFooterMenu = false;
    treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
	treeList.OptionsBehavior.Editable = false;
    
	treeList.OptionsView.ShowAutoFilterRow = true;
    //treeList.OptionsView.ShowColumns = false;
    treeList.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
    treeList.OptionsView.ShowFocusedFrame = false;
    treeList.OptionsView.ShowHorzLines = false;
    treeList.OptionsView.ShowIndicator = false;
    treeList.OptionsView.ShowSummaryFooter = true;
    treeList.OptionsView.ShowVertLines = false;
	treeList.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
	
	treeList.Columns.AddRange(
		new DevExpress.XtraTreeList.Columns.TreeListColumn[] 
		{
    		new DevExpress.XtraTreeList.Columns.TreeListColumn() {FieldName ="Codigo", Caption =  "Codigo", Visible = true, VisibleIndex = 0},
    		new DevExpress.XtraTreeList.Columns.TreeListColumn() {FieldName ="ParentCodigo" , Visible = true, VisibleIndex = 1}
		});		
	
	Form  form = new Form()
	{
	 	Size = new Size(500,500)
	};
	
	form.Controls.Add(treeList);
	form.ShowDialog();

}

public class Teste
{
	public string Codigo {get;set;}
	public string ParentCodigo {get;set;}
}