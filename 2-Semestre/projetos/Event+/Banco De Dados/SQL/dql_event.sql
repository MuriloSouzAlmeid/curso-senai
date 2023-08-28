USE [Event+_Tarde];

SELECT * FROM TiposDeUsuario;
SELECT * FROM TiposDeEvento;
SELECT * FROM Instituicao;
SELECT * FROM Usuario;
SELECT * FROM Evento;
SELECT * FROM PresencasEvento;
SELECT * FROM ComentarioEvento;

-- Criar script para consulta exibindo os seguintes dados

/*Usar JOIN

Nome do usuário
Tipo do usuário
Data do evento
Local do evento (Instituição)
Titulo do evento
Nome do evento
Descrição do evento
Situação do evento
Comentário do evento
*/

SELECT --Selecionando as colunas com os dados a serem exibidos
	Usuario.NomeUsuario AS [Nome do Usuário],
	TiposDeUsuario.TituloTipoUsuario AS [Tipo de Usuário],
	Evento.DataEvento AS [Data do Evento],
	--Instituicao.NomeFantasia + ' - ' + Instituicao.Endereco AS [Local do Evento], --Concatecação Simples
	CONCAT (Instituicao.NomeFantasia, ' - ', Instituicao.Endereco) AS [Local do Evento], --Função de concatenação
	TiposDeEvento.TituloTipoDeEvento AS [Tipo de Evento],
	Evento.NomeEvento AS [Nome do Evento],
	Evento.DescricaoEvento AS [Descrição do Evento],
	CASE WHEN PresencasEvento.SituacaoPresenca = 1 THEN 'Confirmado' ELSE 'Não Confirmado' END AS [Presença No Evento], --Estrutura Condicional SQL
	ComentarioEvento.DescricaoComentario AS [Comentario do Evento]
FROM Evento 
	INNER JOIN TiposDeEvento ON Evento.IdTipoDeEvento = TiposDeEvento.IdTipoDeEvento
	INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
	INNER JOIN ComentarioEvento ON Evento.IdEvento = ComentarioEvento.IdEvento
	INNER JOIN Usuario ON Usuario.IdUsuario = ComentarioEvento.IdUsuario
	INNER JOIN PresencasEvento ON Evento.IdEvento = PresencasEvento.IdEvento AND Usuario.IdUsuario = PresencasEvento.IdUsuario
	INNER JOIN TiposDeUsuario ON Usuario.IdTipoUsuario = TiposDeUsuario.IdTipoUsuario;