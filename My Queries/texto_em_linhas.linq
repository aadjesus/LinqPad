<Query Kind="Program" />

void Main()
{
	var objeto1 = Regex.Replace(_texto, "-+", "#grupo#") 			// identifica a linha tracejada 
		.Split(new string[] {"#grupo#"}, StringSplitOptions.None)   // cria linhas conforme o grupo
		.Select((s,index) => new 
		{
			index, 
			linha = s
		})		
		;
	
	var objeto2 = objeto1
		.OrderByDescending(o=> o.index)
		.Select(s=> s.linha
						.Split(new string[] {Environment.NewLine}, StringSplitOptions.None)
						.Where(w=> !string.IsNullOrWhiteSpace(w) )
						.Aggregate(string.Empty,(retorno,item) =>
						{							
							retorno += item + Environment.NewLine;
							return retorno;
						}));						

	var objeto3 = objeto2
		.Aggregate(string.Empty,(retorno,item) =>
		{
			retorno += item + new string('-',200)  + Environment.NewLine;
			return retorno;
		});
		
	var x1 = objeto2.Count().Dump();
	var x2 = _datas.Length.Dump();
	
	objeto1
		.GroupBy(g=> g.index/2).
		.Dump().Select(s=> s.Key).Dump();
}

string _texto = @"

Não entendo quem escolhe o caminho do crime, quando há tantas maneiras legais de ser desonesto. 

Al Capone. 

------------------------------------------------------------------------------------------------------------------------ 

Nossa vida não e nossa de fato, do útero ao tumulo temos ligações com os outros, passado, presente por cada crime bondade geramos nosso futuro(filme, a viagem) 

------------------------------------------------------------------------------------------------------------------------ 

Um bom artista cópia, um ótimo artista rouba (Picasso), não a nada mais original estamos sempre roubando algo de alguém 

------------------------------------------------------------------------------------------------------------------------ 

Uma mulher chama um homem de cachorro, que ele é infiel mas o cachorro e fiel, e se somos cachorro o q seria as mulheres.  

Uma cadela quando está no siu esfrega a bunda na grama, sai e da pro primeiro cachorro q ve, (filme, linha de aço) 

------------------------------------------------------------------------------------------------------------------------ 

Se algo pode dar errado, dará errado da pior maneira, no pior momento e de modo a causar o maior estrago possível 

Edward Murphy 

------------------------------------------------------------------------------------------------------------------------ 

A escola tradicional ensina a não errar e isso amedronta o indivíduo a arriscar, mas é arriscando e se sujeitando a falhas que alcançamos a inovação 

Peter Sims 

------------------------------------------------------------------------------------------------------------------------ 

As convicções são inimigos da verdade bem mais perigosos que as mentiras. 

Friedrich Nietzsche 

------------------------------------------------------------------------------------------------------------------------ 

nem tudo que pode ser naquele momento vai ser aceito naquele momento, e que mesmo sendo bom, pode ser muito discriminado.(CEO da Microsoft ) 

------------------------------------------------------------------------------------------------------------------------ 

Para evoluir além do que vc é vc precisa ser diferente doque vc é 

------------------------------------------------------------------------------------------------------------------------ 

No entanto, os homens podem lutar contra tudo. Menos a sua natureza. 

 

Olho por olho, dente por dente 

Será sempre mais dramático . do que o Dê a outra face. 

