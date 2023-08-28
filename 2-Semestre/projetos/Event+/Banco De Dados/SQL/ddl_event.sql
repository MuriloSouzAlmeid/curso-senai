--DDL - Data Defination Language

--criar o banco de dados
CREATE DATABASE [Event+_Tarde];

USE [Event+_Tarde];

--criar as tabelas
CREATE TABLE TiposDeUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE TiposDeEvento
(
	IdTipoDeEvento INT PRIMARY KEY IDENTITY,
	TituloTipoDeEvento VARCHAR(50) NOT NULL,
	DescricaoTipoDeEvento VARCHAR(250) NOT NULL
);

--adiciona uma chave para uma coluna já criada
ALTER TABLE TiposDeEvento ADD UNIQUE (TituloTipoDeEvento);

CREATE TABLE Instituicao
(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(200) NOT NULL,
	CNPJ CHAR(14) NOT NULL UNIQUE,
	Endereco VARCHAR(200) NOT NULL 
);

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TiposDeUsuario(IdTipoUsuario) NOT NULL,
	NomeUsuario VARCHAR(100) NOT NULL,
	EmailUsuario VARCHAR(100) NOT NULL UNIQUE,
	SenhaUsuario VARCHAR(100) NOT NULL,
	TelefoneUsuario VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE Evento
(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdTipoDeEvento INT FOREIGN KEY REFERENCES TiposDeEvento(IdTipoDeEvento) NOT NULL,
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao) NOT NULL,
	NomeEvento VARCHAR(200) NOT NULL,
	DescricaoEvento VARCHAR(500) NOT NULL,
	DataEvento DATE NOT NULL,
	HoraEvento TIME NOT NULL
);

CREATE TABLE PresencasEvento
(
	IdPresencasEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	--Valor padrão
	SituacaoPresenca BIT DEFAULT(0)
);

CREATE TABLE ComentarioEvento
(
	IdComentarioEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	TituloComentario VARCHAR(50) NOT NULL,
	DescricaoComentario VARCHAR(500) NOT NULL,
	DataComentario DATE NOT NULL,
	ComentarioExibido BIT DEFAULT(0)
);