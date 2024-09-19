<Query Kind="Program">
  <Namespace>System.Collections.ObjectModel</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var taskSortedSet = Task.Run(() =>
	{	
		var sortedSet = new SortedSet<Foo>();
		sortedSet.Add(new Foo(){ Id  = 2, Desc = "a 2"});
		sortedSet.Add(new Foo(){ Id  = 1, Desc = "a 1"});
		sortedSet.Add(new Foo(){ Id  = 1, Desc = "a 1"});
		sortedSet.Add(new Foo(){ Id  = 3, Desc = "a 3"});
		//sortedSet.Dump();	
		
		var stopwatch = new Stopwatch();
		stopwatch.Start();
		sortedSet.Any(a=> a.Desc == "a 3").Dump();
		stopwatch.Stop();
		stopwatch.Elapsed.Dump("sortedSet");
	});
	
	var taskHashSet = Task.Run(() =>
	{	
		var hashSet = new HashSet<Foo>();
		hashSet.Add(new Foo(){ Id  = 2, Desc = "a 2"});
		hashSet.Add(new Foo(){ Id  = 1, Desc = "a 1"});
		hashSet.Add(new Foo(){ Id  = 1, Desc = "a 1"});
		hashSet.Add(new Foo(){ Id  = 3, Desc = "a 3"});
		//hashSet.Dump();		
		
		var stopwatch = new Stopwatch();
		stopwatch.Start();
		hashSet.Any(a=> a.Desc == "a 3").Dump();
		stopwatch.Stop();
		stopwatch.Elapsed.Dump("hashSet");
	});
	
	var taskList = Task.Run(() =>
	{
		var list = new List<Foo>();
		list.Add(new Foo(){ Id  = 2, Desc = "a 2"});
		list.Add(new Foo(){ Id  = 1, Desc = "a 1"});
		list.Add(new Foo(){ Id  = 1, Desc = "a 1"});
		list.Add(new Foo(){ Id  = 3, Desc = "a 3"});
		//list.Dump();
		
		var stopwatch = new Stopwatch();
		stopwatch.Start();
		list.Any(a=> a.Desc == "a 3").Dump();
		stopwatch.Stop();
		stopwatch.Elapsed.Dump("list");	
	});
	
	var taskCollection = Task.Run(() =>
	{
		var collection = new Collection<Foo>();
		collection.Add(new Foo(){ Id  = 2, Desc = "a 2"});
		collection.Add(new Foo(){ Id  = 1, Desc = "a 1"});
		collection.Add(new Foo(){ Id  = 1, Desc = "a 1"});
		collection.Add(new Foo(){ Id  = 3, Desc = "a 3"});
		//collection.Dump();
		
		var stopwatch = new Stopwatch();
		stopwatch.Start();
		collection.Any(a=> a.Desc == "a 3").Dump();
		stopwatch.Stop();
		stopwatch.Elapsed.Dump("collection");
	});
	
	var taskDictionary = Task.Run(() =>
	{
		var dictionary = new Dictionary<int, Foo>();
		dictionary.Add(2,new Foo(){ Id  = 2, Desc = "a 2"});
		dictionary.Add(1,new Foo(){ Id  = 1, Desc = "a 1"});
		//dictionary.Add(1,new Foo(){ Id  = 1, Desc = "a 1"});
		dictionary.Add(3,new Foo(){ Id  = 3, Desc = "a 3"});
		
		var stopwatch = new Stopwatch();
		stopwatch.Start();
		dictionary.ContainsKey(3).Dump();
		stopwatch.Stop();
		stopwatch.Elapsed.Dump("dictionary");	
	});
	
	
	
	//Task.Yield();
	Task.WaitAll(taskSortedSet, taskHashSet, taskList, taskCollection, taskDictionary);
}

public class Foo : IComparable
{
	public int Id { get; set; }
	public string Desc { get; set; }
	
	public int CompareTo(object obj)
    {
	 	if (this.Id >  ((Foo)obj).Id) return -1;
        if (this.Id == ((Foo)obj).Id) return 0;
		
    	return 1;
	}
	
	public virtual bool Equals(Foo other)
    {
    	if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;

        return other.Id == Id;
	}
	
	public override int GetHashCode() 
	{
	 	return (Id.GetHashCode() * 397) ^ GetType().GetHashCode();
	}
	
	public override bool Equals(object obj) 
	{
       return Equals(obj as Foo);
	}
	
	
}