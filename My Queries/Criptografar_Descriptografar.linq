<Query Kind="Program" />

void Main()
{
	var valor = "Teste";
	var valorCripto = Criptografar(valor);
	var valorDesCripto = Descriptografar(valorCripto);
	
	valor.Dump();
	valorCripto.Dump();
	valorDesCripto.Dump();
	
	
}

public string CriptografaSenhaGlobus(string texto, byte quantidadePosicoes)
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

public string Criptografar(string texto, int vInt = 48)
{
    texto = texto.Trim();

    string resultado = "";
    int numAuxiliar;

    if (vInt < 48)
        vInt = 48 + vInt;
    if (vInt > 57)
        vInt = 57 - vInt;

    int j = 1;
    for (int i = 0; i <= texto.Length - 1; i++)
    {
        numAuxiliar = ((int)Convert.ToChar(texto[i])) + j;
        byte[] arraybyteAuxiliar = { Convert.ToByte(vInt) };

        resultado += numAuxiliar.ToString().PadLeft(3, '0') + ASCIIEncoding.ASCII.GetString(arraybyteAuxiliar);

        vInt++;
        if (vInt > 57) vInt = 48;
        j++;
        if (j > 744)
            j = 1; // Reinicia
    }
    return resultado;
}

public static string Descriptografar(string valor)
{
    valor = valor.Trim();
    string resultado = "";
    int contador = 0;
    int numAuxiliar = 1;

    while (contador < valor.Length)
    {
        byte[] arraybyteAuxiliar = { Convert.ToByte(Convert.ToInt32(valor.Substring(contador, 3)) - numAuxiliar) };
        resultado += ASCIIEncoding.ASCII.GetString(arraybyteAuxiliar);
        numAuxiliar += 1;
        contador += 4;
    }

    return resultado;
}
