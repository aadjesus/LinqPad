<Query Kind="Program">
  <Connection>
    <ID>1f3df4be-6a9d-4313-9235-74ff322e8ddf</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.Oracle</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAApFCDlPXo2UydHX9FOOV/FgAAAAACAAAAAAADZgAAwAAAABAAAADJq8vyUE+D/rKAWU+BXmK8AAAAAASAAACgAAAAEAAAAE/qKh2GQBO6YTapLPrzScs4AAAAbDGaq/GPSAV1smsHWlGWO7g4oohLB8+UtH8tBDV9zeU18arIUkz2oAbBn9AIVUgi3lJD4qGln3EUAAAAIqRgW+b0aDOYO8SzgM5SciegqWI=</CustomCxString>
    <Server>ORA11G64</Server>
    <UserName>SIITESTE</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAApFCDlPXo2UydHX9FOOV/FgAAAAACAAAAAAADZgAAwAAAABAAAAAKIvzvOTfSARxFtXP8B2fVAAAAAASAAACgAAAAEAAAAM8Z7098Y22ZGiuXCczqDLAQAAAA9rPwyJwQkLyhh/+QTRvjGxQAAABjSAo5j4TBQR7wgA+hhbh8XNGxZA==</Password>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>true</StripUnderscores>
      <QuietenAllCaps>true</QuietenAllCaps>
      <ConnectAs>Default</ConnectAs>
      <UseOciMode>true</UseOciMode>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	var x1 = SiiFuncionarios
		.Where(w=> w.Ativofuncionario == "A" && w.Coduf == "SP")
		.Select(s=> new 
		{
			Nome = s.Nomeabreviadofuncionario,
			AnoAdm = s.Dataadmissaofuncionario.Year,
			AnoNasc = (s.Datanascfuncionario ?? DateTime.MinValue).Year
		})
		.Select(s=> new 
		{
			s.Nome,
			s.AnoAdm,
			s.AnoNasc,
			AnosAdm = DateTime.Now.Year-s.AnoAdm,
			Idade = DateTime.Now.Year-s.AnoNasc
		})
		.Where(w=> w.Idade > 10)
		.Dump()
		.ToList();
		
	var x2 = x1
		.GroupBy(g=> g.AnosAdm)	
		.OrderByDescending(o=> o.Key)
		.Select(s=> new 
		{
			AnosAdm = s.Key,
			Qtde = s.Count(),
			Lista = s
				.OrderBy(o=> o.Nome)
				.Select(s2=> new 
				{
					s2.Nome,					
					s2.Idade
				})
		})
		.Dump();
		
}