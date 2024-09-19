<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	BackgroundWorker backgroundWorker = new BackgroundWorker();
    backgroundWorker.WorkerReportsProgress = true;
    backgroundWorker.WorkerSupportsCancellation = true;
    backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
    backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
    backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);

    backgroundWorker.RunWorkerAsync();
}

void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
{
	Console.WriteLine("ProgressChanged");
}

void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
    Console.WriteLine("RunWorkerCompleted");
}

void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
{			
	(sender as BackgroundWorker).ReportProgress(3);
	Console.WriteLine("DoWork");
}