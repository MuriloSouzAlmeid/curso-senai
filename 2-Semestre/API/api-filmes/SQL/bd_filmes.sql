CREATE DATABASE Filmes;

USE Filmes_Tarde;

CREATE TABLE Genero(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL
);

CREATE TABLE Filme(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero) NOT NULL,
	Titulo VARCHAR(100) NOT NULL
);

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (100) NOT NULL,
	Email VARCHAR (100) UNIQUE NOT NULL,
	Senha VARCHAR(50) NOT NULL,
	Permissao BIT NOT NULL
);

DROP TABLE Usuario;

SELECT IdUsuario, Nome, Email, Senha, CASE WHEN Usuario.Permissao = 1 THEN 'Administraor' ELSE 'Usuário Comun' END AS Permissao FROM Usuario;

INSERT INTO Usuario (Nome,Email,Senha,Permissao)
VALUES ('Murilo Souza Almeida','murilo.souza@email.com','12345',1),('Andréia Katia da Silva Souza','andreia.katia@email.com','54321',0);