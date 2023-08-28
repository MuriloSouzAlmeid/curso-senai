------------Comandos b�sicos SQL (DML - Data Manipulation Languege)------------------
--Inserir dados em uma tabela
INSERT INTO Funcionarios(NomeFuncionario, Cpf) VALUES ('Enzo', '46819484020')

--Altera dados em uma tabela (Se n�o houver condicional vai alterar em todas as linhas da coluna) 
UPDATE Funcionarios SET Cpf = '47015003805' WHERE IdFuncionario = 3;

--Deleta dados em uma tabela (Se n�o houver condicional apaga todos os dados de uma tabela, tamb�m tem como usar operadores l�gicos AND ou OR)
DELETE FROM Funcionarios WHERE IdFuncionario = 4 OR NomeFuncionario = 'Matheus';

-------------------------------Empresas------------------------------------------
--Tem que inserir a chave estrangeira manualmente
INSERT INTO Empresas (IdFuncionario, NomeEmpresa) VALUES (6, 'Ribeir�o Pires FC')