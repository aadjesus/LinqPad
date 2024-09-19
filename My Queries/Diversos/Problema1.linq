<Query Kind="Program" />

void Main()
{
	// Faça um algoritmo que leia dois vetores (A e B) de 5 posições de números inteiros. O algoritmo deve subtrair o primeiro 
	// elemento de A do ultimo elemento de B e acumulando o valor. Em seguida deve subtrair o segundo elemento de A do penúltimo 
	// elemento de B, acumular o valor, e assim por diante. Mostre o resultado final da soma. 
	int[] listaA = new int[] {9,8,7,6,5};
	int[] listaB = new int[] {1,2,3,4,5};
	
	int c = 0;	
	for (int i = 0; i < listaA.Length; i++)
		c += listaA[i] - listaB[(listaA.Length-1)-i]; 
		
	c.Dump("Exemplo 1");
	
	listaA
		.Select((s,index) => s - listaB[(listaA.Length-1)-index])
		.Aggregate((a1,b1) => a1+b1).Dump("Exemplo 2");
}

// Define other methods and classes here
