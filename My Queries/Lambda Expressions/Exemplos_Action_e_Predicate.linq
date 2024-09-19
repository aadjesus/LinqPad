<Query Kind="Program" />

void Main()
{	
	Action<object> action = a => Console.WriteLine(String.Concat(a.GetHashCode()," -> ", a));	
	Predicate<string> predicate = p => p.Length == 5;	
	
	action(predicate("12345"));
	action(predicate("1234"));
	
	Console.WriteLine("-------------");
	Func<int, int, bool> func = (a, b) => a.CompareTo(b) == 0;
	
	action(func(8, 8));	
	action(func(7, 8));	
	
	Console.WriteLine("-------------");
	
	Array.ForEach(new int[] { 1, 2, 3, 4, 5, 6 }, f => action(f));
}