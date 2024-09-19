<Query Kind="Statements" />

DateTime HoraChegadaProg = new DateTime(2010, 1, 1, 5, 23, 0);
DateTime HoraSaidaProg = new DateTime(2010, 1, 1, 4, 50, 0);
var tempoTotalViagem = HoraChegadaProg.Ticks - HoraSaidaProg.Ticks.Dump();

var calculo = (tempoTotalViagem * 12970) / 12970.Dump();

DateTime.Now.Date.AddTicks(calculo).Dump();

"".Dump();
HoraChegadaProg = new DateTime(2010, 1, 1, 7, 2, 0);
HoraSaidaProg = new DateTime(2010, 1, 1, 6, 20, 0);

tempoTotalViagem = HoraChegadaProg.Ticks - HoraSaidaProg.Ticks.Dump();

calculo = (tempoTotalViagem * 12970) / 12970.Dump();

DateTime.Now.Date.AddTicks(calculo).Dump();




