CREATE DATABASE inlock_games_dbFirst_tarde
USE inlock_games_dbFirst_tarde

CREATE TABLE Estudio
(
	--deixa de ser INT com a caracter�stica IDENTITY e passa a ser UNIQUEIDENTIFIER (o �nico tipo de dado compat�vel com o GUID)
	IdEstudio UNIQUEIDENTIFIER PRIMARY KEY,
	Nome VARCHAR(100) NOT NULL
)

CREATE TABLE Jogo
(
	IdJogo UNIQUEIDENTIFIER PRIMARY KEY,
	IdEstudio UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Estudio(IdEstudio),
	Nome VARCHAR(100) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	DataLancamento DATE NOT NULL,
	Valor SMALLMONEY NOT NULL
)

CREATE TABLE TiposUsuario
(
	IdTipoUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	Titulo VARCHAR(100) NOT NULL
)

CREATE TABLE Usuario
(
	IdUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	IdTipoUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario),
	Email VARCHAR(100) NOT NULL,
	Senha VARCHAR(100) NOT NULL
)

INSERT INTO Estudio
VALUES 
--como n�o tem mais identity temos de preencher o id por conta pr�pria
--a fun��o NEWID gera o identificador �nico no registro
(NEWID(),'SENAI'),(NEWID(),'SESI'),(NEWID(),'SEBRAE')

SELECT * FROM Estudio

INSERT INTO Jogo
--tem que pegar o IdEstudio que est� como uniqueidentifier
VALUES (NEWID(),'80565805-A49B-4E61-B716-DFBCCB0F6425','PING PONG','JOGO LEGAL','2023-01-01',500),
	   (NEWID(),'80565805-A49B-4E61-B716-DFBCCB0F6425','JUCAMOM','CA�A POKEMOM','2022-03-23',2.99)

SELECT * FROM Jogo

INSERT INTO TiposUsuario
VALUES (NEWID(),'administrador'),(NEWID(),'comum')

SELECT * FROM TiposUsuario

INSERT INTO Usuario
VALUES (NEWID(),'F88B2220-E61F-4EC6-8564-8D946CCC388F','adm@adm.com','admin'),
	   (NEWID(),'22819F3D-8072-451B-B839-CE8EF05BF25E','comum@comum.com','comum')

SELECT * FROM Usuario