(Filme: Uma Cidade Sem Lei, Título Original: Bunraku 

------------------------------------------------------------------------------------------------------------------------ 

O homem é dono do que cala, e escravo do que fala.  
Quando Pedro me fala sobre Paulo, sei mais de Pedro do que de Paulo.   
Sigmund Freud 
 
Complemento:  Ao falarmos dos outros revelamos quem realmente somos 

Mílton Jung CBN 

------------------------------------------------------------------------------------------------------------------------ 

Não ligue o que você não vai saber desligar.  

Mario Sergio Cortella 

------------------------------------------------------------------------------------------------------------------------ 

Fuzileiros não morrem, vão para inferno e se reagrupam. 

Filme amanhecer violento  

------------------------------------------------------------------------------------------------------------------------ 

O amanhã e algo pra se viver mais tarde  

Tecnicamente Eu 

------------------------------------------------------------------------------------------------------------------------ 

qual quer pessoa esta apenas a um dia ruim de encarar a insanidade 

Coringa batman 

------------------------------------------------------------------------------------------------------------------------ 

Os dois dias mais importantes da sua vida são o dia que vc nasce e o outro é porque  

Mark Twain 

------------------------------------------------------------------------------------------------------------------------ 

Para viver fora da lei você precisa ser honesto 

Bob Dylan 

------------------------------------------------------------------------------------------------------------------------ 

Fazer o seu melhor e a única opção. Mesmo que o resultado seja o fracasso. 

------------------------------------------------------------------------------------------------------------------------ 

Se o problema tem solução, não esquente a cabeça, porque tem solução.  

Mas se o problema não tem solução, não esquente a cabeça muito menos, porque o problema não tem solução. 

 

Ou 

 

Se seu problema tem solução,então não há com que se preocupar. 

Mas se seu problema não tem solução, toda preocupação será em vão 

 

Proverbio Chines  

------------------------------------------------------------------------------------------------------------------------ 

Posso discordar de suas palavras, mas defenderei até a morte o seu direito dizê-las.  

Voltarie  

------------------------------------------------------------------------------------------------------------------------ 

Perder peso e juntar dinheiro, são as duas coisa é que as pessoas mais querem saber como faz,  

mais sabem como deve fazer e não conseguem fazer. 

Marcio Atala 

------------------------------------------------------------------------------------------------------------------------ 

Sepulcros fétidos caiados de branco por fora (Resumo= Sepulcros caiados). 

Jesus (Ele falou isso para os moralista do templo, que ficavam escadalizando com oq era pequeno e se esqueciam dos grandes escandalos) 

Significado = Um túmulo fedendo, mas pintado por fora pra parecer limpinho e branco.     

Sepulcro = sepultura, túmulo 

Fétidos = Fedido, fedorento 

Caiado = branqueado com pó de arroz ou outros cosméticos. 

Resumo = Gente podre por dentro 

Mario sergio coretela 

------------------------------------------------------------------------------------------------------------------------ 

Quanto tempo a gente precisa enxergar pra que comece a ver? 

Ana Suy 

------------------------------------------------------------------------------------------------------------------------ 

Ninguem faz a diferença sendo igual ao outro. 

------------------------------------------------------------------------------------------------------------------------ 

O pesimista ganha uma chave e pergunta oque eu vou fazer com isso, o otimistata ganha um balde de merda e pergunta cade meu cavalo. 

 

Ser louco num mundo perturbado não é loucura e sanidade 

Serie the end of the f***ing world  

 

 preparado para paz pronto para guerra 

------------------------------------------------------------------------------------------------------------------------ 

Filipe Ret 

Não falo tudo que sei, mais sei tudo que falo, 

eu sou responsável pelas coisas que falo e faço não pelas coisas que esses putos ve ou entende 

 

Inquérito 

Também quero há revolução mais não sou um imbecil, quem não sabe usar um lápis não vai saber usar um fuzil 

 

 

Platão 

O castigo dos bons que não fazem política é ser governados pelos maus  

O mal de quem não gosta de politica é ser governado por quem gosta de politica 

Pessoas normais falam sobre coisas, pessoas inteligentes falam sobre ideias, pessoas mesquinhas falam sobre pessoas 

 

------------------------------------------------------------------------------------------------------------------------ 

Deus não joga dados  

Ainsten 

------------------------------------------------------------------------------------------------------------------------ 

 você não precisa saber tudo basta saber onde consultar tudo 

------------------------------------------------------------------------------------------------------------------------ 

Agora os inimigos estão levantando a mão e falando. Não gosto de vc!  

Obrigado! Por vc ser sincero, de vc ñ vou ser apunhalado pelas costas,  vou estar sempre ligeiro. 

Mano Brown 

------------------------------------------------------------------------------------------------------------------------ 

O mundo seria muito melhor se as pessoas tivessem a mesma disposição para ouvir que tem para falar 

Toda excelência é tão difícil quanto Rara 

  

Baruch Spinoza 

------------------------------------------------------------------------------------------------------------------------ 

Tirar as moscas da cozinha cagando na sala 

Quem quer que volte a ditadura pq a democracia não funciona  

------------------------------------------------------------------------------------------------------------------------ 

No Dream Is To B.I.G  

Nenhum sonho é grande de mais 

------------------------------------------------------------------------------------------------------------------------ 

A PALAVRA PERTENCE METADE A QUEM A PROFERE E METADE A QUEM A OUVE. 

Michel De Montaigne 

------------------------------------------------------------------------------------------------------------------------ 

Onde está o futuro?   

Bem aqui.  

De quem é essa vida?   

Minha.  

O que você vai fazer com ela?  

Vilela, vivela  custe o que custar..... 

Serie, Raio Negro   

------------------------------------------------------------------------------------------------------------------------ 

Só de lembrar dá ódio, neurose 

As patricinha na fila do show do Snoop Dogg 

Pagando mais de cem num ingresso pra curtir 

Justamente pra favela não ter chance de assitir 

Realidade Cruel, A Trilha Sonora do Gueto 

------------------------------------------------------------------------------------------------------------------------ 

Você nascer em uma condição desfavorável pode ser erro de alguém que 

vem antes de você, mas se você morrer naquela condição foi escolha sua. 

 

Sou formado na faculdade da vida, no curso de superação, pós graduado em me levantar toda vez que o vida me jogar no chão. 

 

Rick Chesther 

------------------------------------------------------------------------------------------------------------------------ 

4.1 na Escala Richter, tremendo o chão 

------------------------------------------------------------------------------------------------------------------------ 

Você está me escutando ou só esperando pra falar! 

xxxxxx 

------------------------------------------------------------------------------------------------------------------------ 

O jeito de ver pela fé é fechar os olhos da razão.”  

Benjamin Franklin 

------------------------------------------------------------------------------------------------------------------------ 

Não há bem que sempre dure, nem mal que nunca se acabe... 

xxxxxx 

------------------------------------------------------------------------------------------------------------------------ 

vc tem que estar consciente das coisa que podem acontecer de ruim  

Vc tem que focar sua energia e suas preocupações em coisas que vc controla estar consciente  

doque vc ñ controla e pode dar errado e lutar naquilo que vc controla pra fazer o seu melhor  

e dando certo ou dando errado a sua tranqüilidade e que fiz o meu melhor. 

PEDRO CALABREZ 

------------------------------------------------------------------------------------------------------------------------ 

Antes da falar do feminismo precisamos falar do machismo 

Ele existe na sociedade? 

Pq o feminismo só relevante se a tese esta correta. 

Essa sociedade se estrutura através de uma desigualdade de gênero.   

Carina Vitral 

------------------------------------------------------------------------------------------------------------------------ 

Geralmente alguns segredos é oq mantém a pessoa viva.  

Ex: Um gay q não sai do armário. 

------------------------------------------------------------------------------------------------------------------------ 

Bandido bom é bandido recuperando/socializado 

Eduardo Taddeo 

------------------------------------------------------------------------------------------------------------------------ 

Agua de mais também mata planta 

------------------------------------------------------------------------------------------------------------------------ 

Culpa e responsabilidade  

Culpa: Um sujeito só pode ser culpado pelo um ato que diretamente ele comete 

Ex: Nenhum brando de hj é culpado pelo racismo estrutural histórico,  mais responsabilidade 

Responsabilidade: Cada membro de uma comunidade é responsável pelo destino da sua comunidade. 

Ex: Então todos brancos são responsáveis pelo racismo estrutural do Brasil 

Kal iasp  

------------------------------------------------------------------------------------------------------------------------ 

 

Eu já vi de perto a derrota por isso que eu digo de virada é mais gostoso 

Delano, Djonga e MC Hariel - Deus e Família 

------------------------------------------------------------------------------------------------------------------------ 

no somos consequência do meio 

 

MOFAIA no dialeto jamaicano eh p vc botar fogo ,amor,paixao,positividade em tudo q vc acredita!MOFAIA =  more fire! Ser positivo e do bem.  

 

Eu aprendi a pesar logo mudo de opinião, só não muda de opinião  aquele não pensa 

Mario Quintana 

 

Significado da palavra convercer 

Vencer com 

------------------------------------------------------------------------------------------------------------------------ 

Não se chega ou novo por sucessivos incrementos no velho, o velho tem que morrer. 

 

Exemplos  

Kodak poderia melhorar a qualidade do filme 10% ao ano que não ia virar um instagran 

Blockbuster poderia ter melhorado a loja com DVDS que não ia vira uma netflix 

 

Conclusão 

A base é totalmente diferente, ela tem que matar o antigo. 

Ai esse desprendimento é o mais difícil para as empresa grandes pq elas tem mais a perder, já as pequenas tem menos recursos, mais tem mais agilidade. 

 

Joseph Alois Schumpeter 

------------------------------------------------------------------------------------------------------------------------ 

 

Não há bem que sempre dure, nem mal que nunca se acabe 

------------------------------------------------------------------------------------------------------------------------ 

Devemos acreditar no que dizemos e fazer o que acreditamos. 

------------------------------------------------------------------------------------------------------------------------ 

Grandes reformas acontecem com mudança de regime 

------------------------------------------------------------------------------------------------------------------------ 

Currículo  tem que ter foto! 

Cidadão só é chamado de cidadão se tem CPF 

Inocente do Zero 

Criolo 

------------------------------------------------------------------------------------------------------------------------ 

Don t support the phonies, SUPPORT THE REAL 

Não suporte os fonemas, APOIE O REAL 

2Pac 

 

tudo está em paz quando tudo faz sentido 

------------------------------------------------------------------------------------------------------------------------ 

A oposição ao bosanarismo não é esquerda e sanidade  

Alvaro Borba (Canal meteoro) 

Ou vc contra ou vc é louco 

------------------------------------------------------------------------------------------------------------------------ 

Realidade é um ponto de vista, que se apresenta de forma diferente pra cada um de nois 

------------------------------------------------------------------------------------------------------------------------ 

Não quero ser melhor que alguém eu quero ser melhor que eu mesmo 

------------------------------------------------------------------------------------------------------------------------ 

Se você acha que custa cara um bom profissional , e porque você não faz ideia de quanto custa um incompetente. 

------------------------------------------------------------------------------------------------------------------------ 

O velho é um jovem que deu certo 

Alysson L. Carvalho  \ Paulinho Gogó 

------------------------------------------------------------------------------------------------------------------------ 

Sábio é aquele que finge ser tolo, observando o tolo fingindo ser sábio. 

Bruno Jonathan 

------------------------------------------------------------------------------------------------------------------------ 

O homem é livre pra fazer o que quer, mas não para querer o que quer 

Arthur Schopenhauer 

------------------------------------------------------------------------------------------------------------------------ 

Teoria do Egoísmo: 

O egoísmo psicológico é a teoria de que todas as nossas ações são basicamente 

motivadas pelo interesse próprio 

 

Jamais alguém fez algo totalmente pra os outros. Todo amor é amor próprio.  Pense naqueles que voce ama: Cave profundamente e verá que não ama á ales; ama as sensações agradáveis que esse amor produz em você! Você ama o desejo, não o desejado. 

Friedrich Nietzsche 

------------------------------------------------------------------------------------------------------------------------ 

Posso não concordar com nenhuma das palavras que você disser, mas defenderei até a morte o direito de você dizê-las. 

Evelyn Beatrice Hall 

------------------------------------------------------------------------------------------------------------------------ 

tenha fé! a cruz é só ferro 

Naitoichi 

------------------------------------------------------------------------------------------------------------------------ 

Dizem que Deus e bom, o mundo é uma merda logo ele não existe 

------------------------------------------------------------------------------------------------------------------------ 

Você não precisa ver a escada inteira, basta ver o primeiro degrau 

Tratar os desiguais de maneira igual reforça a desigualdade 

Quando se tortura os números vc consegue fazer que eles digam qualquer coisa 

------------------------------------------------------------------------------------------------------------------------ 

O principal problema do Mundo, é que os idiotas estão cheios de certezas e os inteligentes estão cheios de dúvidas 

Bertrand Russell 

------------------------------------------------------------------------------------------------------------------------ 

Alegações extraordinárias exigem evidencias extraordinárias 

Carl Sagan 

------------------------------------------------------------------------------------------------------------------------ 

O que me preocupa não é o grito dos maus, mas o silêncio do bons 

Martn Lutherking Jr 

 

Quando a educação não é libertadora, o sonho do oprimido é﻿ ser o opressor 

Paulo Freire 

 

Realidade e ponto de vista pq o mundo se apresenta de forma diferente pra cada um 

Não quero ser melhor que alguém eu quero ser melhor que eu mesmo 

Se você acha que custa cara um bom profissional , e porque você não faz ideia de quanto custa um incompetente. 

Homens fortes criam tempos fáceis e tempos fáceis geram homens fracos, mas homens fracos criam tempos difíceis e tempos difíceis geram homens fortes 

Provérbio Oriental 

 

Nunca estivemos tão perto de quem está longe e tão longe de quem está perto 

Steve Jobs 

 

O diabo é diabo não porque ele é malvado e porque ele e velho 

O diabo é sábio não porque é diabo, mas pq é velho 

------------------------------------------------------------------------------------------------------------------------ 

Tento manter uma convivência pacífica entre a superfície e o profundo 

Gabriela Prioli 

------------------------------------------------------------------------------------------------------------------------ 

É possível contar um monte de mentiras só dizendo a verdade 

Luiz Roberto Bodstein 

------------------------------------------------------------------------------------------------------------------------ 

Não investa o que sobra, gate o que sobra depois de investir  

Warren Buffett  

 

A incompreensão do presente nasce fatalmente da ignorância do passado 

------------------------------------------------------------------------------------------------------------------------ 

Se você não consegue explicar algo de modo simples é porque não entendeu bem a coisa. 

Albert Einstein 

------------------------------------------------------------------------------------------------------------------------ 

Quem não odeia o mau não pode amar o bem 

------------------------------------------------------------------------------------------------------------------------ 

Os circuitos de consagração social serão tanto mais eficazes, quanto maior a distância social do objeto consagrado. 

 

Quer dizer que, quanto mais distante o porta voz estiver em escala social, maior a legitimidade e o prestigio por ele alcançados 

 

Exemplo: Se vc faz alguma coisa e receber três elogios um da sua mãe outros de um amigo e o terceiro elogio de uma pessoa qualquer, as três pessoas elogiam do mesmo jeito Parabéns\Bom Trabalho\Excelente. Qual dos três elogios é mais consagrador!. 

Ai eu te pergunto qual é o elogio mais ineficaz do mundo. O próprio pq é distancia zero.  

 

Pierre Bourdieu    

------------------------------------------------------------------------------------------------------------------------ 

se algo é de graça o produto é você 

------------------------------------------------------------------------------------------------------------------------ 

Homens fortes criam tempos fáceis, e tempos fáceis geram homens fracos; mas homens fracos criam tempos difíceis, e tempos difíceis geram homens fortes 

Provérbio oriental 

------------------------------------------------------------------------------------------------------------------------ 

O segredo da mudança é focar toda sua energia, não em lutar contra o velho, mais sim em construir o novo. 

 

O segredo da mudança é focar a energia em construir o novo e não em destruir o velho. 

Socrates  

 

há amores tão intenso que merecem ser vividos 

 

há verdade não é mais algo realizado aos fatos, a verdade é um lugar que eu vou procurar conforto 

A verdade não é um fato eu acredito naquilo que me faz me sentir melhor  

 

Gênesis 8:21 

Cabo Daciolo: Quando houve o diluvio, A palavra diz que na sua essência o homem desde a juventude tem o coração  predestinado para o mal, mais pode predominar o bem  

 

Gênesis 8:21 

O Senhor sentiu o aroma agradável e disse a si mes­mo: Nun­ca mais amaldiçoarei a terra por causa do homem, pois o seu coração é inteiramente inclinado para o mal desde a infância. E nunca mais destruirei todos os seres vivos como fiz desta vez. 

 

A chance só favorece a mente preparada 

Luiz pasteur 

------------------------------------------------------------------------------------------------------------------------ 

Para criar inimigos não é necessário declarar guerra, basta dizer o que pensa. 

para vc ter inimigos basta dizer o que pensa 

Martin Luther King  

------------------------------------------------------------------------------------------------------------------------ 

Criar dificuldades e vender facilidades 

------------------------------------------------------------------------------------------------------------------------ 

Seja indiferente as mazelas do mundo, pois vc não tem e não terra controle sobre elas e quanto menos vc tenta controla-las mais controle vc tem sobre si mesmo  

------------------------------------------------------------------------------------------------------------------------ 

Ensinando o trivo  

a lógica é a ciência do raciocínio certo 

------------------------------------------------------------------------------------------------------------------------ 

O dinheiro não compra felicidade, mais ser pobre não compra porra nenhuma   

------------------------------------------------------------------------------------------------------------------------ 

Ser fiel a UMA única mulher é um preço pequeno demais se comparado a algo tão grande, como ter UMA mulher  

G.K. Chesterton 

------------------------------------------------------------------------------------------------------------------------ 

Que vc perdoe suas versões anteriores. Foi o máximo que vc podia fazer naquela época. 

Fabrício Carrpinejar 

------------------------------------------------------------------------------------------------------------------------ 

Quando eu entrei aqui achei que ia promover o bem, agora que estou aqui o meu papel e retardar o mal. 

------------------------------------------------------------------------------------------------------------------------ 

Todo ponto de vista é vista de um ponto 

Leonardo Boff 

------------------------------------------------------------------------------------------------------------------------ 

Todo dia um malandro e um trouxa sai de casa, quando eles se encontram sai negocio 

------------------------------------------------------------------------------------------------------------------------ 

Na pratica ñ é pratico 

EU 

------------------------------------------------------------------------------------------------------------------------ 

O povo sabe o que quer / Mas o povo também quer o que não sabe 

Gilberto Gil 

------------------------------------------------------------------------------------------------------------------------ 

O software mais barato que conseguimos construir é aquele que compramos prontos 

Mythical man-month 

------------------------------------------------------------------------------------------------------------------------ 

Quando você tem algo a dizer, o silêncio é uma mentira 

Jordan Peterson 

------------------------------------------------------------------------------------------------------------------------ 

O melhor remédio para ideias ruins são outras ideias  

------------------------------------------------------------------------------------------------------------------------ 

MÁRIO SERGIO CORTELLA 

A postagem em redes sociais da vida boa, se remete a uma diferenciação no meio do bando. Eu sou um desse mais eu sou melhor 

esse narcisismo é uma insegurança de si mesmo, toda vez que eu simulo ser mais que eu sou 

é que tenho insegurança em ser de fato o que estou sendo. 

Então eu tenho tanto medo de que o modo que eu sou ele seja frangiu que eu prefiro em vez de crescer diminuir os outros 

  

se vc é não é ofensa, se vc ñ é não é com vc  

Ex: Se alguem te xingar de Filho da puta.  

Se vc é ñ é ofensa é verdade, se vc ñ é não é com vc  

-----------------------------------------------------------------------------------------------------------------------  

Não eleve a voz melhore seus argumentos  

-----------------------------------------------------------------------------------------------------------------------  

Deus é contra a guerra, mas fica ao lado de quem atira melhor 

Voltaire 

-----------------------------------------------------------------------------------------------------------------------  

Viver no exterior é bom, mas é uma merda. Viver no Brasil é uma merda, mas é bom 

Tom Jobim 

-----------------------------------------------------------------------------------------------------------------------  

Quem luta, pode perder. Quem não luta, já perdeu  

Bertolt Brecht   

-----------------------------------------------------------------------------------------------------------------------  

nada surge do nada  

do nada nada se cria 

Parménides 

-----------------------------------------------------------------------------------------------------------------------  

Quanto mais certo vc estiver mais sozinho vc anda 

-----------------------------------------------------------------------------------------------------------------------  

em um relacionamento existe no mínimo 3 pessoas  

eu, vc, e a nois 

e o eu tudo de mim não cabe em nois 

e tudo de vc não cabe e nois 

tanto que tem coisa sua que eu ñ preciso saber, pq ñ faz parte do nois, faz parde te vc  

-----------------------------------------------------------------------------------------------------------------------  

Se vc é experto de mais no seu meio social, claramente vc está vivendo com pessoas mais burras que vc 

 

-----------------------------------------------------------------------------------------------------------------------  

ansiedade é o excesso de futuro, a pessoa ñ está vivendo o presente 

só é amizade quando é testada  

 

faça qualquer coisa um milhão de vez e se torne um expert 

Pat Riley 

-----------------------------------------------------------------------------------------------------------------------  

 

If the bear is brown, lie down, if it's black, fight back and if it's white, say goodnight 

 

-----------------------------------------------------------------------------------------------------------------------  

Os circuitos de consagração social serão tanto mais eficazes, quanto maior a distância social do objeto consagrado 

Pierre Bourdieu 

Exemplo:  Se vc faz uma coisa da hora e as pessoas vem te elogiar, qual o elogio que vale mais 

        se vc fala que  q foda =  0 

        Sua mãe                        = 1 

        Irmão                             = 2 

                   Filhos                             = 3 

                    .... 

                    Um estranho               = 100 

-----------------------------------------------------------------------------------------------------------------------        

Existe duas verdades em relação ao uma carreira  

Um dia estaremos erado,   

Um dia morreremos,  

Uma carreira de sucesso é feita quando a segunda verdade acontece antes da primeira  
";

string[] _datas = new string[] {
 "01/03/2023"
,"15/02/2023"
,"07/02/2023"
,"01/02/2023"
,"25/01/2023"
,"11/01/2023"
,"11/01/2023"
,"04/01/2023"
,"27/10/2022"
,"21/10/2022"
,"14/10/2022"
,"10/10/2022"
,"22/09/2022"
,"12/09/2022"
,"09/09/2022"
,"06/09/2022"
,"05/09/2022"
,"05/09/2022"
,"01/09/2022"
,"18/08/2022"
,"03/08/2022"
,"26/04/2022"
,"26/04/2022"
,"22/04/2022"
,"20/04/2022"
,"19/04/2022"
,"12/04/2022"
,"08/04/2022"
,"07/04/2022"
,"18/03/2022"
,"01/02/2022"
,"21/01/2022"
,"11/01/2022"
,"10/01/2022"
,"27/12/2021"
,"04/11/2021"
,"23/10/2021"
,"15/10/2021"
,"05/10/2021"
,"01/10/2021"
,"28/09/2021"
,"12/09/2021"
,"31/08/2021"
,"19/08/2021"
,"26/07/2021"
,"15/07/2021"
,"23/06/2021"};