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

Nome do usu�rio
Tipo do usu�rio
Data do evento
Local do evento (Institui��o)
Titulo do evento
Nome do evento
Descri��o do evento
Situa��o do evento
Coment�rio do evento
*/

SELECT --Selecionando as colunas com os dados a serem exibidos
	Usuario.NomeUsuario AS [Nome do Usu�rio],
	TiposDeUsuario.TituloTipoUsuario AS [Tipo de Usu�rio],
	Evento.DataEvento AS [Data do Evento],
	--Instituicao.NomeFantasia + ' - ' + Instituicao.Endereco AS [Local do Evento], --Concateca��o Simples
	CONCAT (Instituicao.NomeFantasia, ' - ', Instituicao.Endereco) AS [Local do Evento], --Fun��o de concatena��o
	TiposDeEvento.TituloTipoDeEvento AS [Tipo de Evento],
	Evento.NomeEvento AS [Nome do Evento],
	Evento.DescricaoEvento AS [Descri��o do Evento],
	CASE WHEN PresencasEvento.SituacaoPresenca = 1 THEN 'Confirmado' ELSE 'N�o Confirmado' END AS [Presen�a No Evento], --Estrutura Condicional SQL
	ComentarioEvento.DescricaoComentario AS [Comentario do Evento]
FROM Evento 
	INNER JOIN TiposDeEvento ON Evento.IdTipoDeEvento = TiposDeEvento.IdTipoDeEvento
	INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
	INNER JOIN ComentarioEvento ON Evento.IdEvento = ComentarioEvento.IdEvento
	INNER JOIN Usuario ON Usuario.IdUsuario = ComentarioEvento.IdUsuario
	INNER JOIN PresencasEvento ON Evento.IdEvento = PresencasEvento.IdEvento AND Usuario.IdUsuario = PresencasEvento.IdUsuario
	INNER JOIN TiposDeUsuario ON Usuario.IdTipoUsuario = TiposDeUsuario.IdTipoUsuario;