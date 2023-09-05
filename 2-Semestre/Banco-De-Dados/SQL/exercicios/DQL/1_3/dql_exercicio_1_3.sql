USE Exercicio_1_3;

-- listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)
SELECT
	Veterinario.IdVeterinario AS [Id do Veterinario],
	Veterinario.NomeVeterinario AS [Nome do Veterin�rio],
	Veterinario.CRM AS [CRM do Veterin�rio],
	Veterinario.EstadoVeterinario AS [Estado do Veterin�rio],
	Clinica.NomeClinica AS [Cl�nica Onde Trabalha]
FROM
	Veterinario INNER JOIN Clinica ON Veterinario.IdClinica = Clinica.IdClinica

-- listar todas as ra�as que come�am com a letra S
SELECT 
	RacaPet.IdRacaPet AS [Id da Ra�a],
	TipoPet.NomeTipoPet AS [Tipo do Pet],
	RacaPet.NomeRacaPet AS [Nome da Ra�a]
FROM RacaPet
	INNER JOIN TipoPet ON RacaPet.IdTipoPet = TipoPet.IdTipoPet
WHERE 
	RacaPet.NomeRacaPet LIKE 'S%';

-- listar todos os tipos de pet que terminam com a letra O
SELECT 
	TipoPet.IdTipoPet AS [Id do Tipo],
	TipoPet.NomeTipoPet AS [Nome do Tipo de Pet]
FROM 
	TipoPet
WHERE
	TipoPet.NomeTipoPet LIKE '%o';

-- listar todos os pets mostrando os nomes dos seus donos
SELECT * FROM Pet;
SELECT 
	Pet.IdPet AS [Id do Pet],
	Pet.NomePet AS [Nome do Pet],
	TipoPet.NomeTipoPet AS [Tipo do Pet],
	RacaPet.NomeRacaPet AS [Ra�a do Pet],
	Pet.DataNascPet AS [Data de Nascimento],
	Cliente.NomeCliente AS [Dono do Pet]
FROM 
	Pet INNER JOIN Cliente ON Pet.IdCliente = Cliente.IdCliente
	INNER JOIN RacaPet ON Pet.IdRacaPet = RacaPet.IdRacaPet
	INNER JOIN TipoPet ON RacaPet.IdTipoPet = TipoPet.IdTipoPet;

/* listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, o nome, a ra�a e o tipo do pet que foi atendido, 
o nome do dono do pet e o nome da cl�nica onde o pet foi atendido*/
SELECT * FROM Atendimento;
SELECT 
	Atendimento.IdAtendimento AS [Id do Atendimento],
	Veterinario.NomeVeterinario AS [Veterin�rio do Atendimento],
	Pet.NomePet AS [Nome do Pet],
	RacaPet.NomeRacaPet AS [Ra�a do Pet],
	TipoPet.NomeTipoPet AS [Tipo do Pet],
	Cliente.NomeCliente AS [Nome do Dono],
	Clinica.NomeClinica AS [Cl�nica de Atendimento],
	Atendimento.DataAtendimento AS [Data do Atendimento],
	Atendimento.ValorAtendimento AS [Valor do Atendimento]
FROM
	Atendimento INNER JOIN Pet ON Atendimento.IdPet = Pet.IdPet
	INNER JOIN Cliente ON  Pet.IdCliente = Cliente.IdCliente
	INNER JOIN RacaPet ON Pet.IdRacaPet = RacaPet.IdRacaPet
	INNER JOIN TipoPet ON RacaPet.IdTipoPet = TipoPet.IdTipoPet
	INNER JOIN Veterinario ON Atendimento.IdVeterinario = Veterinario.IdVeterinario
	INNER JOIN Clinica ON Veterinario.IdClinica = Clinica.IdClinica