USE Exercicio_1_3;

-- listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)
SELECT
	NomeVeterinario AS [Nome do Veterinario],
	NomeClinica AS [Nome da Clinica]
FROM
	Veterinario INNER JOIN Clinica ON Veterinario.IdClinica = Clinica.IdClinica

-- listar todas as ra�as que come�am com a letra S

-- listar todos os tipos de pet que terminam com a letra O

-- listar todos os pets mostrando os nomes dos seus donos

/* listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, o nome, a ra�a e o tipo do pet que foi atendido, 
o nome do dono do pet e o nome da cl�nica onde o pet foi atendido*/
