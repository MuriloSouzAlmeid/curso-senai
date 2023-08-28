USE Exercicio_1_1;

-- listar as pessoas em ordem alfabética reversa, mostrando seus telefones, seus e-mails e suas CNHs
SELECT 
	NomePessoa,NumeroTelefone,EnderecoEmail 
FROM 
	Pessoa INNER JOIN Telefone ON Pessoa.IdPessoa = Telefone.IdPessoa
	INNER JOIN Email ON Pessoa.IdPessoa = Email.IdPessoa
