USE [Event+_Tarde];

--Comandos DML
INSERT INTO TiposDeUsuario (TituloTipoUsuario)
VALUES
	('Administrador'),
	('Comun')
;

INSERT INTO TiposDeEvento(TituloTipoDeEvento, DescricaoTipoDeEvento)
VALUES
	('Front-End', 'Um evento com atra��es e palestras voltadas para o desenvolvimento Front-End'),
	('Back-End', 'Um evento com atra��es e palestras voltadas para o desenvolvimento Back-End'),
	('Full Stack', 'Um evento com atra��es e palestras voltadas tanto para o desenvolvimento Front-End quanto para o desenvolvimento Back-End'),
	('Dev Mobile', 'Um evento com atra��es e palestras voltados para o desenvolvimento e prototipa��o de aplica��es Mobile')

INSERT INTO Instituicao(NomeFantasia,CNPJ,Endereco)
VALUES
	('DevSchool', '64826351947625', 'Rua dos Bobos, n0 - Bairro dos Galos');

UPDATE Instituicao SET Endereco = 'Rua dos Bobos, n0 - Bairro dos Galos, Ribeir�o Pires' WHERE IdInstituicao = 1; 

INSERT INTO Usuario (IdTipoUsuario,NomeUsuario,EmailUsuario,SenhaUsuario,TelefoneUsuario)
VALUES 
	(1,'Murilo Souza Almeida','murilo.souza@email.com','Murilo12$','11995135732'),
	(2,'Andr�ia Katia da Silva Souza','deia.katia@email.com','DetiaKatia123','11986328462'),
	(2,'Jeferson Almeida Junior','jeferson.ajr@email.com','JefersonJR27%','11984017552'),
	(2,'Lucas Lago','lucas.lago@email.com','LucasOP12','11945880692'),
	(2,'Gabriela Akiko','gabi.akiko@email.com','AkikoGabi64&','11956380145'),
	(2,'Gabriel Dantas','gc.dantas@email.com','GCDantas08','11956281374'),
	(2,'Mariana Zacharyas','mari.zacharyas@email.com','ZacharyasMari27','11955639164');

INSERT INTO Evento (IdTipoDeEvento,IdInstituicao,NomeEvento,DescricaoEvento,DataEvento,HoraEvento)
VALUES 
	--(2,1,'Estruturas Condicionais em C#','Um evento em forma de oficina com o objetivo de ensinar aos participantes como aplicar estruturas condicionais em l�gica de programa��o usando a linguagem C#.','19-09-2023','13:30:00'),
	(4,1,'Prototipagem de Jogos','Um evento em forma de oficina com o objetivo de ensinar aos participantes como funciona o processo de prototipa��o de jogos para Mobile usando a ferramenta Unity 3D','22-11-2023','14:00:00'),
	(1,1,'Introdu��o ao Framework React.js','Um evento em forma de palestra com o objetivo de ensinar aos participantes quais s�o as principais caracter�sticas, utiliza��es e possibilidades do framework React.js assim como mostrar suas aplica��es no mercado de trabalho','08-05-2024','09:20:00:00'),
	(3,1,'Utilizando o Razor Pages para cria��es de p�ginas web','Um evento em forma de oficina com o objetivo de ensinar aos participantes como criar e manipular arquivos cshtml com a utiliza��o do framework Razor Pages do ASP.NET Core','15-06-2024','18:00:00');

INSERT INTO PresencasEvento (IdUsuario,IdEvento,SituacaoPresenca)
VALUES 
	(5,4,1),
	(6,1,1),
	(7,2,1),
	(8,3,1),
	(9,1,0),
	(10,2,1),
	(10,3,0),
	(9,4,1);

INSERT INTO ComentarioEvento (IdUsuario,IdEvento,TituloComentario,DescricaoComentario,DataComentario,ComentarioExibido)
VALUES
	(10,3,'Um grande Evento!','Foi um grande evento esse, muito divertido e din�mico. Meus parab�ns ao palestrante, um �tico profissional!','10-05-2024',1),
	(9,1,'Evento do Caralho!','Muito dif�cil de entender a oficina e o professor n�o explicou direito inventando palavras novas a cada momento. Vai se FUDER!!','22-09-2023',0);
