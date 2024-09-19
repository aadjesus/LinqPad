<Query Kind="Program" />

void Main()
{
    Enumerable.Range(32, 95)
        .Select(s => new
        {
            Binário = '0' + Convert.ToString(Convert.ToInt32((char)s), 2),
            Decimal = s,
            Hexa = System.Text.Encoding.ASCII.GetBytes(((char)s).ToString()),
            Glifo = (char)s
        })
		.Dump();
}