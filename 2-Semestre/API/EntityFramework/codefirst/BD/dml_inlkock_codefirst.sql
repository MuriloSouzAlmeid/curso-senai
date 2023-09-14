
INSERT INTO Estudio
VALUES 
--como não tem mais identity temos de preencher o id por conta própria
--a função NEWID gera o identificador único no registro
(NEWID(),'SENAI'),(NEWID(),'SESI'),(NEWID(),'SEBRAE')

SELECT * FROM Estudio

INSERT INTO Jogo
--tem que pegar o IdEstudio que está como uniqueidentifier
VALUES (NEWID(),'PING PONG','JOGO LEGAL','2023-01-01',500,'7C504B43-5B5D-4AB2-A904-24A30AA81985'),
	   (NEWID(),'JUCAMOM','CAÇA POKEMOM','2022-03-23',2.99,'65D58A1E-32DB-4F55-BAB5-7268E43F7283')

SELECT * FROM Jogo

INSERT INTO TiposUsuario
VALUES (NEWID(),'Administrador'),(NEWID(),'Comum')

SELECT * FROM TiposUsuario

INSERT INTO Usuario
VALUES (NEWID(),'adm@adm.com','admin','8868F802-DC18-4C02-89DD-F3151B7FDEE8'),
	   (NEWID(),'comum@comum.com','comum','6CA2D531-4F4B-4F28-BDB3-BA54B94664BC')

SELECT * FROM Usuario