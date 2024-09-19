<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
</Query>

void Main()
{
    TimeSpan _timeSpan = DateTime.Now.TimeOfDay;
	
	Thread.Sleep(1000);		
	
	TimeSpan timeSpan = Msg("a");	
	
	Thread.Sleep(1000);
	
	timeSpan += Msg("a");	
	
	Thread.Sleep(1000);
	
	_timeSpan = DateTime.Now.TimeOfDay.Subtract(_timeSpan+timeSpan);
	_timeSpan.Dump();
	
}

public static TimeSpan  Msg(string msg)
{
	TimeSpan timeSpan = DateTime.Now.TimeOfDay;			
	System.Windows.Forms.MessageBox.Show("ok");
	timeSpan = DateTime.Now.TimeOfDay.Subtract(timeSpan);
	
	return timeSpan;
}
