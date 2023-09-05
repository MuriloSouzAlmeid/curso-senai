USE Exercicio_1_3;

-- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
SELECT
	Veterinario.IdVeterinario AS [Id do Veterinario],
	Veterinario.NomeVeterinario AS [Nome do Veterinário],
	Veterinario.CRM AS [CRM do Veterinário],
	Veterinario.EstadoVeterinario AS [Estado do Veterinário],
	Clinica.NomeClinica AS [Clínica Onde Trabalha]
FROM
	Veterinario INNER JOIN Clinica ON Veterinario.IdClinica = Clinica.IdClinica

-- listar todas as raças que começam com a letra S
SELECT 
	RacaPet.IdRacaPet AS [Id da Raça],
	TipoPet.NomeTipoPet AS [Tipo do Pet],
	RacaPet.NomeRacaPet AS [Nome da Raça]
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
	RacaPet.NomeRacaPet AS [Raça do Pet],
	Pet.DataNascPet AS [Data de Nascimento],
	Cliente.NomeCliente AS [Dono do Pet]
FROM 
	Pet INNER JOIN Cliente ON Pet.IdCliente = Cliente.IdCliente
	INNER JOIN RacaPet ON Pet.IdRacaPet = RacaPet.IdRacaPet
	INNER JOIN TipoPet ON RacaPet.IdTipoPet = TipoPet.IdTipoPet;

/* listar todos os atendimentos mostrando o nome do veterinário que atendeu, o nome, a raça e o tipo do pet que foi atendido, 
o nome do dono do pet e o nome da clínica onde o pet foi atendido*/
SELECT * FROM Atendimento;
SELECT 
	Atendimento.IdAtendimento AS [Id do Atendimento],
	Veterinario.NomeVeterinario AS [Veterinário do Atendimento],
	Pet.NomePet AS [Nome do Pet],
	RacaPet.NomeRacaPet AS [Raça do Pet],
	TipoPet.NomeTipoPet AS [Tipo do Pet],
	Cliente.NomeCliente AS [Nome do Dono],
	Clinica.NomeClinica AS [Clínica de Atendimento],
	Atendimento.DataAtendimento AS [Data do Atendimento],
	Atendimento.ValorAtendimento AS [Valor do Atendimento]
FROM
	Atendimento INNER JOIN Pet ON Atendimento.IdPet = Pet.IdPet
	INNER JOIN Cliente ON  Pet.IdCliente = Cliente.IdCliente
	INNER JOIN RacaPet ON Pet.IdRacaPet = RacaPet.IdRacaPet
	INNER JOIN TipoPet ON RacaPet.IdTipoPet = TipoPet.IdTipoPet
	INNER JOIN Veterinario ON Atendimento.IdVeterinario = Veterinario.IdVeterinario
	INNER JOIN Clinica ON Veterinario.IdClinica = Clinica.IdClinica