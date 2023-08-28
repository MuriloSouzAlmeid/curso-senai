------------Comandos básicos SQL (DDL - Data Defination Languege)------------------
--Cria uma base de dados
CREATE DATABASE MuriloSouza;

--Seleciona a base para uso
USE MuriloSouza;

---------------Cria uma tabela------------------
--Uma tabela apenas com uma chave primária
CREATE TABLE Funcionarios(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	NomeFuncionario VARCHAR(50),
	Salario INT
);

--Uma tabela com uma chave estrangeira
CREATE TABLE Empresas(
	IdEmpresa INT PRIMARY KEY IDENTITY,
	IdFuncionario INT FOREIGN KEY REFERENCES Funcionarios(IdFuncionario),
	NomeEmpresa VARCHAR(50)
);

----------------------Altera uma tabela----------------------------
--Adiciona uma coluna
ALTER TABLE Funcionarios ADD Cpf VARCHAR(11);

--Deleta uma coluna
ALTER TABLE Funcionarios DROP COLUMN Salario;

------------Deleta uma tabela ou uma Base de dados inteira-----------
--Deleta uma tabela
DROP TABLE Empresas;

--Deleta toda uma base de dados (tem que estar em um banco de nível superior)
USE master;
DROP DATABASE MuriloSouza;