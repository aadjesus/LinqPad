<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Drawing</Namespace>
</Query>

void Main()
{
	Font fonte = new Font("Tahoma", 8.25F);
	
	TextBox textBox1 = new TextBox();
	Graphics g1 = Graphics.FromHwnd(textBox1.Handle);

//	g1.MeasureString("0", textBox1.Font).Dump();
//	g1.MeasureString("O", textBox1.Font).Dump();
//	
//	TextRenderer.MeasureText( "0",  fonte ).Dump();
//	TextRenderer.MeasureText( "O",  fonte ).Dump();

	Enumerable.Range(33,127)
		.Select(s=> new 
		{
			s,
			Caracter = (char)s,
			Tamanho_MeasureString = g1.MeasureString(((char)s).ToString(), textBox1.Font).Width,
			Tamanho_MeasureString2 = g1.MeasureString(((char)s).ToString(), textBox1.Font).Height,
			
			Tamanho_TextRenderer = TextRenderer.MeasureText( ((char)s).ToString(),  fonte ).Width,
			Tamanho_TextRenderer1 = TextRenderer.MeasureText( ((char)s).ToString(),  fonte ).Height
		})
//	.OrderByDescending(o=> o.Tamanho_MeasureString)
//	.OrderByDescending(o=> o.Tamanho_TextRenderer)
	.OrderBy(o=> o.s)
	.Dump()
	.GroupBy(g => g.Tamanho_MeasureString,(grupo,lista) => new 
	{ 
		Tamanho = grupo, 
		Caracter = lista
			.Select(s=> s.Caracter) 
	})
	.OrderByDescending(o=> o.Tamanho)
	.Dump();
	
//	Form a = new Form();
//	a.Controls.Add(new Label() { Text = "W", Location = new Point(10,10), BorderStyle = BorderStyle.FixedSingle} );
//	a.Controls.Add(new TextBox() { BorderStyle= BorderStyle.None, Location = new Point(10,40), Width = (int)g1.MeasureString("W", textBox1.Font).Width  });
//	a.Controls.Add(new TextBox() { BorderStyle= BorderStyle.None, Location = new Point(10,80), Width = TextRenderer.MeasureText( "W",  fonte ).Width  });
//	a.ShowDialog();

}