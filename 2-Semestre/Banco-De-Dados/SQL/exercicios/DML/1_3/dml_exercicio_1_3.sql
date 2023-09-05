USE Exercicio_1_3;

SELECT * FROM Cliente;
SELECT * FROM Clinica;
SELECT * FROM Veterinario;
SELECT * FROM TipoPet;
SELECT * FROM RacaPet;
SELECT * FROM Pet;
SELECT * FROM Atendimento;

INSERT INTO Cliente (NomeCliente,TelefoneCliente) VALUES ('Murilo Almeida','11947294628'),('Gabriela Akiko','11966828452');

INSERT INTO Clinica (NomeClinica,EnderecoClinica) VALUES ('PClinics','Rua Tal, n0 - Bairro Tal');

INSERT INTO Veterinario (IdClinica, NomeVeterinario, CRM, EstadoVeterinario) 
VALUES (1,'Jeferson Almeida','948335274','SP'),
		(1,'Andreia Souza','400248264','RJ');

INSERT INTO TipoPet (NomeTipoPet) VALUES ('Gato'),('Cachorro'),('Cobra');

INSERT INTO RacaPet (IdTipoPet,NomeRacaPet) VALUES (3,'Jiboia'),(1,'Siames'),(2,'Poodle');

INSERT INTO Pet (IdCliente,IdRacaPet,NomePet,DataNascPet) 
VALUES (1,3,'Nino','02-10-2002'),(2,2,'Mingau','23-08-2010'),(1,1,'Nevada','02-12-2021');

INSERT INTO Atendimento (IdPet,IdVeterinario,DataAtendimento,ValorAtendimento) 
VALUES (1,1,'23-07-2022 02:30:00 PM',700),
(3,1,'31-07-2020 08:00:00 AM',950),
(2,2,'10-03-2021 06:40:00 PM',370);