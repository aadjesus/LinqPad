<Query Kind="Program" />

void Main()
{
	#region Listas
	
	var servicoDTO = Enumerable.Range(0,10)
		.Select(s => new 
		{
			EmpresaXXXXX = Convert.ToInt32(s), 
			Filial = s, 
			Garagem = s, 
			TipoDocto = s, 
			Serie = s, 
			Conhecimento = s, 
			Veiculo = s,			
			Carreta = s,
			Carreta2 = s,
			LocalidColeta = s,
         	LocalidEntrega = s,      	
		});

	var servicoAuxiliarDTO = Enumerable.Range(0,10)
		.Select(s => new 
		{
			Empresa = s.ToString(), 
			Filial = s, 
			Garagem = s, 
			TipoDocto = s, 
			Serie = s, 
			Conhecimento = s, 
		});
		
	var veiculosDTO = Enumerable.Range(0,10)
		.Select(s => new 
		{
			CodigoVeic = ((s % 3 == 0) ? -1 : s)  
		});
		
	var localidadesDTO = Enumerable.Range(0,10)
		.Select(s => new 
		{
			CodLocalidade = s 
		});		

	var municipiosDvsDTO = Enumerable.Range(0,10)
		.Select(s => new 
		{
			CodMunic = s
		});
	#endregion
	
	var listaPrincipal = 
		(from a in servicoDTO
		
         join b in servicoAuxiliarDTO
		 				.Select(s=> new 
						{ 
							EmpresaXXXXX = Convert.ToInt32(s.Empresa), 
							s
						})
								on new { a.EmpresaXXXXX, a.Filial, a.Garagem, a.TipoDocto, a.Serie, a.Conhecimento } equals
                                   new { b.EmpresaXXXXX, b.s.Filial, b.s.Garagem, b.s.TipoDocto, b.s.Serie, b.s.Conhecimento } into join_b
         from b in join_b.DefaultIfEmpty()										  
         join veic in veiculosDTO on Convert.ToInt16(a.Veiculo) equals veic.CodigoVeic into join_veic
		 from veic in join_veic.DefaultIfEmpty()		
         join car1 in veiculosDTO on a.Carreta equals car1.CodigoVeic into join_car1
         from car1 in join_car1.DefaultIfEmpty()		
		 join car2 in veiculosDTO on a.Carreta2 equals car2.CodigoVeic into join_car2
         join locOri in localidadesDTO on a.LocalidColeta equals locOri.CodLocalidade
         join locDes in localidadesDTO on a.LocalidEntrega equals locDes.CodLocalidade		 
         //join munOri in municipiosDvsDTO on f.CodMunic equals munOri.CodMunic
         //join munDes in municipiosDvsDTO on g.CodMunic equals munDes.CodMunic
         from car2 in join_car2.DefaultIfEmpty()
		 select new 
		 { 
		 		Servico  = a,
				ServicoAuxiliar = b,
				Veiculo = veic,
				Carreta1 =  car1,
				Carreta2 = car2,
				LocalidColeta = locOri,
				LocalidEntrega = locDes,
		 });
		 
	listaPrincipal.Dump();						  
	
}