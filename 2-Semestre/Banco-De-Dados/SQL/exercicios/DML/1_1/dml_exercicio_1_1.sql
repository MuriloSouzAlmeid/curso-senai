INSERT INTO 
	Pessoa (NomePessoa, CnhPessoa) 
VALUES 
	('Murilo Souza', '5682018472'),
	('Gabriela Akiko', '4682984671'),
	('Gabriel Dantas', '4682479173'); 

INSERT INTO 
	Telefone (IdPessoa, NumeroTelefone) 
VALUES 
	(2, '11957027492'),
	(2, '11936402479'),
	(3, '11946294916'),
	(1, '11956208593');

INSERT INTO 
	Email (IdPessoa, EnderecoEmail)
VALUES 
	(2, 'gabriela.akiko@emial.com'),
	(3, 'gcdantas@email.com'),
	(3, 'gabriel@email.com'),
	(1, 'murilo.souza@email.com'),
	(3, 'dantas.gabriel@email.com');

SELECT * FROM Pessoa;
SELECT * FROM Telefone;
SELECT * FROM Email;