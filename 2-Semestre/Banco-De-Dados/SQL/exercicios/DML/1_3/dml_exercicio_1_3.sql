USE Exercicio_1_3;

SELECT * FROM Cliente;
SELECT * FROM Clinica;
SELECT * FROM Veterinario;
SELECT * FROM TipoPet;
SELECT * FROM RacaPet;
SELECT * FROM Pet;
SELECT * FROM Atendimento;

INSERT INTO Cliente (NomeCliente,TelefoneCliente) VALUES ('Murilo Almeida','11947294628'),('Gabriela Akiko','11966828452');

INSERT INTO Clinica (NomeClinica,EnderecoClinica) VALUES ('HelPPet','Rua Tal, n0 - Bairro Tal');

INSERT INTO Veterinario (IdClinica, NomeVeterinario) VALUES (1,'Jeferson Almeida'),(1,'Andreia Souza');

INSERT INTO TipoPet (NomeTipoPet) VALUES ('Gato'),('Cachorro'),('Passarinho');

INSERT INTO RacaPet (IdTipoPet,NomeRacaPet) VALUES (3,'Calopsita'),(1,'Siames'),(2,'Poodle');

INSERT INTO Pet (IdCliente,IdRacaPet,NomePet,DataNascPet) 
VALUES (3,3,'Nino','02-10-2002'),(4,2,'Mingau','23-08-2010'),(3,1,'Nigel','02-12-2021');

INSERT INTO Atendimento (IdPet,IdVeterinario,DataAtendimento,ValorAtendimento) 
VALUES (6,1,'23-07-2022 02:30:00 PM',700),
(8,1,'31-07-2020 08:00:00 AM',950),
(7,2,'10-03-2021 06:40:00 PM',370);