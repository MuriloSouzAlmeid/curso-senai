USE Exercicio_1_3;

-- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
SELECT
	NomeVeterinario AS [Nome do Veterinario],
	NomeClinica AS [Nome da Clinica]
FROM
	Veterinario INNER JOIN Clinica ON Veterinario.IdClinica = Clinica.IdClinica

-- listar todas as raças que começam com a letra S

-- listar todos os tipos de pet que terminam com a letra O

-- listar todos os pets mostrando os nomes dos seus donos

/* listar todos os atendimentos mostrando o nome do veterinário que atendeu, o nome, a raça e o tipo do pet que foi atendido, 
o nome do dono do pet e o nome da clínica onde o pet foi atendido*/
