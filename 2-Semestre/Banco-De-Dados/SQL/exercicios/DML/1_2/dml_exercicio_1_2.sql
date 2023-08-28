USE Exercicio_1_2;

SELECT * FROM Aluguel;

INSERT INTO 
	Cliente (NomeCliente, CpfCliente) 
VALUES
	('Murilo Souza', '64829471903'),
	('Matheus Almeida', '54619384023'),
	('Gabriela Akiko', '26839856829');

INSERT INTO 
	Locadora (NomeLocadora) 
VALUES 
	('AutoAluga+');

INSERT INTO 
	Marca (NomeMarca) 
VALUES 
	('GM'),
	('FORD'),
	('FIAT');

INSERT INTO 
	Modelo (NomeModelo, AnoModelo, IdMarca) 
VALUES 
	('Onix', '2012', 1),
	('Fiesta','2006',2),
	('Argo','2017',3);

INSERT INTO 
	Veiculo (IdLocadora, IdModelo, PlacaVeiculo)
VALUES 
	(1,1,'ENA6728'),
	(1,2,'ODJ2356'),
	(1,3,'SGQ2374');

INSERT INTO 
	Aluguel(IdCliente,IdVeiculo,DataInicioAluguel,DataFinalAluguel,ValorAluguel) 
VALUES 
	(1,2,'01-07-2020 02:30:00 PM','15-07-2020 04:00:00 PM', 700),
	(2,3,'17-02-2013 08:00:00 AM','28-02-2013 10:00:00 AM',1500),
	(2,1,'02-10-2012 03:40:00 PM','22-10-2012 09:00:00 AM',1980),
	(3,2,'07-12-2022 05:30:00 PM','26-12-2022 12:00:00 AM',1740),
	(1,3,'12-03-2018 01:20:00 PM','25-03-2028 02:50:00 PM',1260),
	(2,1,'10-05-2010 08:10:00 AM','20-05-2010 10:00:00 AM',570);