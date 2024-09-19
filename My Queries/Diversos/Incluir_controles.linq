<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationTypes.dll</Reference>
</Query>

void Main()
{
	PanelManager.DisplayControl(new System.Windows.Forms.Panel() ,"1");
///	PanelManager.DisplayControl(new System.Windows.Forms.Button() { Text = "2"},"1");

	PanelManager.StackWpfElement (new System.Windows.Controls.Label()  	 { Content = "Hello" }, "WPF Control Gallery");
	PanelManager.StackWpfElement (new System.Windows.Controls.Button() 	 { Content = "Click" }, "WPF Control Gallery");
	PanelManager.StackWpfElement (new System.Windows.Controls.Expander() { Header = "More"   }, "WPF Control Gallery");
	PanelManager.StackWpfElement (new System.Windows.Controls.GroupBox() { Header = "Data"   }, "WPF Control Gallery");
}

// Define other methods and classes here
