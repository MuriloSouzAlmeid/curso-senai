-- Cria��o da estrutura --
CREATE DATABASE dev_db;
GO

USE dev_db;
GO

CREATE TABLE Professor(
	ProfessorId INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(255) NOT NULL,
	Email VARCHAR(255) NOT NULL,
	Senha VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Turma(
	TurmaId INT PRIMARY KEY IDENTITY,
	ProfessorId INT FOREIGN KEY REFERENCES Professor(ProfessorId),
	Nome VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Atividade(
	AtividadeId INT PRIMARY KEY IDENTITY,
	TurmaId INT FOREIGN KEY REFERENCES Turma(TurmaId),
	Descricao VARCHAR(255) NOT NULL
);
GO

-- Inser��o de dados (copula��o)

INSERT INTO Professor(Nome, Email, Senha) VALUES ('Matheus', 'math@email.com', '1234'),('Mayara', 'may@email.com', '5678'),('Miguel', 'mig@email.com', '9090');
GO

INSERT INTO Turma(Nome, ProfessorId) VALUES ('Matem�tica', 1),('Qu�mica', 2),('Educa��o F�sica', 3);
GO

INSERT INTO Atividade(Descricao, TurmaId) VALUES ('Limites laterais', 1), ('Teoria do Orbital Molecular (TOM)', 2), ('Bioqu�mica', 3);
GO