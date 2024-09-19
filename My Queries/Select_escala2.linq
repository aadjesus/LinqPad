<Query Kind="Program">
  <Connection>
    <ID>a832ee94-9fbc-40b4-a698-f27c05f3d1e9</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.Oracle</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAvsgBYpcs2E2di9LXuJX9TQAAAAACAAAAAAADZgAAwAAAABAAAADCLkwtIkn06WAgrU4BRUw6AAAAAASAAACgAAAAEAAAAGMy069bRCNsnJt35YjeFv9AAAAAdm+IzH2Bcl3v/zg5mfXO5EqYW5Wp6FGxj267LtkzegH46GtYs2t4Wt0CTydgy6rPivY4io4/qJ9bFBj7TqWJKBQAAAAxRzp4+sIub4XF0PKI89Mlto+QbA==</CustomCxString>
    <Server>ora11g64</Server>
    <UserName>SBCTRANS171031</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAvsgBYpcs2E2di9LXuJX9TQAAAAACAAAAAAADZgAAwAAAABAAAAA1xBGFbUVxqq0W3hvz22kkAAAAAASAAACgAAAAEAAAAOqbQ6vyGQXqabpZ9cxUfv8QAAAAdEx3pmseQrXvIOwzbFU//xQAAAC9jHFoAnnEpDj5ICHboZPEMKsVyQ==</Password>
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
		Func<DateTime?,string> data =
			f => f == null
				? string.Empty
				: f.Value.ToString("HH:mm")
				;
		
		var x1=
			from Ph in TEscProgramacaohorarias
			join Sh in TEscServicoprogramacaos on Ph.CodIntprograma equals Sh.CodIntprograma into join_Sh
			from Sh in join_Sh.DefaultIfEmpty()			
			join Hp in TEscHorarioprogramacaos on new { Sh.CodIntprograma, Sh.CodIntturno, Sh.CodServico}equals new { Hp.CodIntprograma, Hp.CodIntturno, Hp.CodServico}into join_Hh
			from Hp in join_Hh.DefaultIfEmpty()		
			where Ph.Ativo=="S"
			    //&& Sh.CodServico.Contains("001")
				&& Ph.CodIntprograma == 106
				//&& Ph.CodIntprograma > 100 && Ph.CodIntprograma < 200
			select new
			{
				//Ph, Sh, Hp
				//Ph.CodIntprograma,Ph.CodPrograma,Ph.CodTipodia,Ph.Codintlinha,Ph.DatElabor,Ph.CodigoEmpresa,Ph.NomElabor,Ph.CodigoFil,Ph.DatAlter,Ph.NomUsuaralter,Ph.Ativo,Ph.Obsprg,Ph.CodigoOsoRov,Ph.Importada
				//Sh.CodServico,
				//Sh.CodIntturno,
				SaidaGaragem = data(Sh.HorSaidaGaragem),
				InicioServico = data(Sh.HorInicioServico),
				FimServico = data(Sh.HorFimServico),				
				InicioIntervalo = data(Sh.HorInicioIntervalo),
				FimIntervalo = data(Sh.HorFimIntervalo),
				Sh.ProgRendicao,Sh.ServicoRendicao,Sh.TurnoRendicao				
				
				 
				 //Sh.HorSaidaGaragem,Sh.HorInicioServico,Sh.HorFimServico,Sh.HorInicioIntervalo,Sh.HorFimIntervalo,
				 //Sh.Preparomotorista,Sh.FlgSegpegada,Sh.Preparocobrador,Sh.Percursomotorista,Sh.Percursocobrador,Sh.Entregaferia,Sh.FlgTipo,Sh.CodLocpegmotorista,Sh.CodLocpegcobrador,Sh.RetornoGaragem,Sh.Posicao,Sh.FlgEqpfixa,Sh.FlgSomaequipe,Sh.Posicaomot,Sh.Posicaocob,Sh.Origem,Sh.FlgEntrada,Sh.TipodiaSemana,Sh.Codocorr,Sh.FlgServpagacomissao,Sh.FlgViradadia,Sh.TEscServicoprogEqpfixas
				//,Hp.CodHorarioprog,Hp.CodAtividade,Hp.HorSaida,Hp.HorChegada,//Hp.Codintlinha,Hp.TempoAtiv,Hp.TempoPlaca,Hp.TempoViag,Hp.FlgSentido,Hp.CodSufixo,Hp.CodLocalidade,Hp.Identificador,Hp.CodLocRef,Hp.HorRef,Hp.Observacao
			};
			
	x1.ToList()	
		//.OrderBy(o=> o.InicioServico)
		//.ThenBy(o=> o.CodServico)
		.Dump();
	
//	x1
//	.Select(s=> new 
//	{
//		s.CodServico,
//	}).Dump();
		
}