<Query Kind="Program">
  <Connection>
    <ID>accd7d1a-fd4a-4d2c-846b-fa23fb83cd04</ID>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.Oracle</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAiqVU/odBY02Dk+8cfv9CtgAAAAACAAAAAAADZgAAqAAAABAAAAC/ELiyoFp9v5uHdRMG6QDPAAAAAASAAACgAAAAEAAAAIJ320+ihDaueF04vaBwlnlAAAAAeI66E/liaImN6bSPzkxozHF1wEUuiSuT21CJtkuVJGu2fgzBaT+y3x5ZiuclPYHT/zu64fEt9VYVnYpBjCHNOhQAAACEWb59azJ6UgyOi/KH0h/TPpqSTQ==</CustomCxString>
    <Server>Ora10g</Server>
    <UserName>COMPORTE110303</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAiqVU/odBY02Dk+8cfv9CtgAAAAACAAAAAAADZgAAqAAAABAAAAAPiL+Qe28hbAN05+smsAO/AAAAAASAAACgAAAAEAAAAD83vN18Ar0I6QcEqeKuMWkQAAAAWGumTD9p2LgCeIANdjQ5VRQAAAA6BEDeoZyPZ7OsJYapQhgqbvTfEA==</Password>
    <DisplayName>COMPORTE110303</DisplayName>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>true</StripUnderscores>
      <QuietenAllCaps>true</QuietenAllCaps>
      <ConnectAs>Default</ConnectAs>
      <UseOciMode>true</UseOciMode>
    </DriverData>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Comum.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Util.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.FGlobus.Componentes.WinForms.dll</Reference>
  <Reference>C:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Comum.dll</Reference>
  <Namespace>FGlobus.Componentes.WinForms.ws.controle</Namespace>
  <Namespace>Globus5.WPF.Comum</Namespace>
  <Namespace>System.Web.Services.Protocols</Namespace>
  <Namespace>Globus5.WPF.Comum.ws.escala</Namespace>
  <Namespace>FGlobus.Util</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	WebServices.CarregarConfigWebServices(@"c:\GlobusMais\WPF\Distribuicao\BgmRodotec.Globus5.Config");	
	Globus5.WPF.Comum.Properties.Settings.Default.BgmRodotec_GestaoDeFrotaOnLineWS.Dump("");	

	DateTime dataHoraConsulta = new DateTime(2010, 1, 1, 7, 9, 0);
	int	codIntLinha = 2201;
	EscalaWS escalaWS = new EscalaWS();
	
	#region TipoDeDiaEscalaDTO
	
	TipoDeDiaEscalaDTO[] tipoDeDiaEscalaDTO = escalaWS.GenericoConsultaBasica<Globus5.WPF.Comum.ws.escala.TipoDeDiaEscalaDTO>(new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria[] 
	{
		new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
		{
		    Operador = Globus5.WPF.Comum.ws.escala.eOperador.Igual,
			Valor = 8,
			Propriedade = "CodEmpresa"
		},		
		new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
		{
		    Operador = Globus5.WPF.Comum.ws.escala.eOperador.Igual,
			Valor = 11,
			Propriedade = "CodFilial"		
		},				
		new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
		{
		    Operador = Globus5.WPF.Comum.ws.escala.eOperador.Igual,
			Valor = "ESC",
			Propriedade = "CodSistema"		
		}
		
//		,			new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
//					{
//						Operador = Globus5.WPF.Comum.ws.escala.eOperador.Igual,
//						Valor = "S",
//						Propriedade = "FlgDomingo"		
//					},
	})
	//.Dump("TipoDeDiaEscalaDTO")
	;
	
	#endregion
	
	#region EscalaPadraoDTO
	
	var escalaPadraoDTO = escalaWS.GenericoConsultaBasicaDosCampos<Globus5.WPF.Comum.ws.escala.EscalaPadraoDTO>(new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria[] 
	{
		new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
		{
		    Operador = Globus5.WPF.Comum.ws.escala.eOperador.Igual,
			Valor = "S",
			Propriedade = "FlgAtiva"
		},		
		new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
		{
		    Operador = Globus5.WPF.Comum.ws.escala.eOperador.Igual,
			Valor = codIntLinha,
			Propriedade = "CodIntLinha"		
		},		
		new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
		{
		    Operador = Globus5.WPF.Comum.ws.escala.eOperador.Contido,
			Valor = tipoDeDiaEscalaDTO.GroupBy(g=> g.CodIntTipoDia).Select(s=> s.Key).ToArray(),
			Propriedade = "CodTipoDia"
		}		
	},new string[] {"CodIntEscala","CodTipoDia"})
	.Rows.OfType<DataRow>()
	.Select(s=> new 
	{ 
		CodIntEscala = s.Field<int>("CodIntEscala"),
		CodTipoDia = s.Field<int>("CodTipoDia")
	})
	//.Dump("EscalaPadraoDTO")
	;
	
	#endregion

	#region ServicoEscalaPadraoDTO	
	
	var servicoEscalaPadraoDTO = escalaWS.GenericoConsultaBasicaDosCampos<Globus5.WPF.Comum.ws.escala.ServicoEscalaPadraoDTO>(
		new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
		{
		    Operador = Globus5.WPF.Comum.ws.escala.eOperador.Contido,
			Valor = escalaPadraoDTO.GroupBy(g=> g.CodIntEscala).Select(s=> s.Key).ToArray(),
			Propriedade = "CodIntEscala"
		},new string[] {"CodIntPrograma", "CodServico", "CodIntTurno","CodIntEscala","Codveic"}).Rows
		.OfType<DataRow>()
		.Select(s=> new 
		{
			CodIntPrograma = s.Field<int>("CodIntPrograma"), 
			CodServico = s.Field<string>("CodServico"), 
			CodIntTurno= s.Field<int>("CodIntTurno"), 
			Codveic= s.Field<int>("Codveic"), 
			CodIntEscala= s.Field<int>("CodIntEscala"), 
			})
		//.Dump("ServicoEscalaPadraoDTO")
		;
	
	#endregion
	
	#region HorarioProgramacaoDTO
	
	var horarioProgramacaoDTO = escalaWS.GenericoConsultaBasicaDosCampos<Globus5.WPF.Comum.ws.escala.HorarioProgramacaoDTO>(new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria[] 
	{
		new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
		{
		    Operador = Globus5.WPF.Comum.ws.escala.eOperador.Contido,
			Valor = servicoEscalaPadraoDTO.GroupBy(g=> g.CodIntPrograma ).Select(s=> s.Key).ToArray(),
			Propriedade = "CodIntPrograma"
		},		
		new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
		{
		    Operador = Globus5.WPF.Comum.ws.escala.eOperador.Contido,
			Valor = servicoEscalaPadraoDTO.GroupBy(g=> g.CodServico ).Select(s=> s.Key).ToArray(),
			Propriedade = "CodServico"		
		},		
		new Globus5.WPF.Comum.ws.escala.sCondicaoAdicionalCriteria() 
		{
		    Operador = Globus5.WPF.Comum.ws.escala.eOperador.Contido,
			Valor = servicoEscalaPadraoDTO.GroupBy(g=> g.CodIntTurno ).Select(s=> s.Key).ToArray(),
			Propriedade = "CodIntTurno"
		}		
	},new string[] {"CodIntPrograma", "CodServico", "CodIntTurno","FlgSentido","HorChegada"}).Rows
	.OfType<DataRow>()
		.Select(s=> new 
		{
			CodIntPrograma = s.Field<int>("CodIntPrograma"), 
			CodServico = s.Field<string>("CodServico"), 
			CodIntTurno= s.Field<int>("CodIntTurno"), 
			FlgSentido= s.Field<string>("FlgSentido"), 
			HorChegada= s.Field<DateTime>("HorChegada") 
			})
	
	//.Dump("HorarioProgramacaoDTO")
	;
	
	#endregion
	
	var listaGerarlServicosProgramados =
		(from hor in horarioProgramacaoDTO
		join ser in servicoEscalaPadraoDTO on new { hor.CodIntPrograma, hor.CodServico, hor.CodIntTurno } equals
		    							      new { ser.CodIntPrograma, ser.CodServico, ser.CodIntTurno }	
		join esc in escalaPadraoDTO on ser.CodIntEscala equals esc.CodIntEscala
		join tip in tipoDeDiaEscalaDTO  on esc.CodTipoDia equals tip.CodIntTipoDia	
		select new
		{
			Sentido = hor.FlgSentido.Equals("I") ? Globus5.WPF.Comum.ws.escala.eSentido.Ida : Globus5.WPF.Comum.ws.escala.eSentido.Volta,
			hor.HorChegada,
			ser.Codveic,
			TipoDeDia = tip.FlgDomingo.Equals("S")
							? Globus5.WPF.Comum.ws.escala.eTipoDeDia.Domingo
							: tip.FlgSabado.Equals("S")
								? Globus5.WPF.Comum.ws.escala.eTipoDeDia.Sabado
								: Globus5.WPF.Comum.ws.escala.eTipoDeDia.Segunda |
								  Globus5.WPF.Comum.ws.escala.eTipoDeDia.Terca |
								  Globus5.WPF.Comum.ws.escala.eTipoDeDia.Quarta |
								  Globus5.WPF.Comum.ws.escala.eTipoDeDia.Quinta |
								  Globus5.WPF.Comum.ws.escala.eTipoDeDia.Sexta
		})		
		.Dump();
			
	Func<Globus5.WPF.Comum.ws.escala.eTipoDeDia, sEscalaControleOperacional[]> delegateHorarioProgramacaoDTO =
					delegate(Globus5.WPF.Comum.ws.escala.eTipoDeDia tipoDeDia)
					{
						try
						{
							return listaGerarlServicosProgramados
								.Where(w => w.TipoDeDia == tipoDeDia)
								.Select(s => new sEscalaControleOperacional()
								{
									CodIntLinha = codIntLinha,
									Sentido = s.Sentido,
									HoraChegadaProg = s.HorChegada,
									CodIntVeiculo = s.Codveic
								})
								.ToArray();
						}
						catch (Exception)
						{
							return new sEscalaControleOperacional[] { };
						}
					};	
					
	sEscalaControleOperacional[] listaEscalaDiasUteis = delegateHorarioProgramacaoDTO(Globus5.WPF.Comum.ws.escala.eTipoDeDia.Segunda | Globus5.WPF.Comum.ws.escala.eTipoDeDia.Terca | Globus5.WPF.Comum.ws.escala.eTipoDeDia.Quarta | Globus5.WPF.Comum.ws.escala.eTipoDeDia.Quinta | Globus5.WPF.Comum.ws.escala.eTipoDeDia.Sexta).Dump("uteis");
	sEscalaControleOperacional[] listaEscalaSabado = delegateHorarioProgramacaoDTO(Globus5.WPF.Comum.ws.escala.eTipoDeDia.Sabado).Dump("Sabado");
	sEscalaControleOperacional[] listaEscalaDomingo = delegateHorarioProgramacaoDTO(Globus5.WPF.Comum.ws.escala.eTipoDeDia.Domingo).Dump("Domingo");

}