<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{	
	foreach (var senha in new [] {"Prx@123","Isa123!@#$"})
	{
		CriptografaSenhaGlobus(senha,10,false).Dump();
		Criptografar(senha,10,true,false).Dump();		
	}
	
}

public static string CriptografaSenhaGlobus(string texto, byte quantidadePosicoes, bool criptografiaAntiga)
{
    if (texto.Length == 0)
        return string.Empty;

    int numAuxiliar = 0;
    string convertido;

    for (int contador = 0; contador < texto.Length; contador++)
        numAuxiliar += ((int)Convert.ToChar(texto[contador])) * (contador + 1);

    convertido = Convert.ToString((double)numAuxiliar / 357);
    convertido = convertido.Substring(0, Math.Min(quantidadePosicoes, convertido.Length));

    string resultado = string.Empty;

    for (int contador = 0; contador < convertido.Length; contador++)
    {
        if (convertido.Substring(contador, 1) == ",")
            resultado += '.';
        else
            resultado += convertido.Substring(contador, 1);
    }

    return resultado;
}

public static string Criptografar(string texto, byte quantidadePosicoes, bool posicional = false, bool senhaAntiga = false)
{
    var numAuxiliar = 0;

    if  (senhaAntiga)
    // Adiciona 32 ao código ASCII de cada caracter da string e acumula seus respectivos códigos em um somador
      numAuxiliar = texto.ToUpper(new CultureInfo("en-US"))
        .Select((s, index) => posicional
                    ? s * (index + 1)
                    : s + 32)
        .Sum(s => s);
	else
	  numAuxiliar = texto
        .Select((s, index) =>  s * (index + 1))
        .Sum(s => s);
	
    // Retorna as 10 primeiras posições do resultado da divisão do somador por 357
    var convertido = Convert.ToString((double)numAuxiliar / 357);
    convertido = convertido.Substring(0, Math.Min(quantidadePosicoes, convertido.Length))
        .Replace(",", ".");

    return convertido;
}