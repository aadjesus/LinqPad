<Query Kind="Program" />

void Main()
{
	var cSharpCodeProvider = new Microsoft.CSharp.CSharpCodeProvider();
	
	var stringClasse = 
		@"public class NomeClass                   
		{
			public string NomeMetodo()
			{
				return ""retorno metodo"";
			}
			
			public NomeClass NomeMetodo1()
			{
				return new NomeClass();
			}
		}";
	
	var compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(
		new System.CodeDom.Compiler.CompilerParameters() 
		{
			GenerateInMemory = true 
		},
		stringClasse);

	var tipo = compilerResults.CompiledAssembly.GetType("NomeClass");

	var objeto = Activator.CreateInstance(tipo);

	var executa = tipo
		.GetMethod("NomeMetodo").Invoke(objeto, new object[] { });		
	executa.Dump();
	
	executa = tipo
		.GetMethod("NomeMetodo1")
		.Invoke(objeto, new object[] { });
	
	executa.Dump();
}

// Define other methods and classes here