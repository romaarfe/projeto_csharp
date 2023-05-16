# PROJETO DE 25 HORAS EM C# 
## PARA CURSO DE PROGRAMADOR DE INFORMÁTICA - IEFP BRAGA

### Projeto de C# em Windows Forms emulando um  jogo de RPG antigo com texto corrido

#### Título e objetivo
- Heróis vs Monstros
- Pequeno jogo de RPG, onde jogador tenta vencer quatro monstros buscados “aleatoriamente” na base de dados

#### Autor, data, contexto do trabalho
- Rodrigo Fernandes, 2023-04-20, Projeto de Programação (25 horas)

#### Descrição do problema
- Pequeno jogo de RPG em C# e Windows Forms
- Tem como objetivo tentar vencer 4 monstros buscados “aleatoriamente” na base de dados
- Todo processo pode ser feito criando e registando um novo personagem na base de dados ou indo buscar algum previamente criado

#### Ferramentas e versões
- Início do planeamento em 2023-03-15
- Reformulação do Diagrama de Entidades em 2023-03-22
- Modificações em 2023-04-02:
-- Alteração do nome do projeto
-- Retirada de alguns Forms
-- Substituição do mapa por botões de navegação
-- Alteração sutil na base de dados (Design)
-- Simplificação do projeto para módulo de 25 horas

### - Tela Inicial
- Inicia o Form com imagem de fundo e botões remodelados para parecerem 3D
- Toca uma música tema
- Ao clicar no botão Novo Jogo, fecha o Form atual e abre o Form NovoJogo
- Ao clicar no botão Carregar Jogo, fecha o Form atual e abre o Form CarregarJogo

<img width="406" alt="Captura de ecrã 2023-04-26, às 15 20 53" src="https://user-images.githubusercontent.com/91450312/234605600-5a0e3627-a75c-405a-9877-f0830b00d51b.png">

### - Novo Jogo
- Inicia o Form com imagem de fundo e com botões remodelados para aparecerem 3D
- Toca uma música tema igual a anterior
- Há um botão para Voltar ao Form anterior
- Há uma textbox para ser preenchida com o Nome do Herói
- Há um botão com imagem de um dado que quando clicado ativa métodos que estão ligados às decisões “randômicas”. Desta forma são gerados valores que em alguns métodos onde são testadas condições para definirem o tipo de Arma e Armadura, ou mesmo utilizar esse valor como Id na hora de buscar na Base de Dados uma Magia Ofensiva e uma Magia Defensiva
- Ao clicar no botão Iniciar Jogo, é verificado na Base de Dados se o nome já existe, e/ou se a textbox foi preenchida, além de testar se já foi clicado no botão do dado
- Caso tudo esteja bem, é criado um registo na Base de Dados, fecha o Form atual e abre o Form Encontro

<img width="403" alt="Captura de ecrã 2023-04-26, às 15 22 53" src="https://user-images.githubusercontent.com/91450312/234606325-2451915a-534e-42d0-be75-b2ae96dee4ce.png">

### - Carregar Jogo

- Inicia o Form com imagem de fundo e com botões remodelados para aparecerem 3D
- Toca uma música tema igual a anterior
- Caso já existam Heróis criados anteriormente e registados na Base de Dados, os seus nomes são apresentados numa listbox
- Há um botão para Voltar ao Form anterior
- Ao selecionar um dos Heróis e clicar em Iniciar Jogo, fecha o Forma atual e abre o Form Encontro

<img width="403" alt="Captura de ecrã 2023-04-26, às 15 22 27" src="https://user-images.githubusercontent.com/91450312/234606437-2302b5ce-fc07-4967-8131-16aa1630fc3d.png">

### - Encontro

