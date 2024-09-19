<Query Kind="Expression">
  <Connection>
    <ID>245f3376-0fc2-469b-9af9-d5b58b1ab0d6</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.Oracle</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA+jvtxrL+XEWFEkMj1xij7AAAAAACAAAAAAADZgAAwAAAABAAAAB4+RYXiU+PaIy+aKVQQQELAAAAAASAAACgAAAAEAAAAPo2IPCxm9uE2PgAK43xl2lAAAAAPkEBd8wTSDCWkLzbR51t1ANk3lipAr47ZB9D3iPDXZnnVrDYbrv/6WVZP54Ai1IGzdz7+EBqyS61kKEcQeU6wRQAAACOigktV7sp59G7z+aJF64aWk0iPA==</CustomCxString>
    <Server>ora11g</Server>
    <UserName>COMPORTE130321</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA+jvtxrL+XEWFEkMj1xij7AAAAAACAAAAAAADZgAAwAAAABAAAAA3CkQ4nDX3mlUN/XkHQBt4AAAAAASAAACgAAAAEAAAAEPn6NSsNsb4RCTkjCxBc54QAAAADDZY4VF6lylUFMcKshxHmBQAAABa2Q4t/vmibFwkExVpiuyPqDaYiQ==</Password>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>true</StripUnderscores>
      <QuietenAllCaps>true</QuietenAllCaps>
      <ConnectAs>Default</ConnectAs>
      <UseOciMode>true</UseOciMode>
    </DriverData>
  </Connection>
</Query>

GfoItinerarios
	.Join(GfoItinerarioItens,
			a=> new {a.IdItinerario, a.Codintlinha},
			b=> new {b.IdItinerario, b.Codintlinha},
			(a,b) => new 
			{
				a,b
			})
	.Where(w=> w.a.BgmCadlinhas.Codigoempresa == 8 &&
			   w.a.IdItinerario == 1 &&
			   w.b.Sequencial == 1)
	