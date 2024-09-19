<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var qtde  = 0;
		 Task.Run(() =>
            {
                while (true)
                {
                    var valor = (qtde++) % 4;

                    Console.Write(valor == 0 ? "/" : valor == 1 ? "-" : valor == 2 ? "\\" : "|");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Thread.Sleep(50);
                }

            });
            Task.Yield();
}

// Define other methods and classes here
