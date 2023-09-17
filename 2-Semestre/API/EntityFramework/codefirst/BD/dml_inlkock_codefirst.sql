USE 
--Casa:
inlock_games_CodeFirst;
--Senai
--inlock_games_CodeFirst_tarde;

INSERT INTO Estudio
VALUES 
--como não tem mais identity temos de preencher o id por conta própria
--a função NEWID gera o identificador único no registro
(NEWID(),'SENAI'),(NEWID(),'SESI'),(NEWID(),'SEBRAE')

SELECT * FROM Estudio

INSERT INTO Jogo
--tem que pegar o IdEstudio que está como uniqueidentifier
VALUES (NEWID(),'PING PONG','JOGO LEGAL','2023-01-01',500,'4C71D7D1-3425-42CA-8F81-F7C4CA0C8CF1'),
	   (NEWID(),'JUCAMOM','CAÇA POKEMOM','2022-03-23',2.99,'25A274D3-7D0F-4223-813F-56F109D888D7')

SELECT * FROM Jogo

INSERT INTO TiposUsuario
VALUES (NEWID(),'Administrador'),(NEWID(),'Comum')

SELECT * FROM TiposUsuario

INSERT INTO Usuario
VALUES (NEWID(),'adm@adm.com','admin','4EA89E69-DF4C-4C60-BCAF-BEE7EAFED1F1'),
	   (NEWID(),'comum@comum.com','comum','02079351-FA84-437B-A5A7-0B032B7D4D66')

SELECT * FROM Usuario