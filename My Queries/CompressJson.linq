<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.IO.Compression</Namespace>
</Query>

void Main()
{
	var random = new Random();
	var lista = Enumerable.Range(1, 1000000)
		.Aggregate(new List<MyClass>(), (retorno, item) =>
		{
			retorno.Add(new MyClass
			{
				Id = item,
				Descricao = "Descricao" + item,
				Data = DateTime.Now.Date.AddDays(1),
				Tipo = random.Next(1, 10),
				Valor = random.Next(item, item + 10) * 5
			});
			return retorno;
		});

	var json = JsonConvert.SerializeObject(lista);

	//var compress = Compress(json);
	//var decompress = Decompress(compress);
	//compress.Count().Dump();
	//System.Text.ASCIIEncoding.ASCII.GetByteCount(json).Dump();

	string pathArquivo = @"c:\Temp\ArqJson.txt";
	if (File.Exists(pathArquivo))
		File.Delete(pathArquivo);

	using (var streamWriter = new StreamWriter(pathArquivo))
		streamWriter.WriteLine(json);
	var arquivo = new FileInfo(pathArquivo);

	var gzipFileName = new FileInfo(arquivo.FullName + ".zip");

	using (var fileStream = arquivo.OpenRead())
	using (var fileStreamZip = gzipFileName.Create())
	using (var gZipStream = new GZipStream(fileStreamZip, CompressionMode.Compress))
		fileStream.CopyTo(gZipStream);

	arquivo.Length.Dump("Atual");
	gzipFileName.Length.Dump("Zip");	

//	using (FileStream fileToDecompressAsStream = gzipFileName.OpenRead())
//	{
//		string decompressedFileName = @"c:\Temp\ArqJsondecompressed.txt";
//		using (FileStream decompressedStream = File.Create(decompressedFileName))
//		using (GZipStream decompressionStream = new GZipStream(fileToDecompressAsStream, CompressionMode.Decompress))
//			decompressionStream.CopyTo(decompressedStream);
//	}
}


public static byte[] Compress(string texto)
{
	byte[] inputBytes = Encoding.UTF8.GetBytes(texto);
	using (MemoryStream memory = new MemoryStream())
	{
		using (GZipStream gZipStream = new GZipStream(memory, CompressionMode.Compress, true))
		{
			gZipStream.Write(inputBytes, 0, inputBytes.Length);
		}
		return memory.ToArray();
	}
}

static string Decompress(byte[] gzip)
{
	using (var gZipStream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
	using (var memoryStream = new MemoryStream())
	{
		gZipStream.CopyTo(memoryStream);
		var outputBytes = memoryStream.ToArray();

		return Encoding.UTF8.GetString(outputBytes);
	}
}

class MyClass
{
	public int Id { get; set; }
	public string Descricao { get; set; }
	public DateTime Data { get; set; }
	public int Tipo { get; set; }
	public decimal Valor { get; set; }
}
