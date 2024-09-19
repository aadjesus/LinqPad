<Query Kind="Program">
  <Namespace>Microsoft.CSharp</Namespace>
  <Namespace>System.CodeDom.Compiler</Namespace>
</Query>

void Main()
{
	var csc = new CSharpCodeProvider();
        var parameters = new CompilerParameters(
			new[] {"mscorlib.dll", "System.Core.dll"}, "teste.exe", true)
            {
                GenerateExecutable = true
            };
			
        var compiledAssembly = csc.CompileAssemblyFromSource(
			parameters, 
			@"using System;
			
			class Program 
			{
				public static void Main() 
				{
					Console.WriteLine(""Hello world."");
				}
			}");

        var errors = compiledAssembly.Errors
			.Cast<CompilerError>()
			.ToList();

        if (errors.Any())
        {
            errors.ForEach(Console.WriteLine);
            return;
        }

        var module = compiledAssembly.CompiledAssembly.GetModules().FirstOrDefault();		

        Type mt = null;
        if (module != null)
            mt = module.GetType("Program");

        MethodInfo methInfo = null;
        if (mt != null)
            methInfo = mt.GetMethod("Main");

        if (methInfo != null)
            Console.WriteLine(methInfo.Invoke(null, null));
	
}