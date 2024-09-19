<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
  </Connection>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var dict1 = new Dictionary<int, string>();
    var dict2 = new Dictionary<int, string>();
        
	Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
		
        for (int i = 1; i < 1000000; i++)
        {
            Parallel.Invoke(
			() => dict1.Add(i, "Test" + i), 
			() => dict2.Add(i, "Test" + i)
			);
        }
		
	stopwatch.Stop();	
	stopwatch.Dump();
}
