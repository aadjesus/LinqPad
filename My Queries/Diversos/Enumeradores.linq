<Query Kind="Program" />

void Main()
{
	typeof(char).Name.Dump("Exemplo = 1");		
    eEnum1.eEnumG.ToString("G").Dump();
    eEnum1.eEnumg.ToString("g").Dump();
    eEnum1.eEnumX.ToString("X").Dump();
    eEnum1.eEnumx.ToString("x").Dump();
    eEnum1.eEnumF.ToString("F").Dump();
    eEnum1.eEnumf.ToString("f").Dump();
    eEnum1.eEnumD.ToString("D").Dump();
    eEnum1.eEnumd.ToString("d").Dump();
		
	typeof(int).Name.Dump("Exemplo = 2");
	eEnum2.eEnum1.ToString("G").Dump();
	eEnum2.eEnum2.ToString("g").Dump();
	eEnum2.eEnum3.ToString("X").Dump();
	eEnum2.eEnum4.ToString("x").Dump();
	eEnum2.eEnum5.ToString("F").Dump();
	eEnum2.eEnum6.ToString("f").Dump();
	eEnum2.eEnum7.ToString("D").Dump();
	eEnum2.eEnum8.ToString("d").Dump();

	
}

public enum eEnum1
{
	eEnumG= 'G',
	eEnumg= 'g',
	eEnumX= 'X',
	eEnumx= 'x',
	eEnumF= 'F',
	eEnumf= 'f',
	eEnumD= 'D',
	eEnumd= 'd',
}

public enum eEnum2
{
	eEnum1= 1,
	eEnum2= 2,
	eEnum3= 3,
	eEnum4= 4,
	eEnum5= 5,
	eEnum6= 6,
	eEnum7= 7,
	eEnum8= 8,
}
