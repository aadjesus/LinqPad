<Query Kind="Program" />

void Main()
{
	var (y: int, m: int, d: int ) aaa = DateTime.Now;
	aaa.Dump();
	
}

// https://www.youtube.com/watch?v=h9yYRwfzUXo
public static class Util
{
	//c# 7
	public static void Deconstruct(this DateTime valor, out int year,out int moth,out int day)
	{
		year = valor.Year;
		moth = valor.Month;
		day = valor.Day;
	}
}

public class Example
    {
        public static void Main()
        {
            var result = QueryCityData("New York City");

            var city = result.Item1;
            var pop = result.Item2;
            var size = result.Item3;

            // Do something with the data.
        }

        private static (string, int, double) QueryCityData(string name)
        {
            if (name == "New York City")
                return (name, 8175133, 468.48);

            return ("", 0, 0);
        }
    }





