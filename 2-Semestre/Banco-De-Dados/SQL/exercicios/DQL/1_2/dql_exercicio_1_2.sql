USE Exercicio_1_2;

-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
SELECT 
	DataInicioAluguel AS [Data Inicial],
	DataFinalAluguel AS [Data Final],
	NomeCliente AS [Nome Do Cliente],
	NomeModelo AS [Modelo Do Carro]
FROM 
	Aluguel INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente
	INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
	INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo;

-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro
SELECT 
	NomeCliente AS [Nome do Cliente],
	DataInicioAluguel AS [Data Inicial],
	DataFinalAluguel AS [Data Final],
	NomeModelo AS [Modelo do Carro]
FROM
	Aluguel INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente
	INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
	INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo
WHERE
	Cliente.NomeCliente = 'Murilo Souza';