- Inicia o Form com imagem de fundo diferente da anterior, formato diferente e com botões remodelados para aparecerem 3D
- Toca uma música tema diferente da anterior
- Busca na Base de Dados o Herói criado ou selecionado e mantém suas informações no programa. Estas informações são configuradas e apresentadas parcialmente em labels ou utilizadas em botões
- Tem início do Encontro onde informações são apresentadas numa listbox, emulando um local fictício que é a Cidade dos Sacro-Montes. As frases são apresentadas pausadamente nesta lisbox, através de um mecanismo de async e Task.Delay
- Existem 4 botões com Setas de Navegação, onde cada um abre um evento em um local fictício distinto (Floresta, Montanha, Tundra e Deserto) quando um deles é clicado. Há também uma Contagem de Encontros
- Em cada um destes botões é gerado um valor “randômico” e pesquisado na Base de Dados, na tabela dos Monstros e suas informações são carregadas no programa
- Há um registo na Base de Dados, na tabela Encontro, do local, do nome do Herói e o nome do Monstro
- Existem outros 3 botões que são ativados neste momento onde é possível, ao clicar, gerar um Ataque contra o Monstro, usar uma Magia Ofensiva contra o Monstro ou usar uma Magia Defensiva no próprio Herói. Estes efeitos envolvem uma matemática de valor de Ataque contra o valor de Defesa, onde o valor que extrapola é retirado nos Pontos de Vida Atuais, seja do Herói ou do Monstro
- Caso os Pontos de Vida Atuais chegarem à zero, o Monstro morre e são reativadas as setas de navegação. Caso isso ocorra com o Herói, então este Form é fechado, e é aberto o Form GameOver. Isto conta como uma Derrota.
- Toda vez que um desses botões é clicado, há a emulação da tela tremer, através da Thread e do Sleep
- Ao se atingir 4 na Contagem de Encontros, o Form atual é fechado, para então abrir o Form GameOver. Isso conta como uma Vitória.

<img width="941" alt="Captura de ecrã 2023-04-26, às 15 23 28" src="https://user-images.githubusercontent.com/91450312/234606353-531a6e7f-ddfe-4134-a7fe-ed478a223a62.png">

### - Game Over

- Inicia o Form com imagem de fundo semelhante às primeiras, formato semelhante e com botões remodelados para aparecerem 3D
- Toca uma música tema diferente das anteriores
- Caso este Form tenha sido iniciado por uma Derrota, os registos do Herói são apagados da Base de Dados, tanto na tabela Encontro quanto na Herói.
- Caso este Form tenha sido iniciado por uma Vitória, alguns registos do Herói são atualizados na Base de Dados. E são apresentados numa DataGridView os nomes dos locais, o nome do Herói e os nomes dos 4 Monstros enfrentados neste último Encontro

<img width="407" alt="Captura de ecrã 2023-04-26, às 15 25 02" src="https://user-images.githubusercontent.com/91450312/234606751-9c9ff4c4-a7e3-4d46-97be-d65f111357e6.png">

#### Lista de tabelas, campos e tipos
•	Magia:
- Id - INT, NN, PK, AI
- Nome - VARCHAR (50), NN
- Tipo - CHAR (10), NN
- Descritivo - VARCHAR (50)

•	Heroi:
- Id - INT, NN, PK, AI
- Nome - VARCHAR (50), NN
- Nivel - INT, NN
- PontosDeVida - INT, NN
- Arma - VARCHAR (50)
- Armadura - VARCHAR (50)
- MagiaOfensiva - VARCHAR (50), NN
- MagiaDefensiva - VARCHAR (50), NN
- RIP - BIT

•	Encontro:
o	Id - INT, NN, PK, AI
o	Descritivo - VARCHAR (100)
o	IdHeroi - INT, NN, FK
o	IdMonstro - INT, NN, FK

•	Monstro:
o	Id - INT, NN, PK, AI
o	Nome - VARCHAR (50), NN
o	Dificuldade - INT, NN
o	AtaqueNormal - VARCHAR (50)
o	AtaquePoderoso - VARCHAR (50)
o	AtaqueEspecial - VARCHAR (50)

#### Namespaces
•	HeroisMonstros
•	Diversos

#### Classes e métodos
•	TelaInicial
o	ConfigurarBotoes( )
o	TocarMusicaTema( )

•	NovoJogo
o	ConfigurarBotoes( )
o	RolarPontosDeVida( )
o	RolarArma( )
o	RolarArmadura( )
o	RolarMagiaOfensiva( )
o	RolarMagiaDefensiva( )
o	PesquisarNaBaseDeDados( )
o	RegistrarNaBaseDeDados( )

•	CarregarJogo
o	ConfigurarBotoes( )
o	PreencherLista( )

•	Encontro
o	TocarMusicaTema( )
o	ConfigurarBotoes( )
o	BloquearBotoesDeAcao( )
o	AtivarBotoesDeAcao( )
o	BloquearSetasDeNavegacao( )
o	AtivarSetasDeNavegacao( )
o	TremerTela( )
o	BuscarHeroi( )
o	ConfigurarHeroi( )
o	IniciarEncontro( )
o	BuscarMonstro( )
o	MonstroAtacar( )
o	FinalizarAventura( )

•	GameOver
o	FinalDoJogo( )
o	RegistrarVitoria( )
o	RegistrarDerrota( )

•	Conecta
o	BuscarDados( )

•	Configuracoes


#### Outras informações
•	Material Extra (Resources):
o	Fontes
o	Imagens
o	Música

