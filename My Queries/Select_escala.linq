<Query Kind="Expression">
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

(SELECT 
*
  FROM t_Esc_Programacaohoraria Ph
  left join t_Esc_Servicoprogramacao Sh on  Ph.Cod_Intprograma = Sh.Cod_Intprograma
  left join t_Esc_Horarioprogramacao Hp on Sh.Cod_Intprograma = Hp.Cod_Intprograma	AND Sh.Cod_Intturno = Hp.Cod_Intturno	AND Sh.Cod_Servico = Hp.Cod_Servico

	where Ph.Ativo = 'S'
	AND Sh.Cod_Servico LIKE '001%'
	and Ph.Cod_Intprograma > 100 and Ph.Cod_Intprograma < 200
)	
--ORDER BY Ph.Cod_Intprograma   
--group by
--Ph.Cod_Intprograma