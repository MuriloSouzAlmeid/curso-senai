CREATE DATABASE Exercicio_1_1;

USE Exercicio_1_1;

CREATE TABLE Pessoa(
	IdPessoa INT PRIMARY KEY IDENTITY,
	NomePessoa VARCHAR(50) NOT NULL,
	CnhPessoa CHAR(10) NOT NULL UNIQUE
);

CREATE TABLE Telefone(
	IdTelefone INT PRIMARY KEY IDENTITY,
	IdPessoa INT FOREIGN KEY REFERENCES Pessoa(IdPessoa) NOT NULL,
	NumeroTelefone VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE Email(
	IdEmail INT PRIMARY KEY IDENTITY,
	IdPessoa INT FOREIGN KEY REFERENCES Pessoa(IdPessoa) NOT NULL,
	EnderecoEmail Varchar(50) NOT NULL UNIQUE
);

SELECT * FROM Pessoa;
SELECT * FROM Telefone;
SELECT * FROM Email;