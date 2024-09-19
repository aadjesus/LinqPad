<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
  </Connection>
  <Namespace>System.Net</Namespace>
</Query>

static void Main()
{
	Stopwatch stopwatch = new Stopwatch();
	stopwatch.Start();
	
    // Retrieve Darwin's "Origin of the Species" from Gutenberg.org.
    string[] words = CreateWordArray(@"http://www.gutenberg.org/files/2009/2009.txt");

    // Perform three tasks in parallel on the source array
                         Console.WriteLine("Begin first task...");
                         GetLongestWord(words);

						 Console.WriteLine("Begin second task...");
                         GetMostCommonWords(words);

						 Console.WriteLine("Begin third task...");
                         GetCountForWord(words, "species");

    Console.WriteLine("Returned from Parallel.Invoke");
    Console.WriteLine("Press any key to exit");    
	
	stopwatch.Stop();	
	stopwatch.Dump();
}

private static void GetCountForWord(string[] words, string term)
{
    var findWord = from word in words
                   where word.ToUpper().Contains(term.ToUpper())
                   select word;

    Console.WriteLine(@"Task 3 -- The word ""{0}"" occurs {1} times.",
        term, findWord.Count());
}

private static void GetMostCommonWords(string[] words)
{
    var frequencyOrder = from word in words
                         where word.Length > 6
                         group word by word into g
                         orderby g.Count() descending
                         select g.Key;

    var commonWords = frequencyOrder.Take(10);

    StringBuilder sb = new StringBuilder();
    sb.AppendLine("Task 2 -- The most common words are:");
    foreach (var v in commonWords)
    {
        sb.AppendLine("  " + v);
    }
    Console.WriteLine(sb.ToString());
}

private static string GetLongestWord(string[] words)
{
    var longestWord = (from w in words
                       orderby w.Length descending
                       select w).First();

    Console.WriteLine("Task 1 -- The longest word is {0}", longestWord);
    return longestWord;
}


// An http request performed synchronously for simplicity.
static string[] CreateWordArray(string uri)
{
    Console.WriteLine("Retrieving from {0}", uri);

    // Download a web page the easy way.
    string s = new WebClient().DownloadString(uri);

    // Separate string into an array of words, removing some common punctuation.
    return s.Split(
        new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' },
        StringSplitOptions.RemoveEmptyEntries);
}
