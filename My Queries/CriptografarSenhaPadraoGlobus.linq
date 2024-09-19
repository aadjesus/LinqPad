<Query Kind="Program" />

void Main()
{
	CriptografarSenhaPadraoGlobus("1234",false,6).Dump();
	CriptografarSenhaPadraoGlobus("1234",true,10).Dump();	
}

public static string CriptografarSenhaPadraoGlobus(string senha, bool posicional, int iQtdChar =0)
        {
            string resultado = "";

            if (senha.Length > 0)
            {
                int numAuxiliar;
                string convertido;

                numAuxiliar = 0;
                senha = senha.ToUpper();

                // Adiciona 32 ao código ASCII de cada caracter da string e acumula seus respectivos códigos em um somador
                for (int contador = 0; contador < senha.Length; contador++)
                {
                    if (posicional)
                        numAuxiliar += ((int)Convert.ToChar(senha[contador])) * (contador + 1);
                    else
                        numAuxiliar += ((int)Convert.ToChar(senha[contador])) + 32;
                }

                // Retorna as 10 primeiras posições do resultado da divisão do somador por 357
                convertido = Convert.ToString((double)numAuxiliar / 357);
                convertido = convertido.Substring(0, iQtdChar);

                resultado = "";

                for (int contador = 0; contador < convertido.Length; contador++)
                {
                    if (convertido.Substring(contador, 1) == ",")
                        resultado += '.';
                    else
                        resultado += convertido.Substring(contador, 1);
                }
            }
            return resultado;
        }