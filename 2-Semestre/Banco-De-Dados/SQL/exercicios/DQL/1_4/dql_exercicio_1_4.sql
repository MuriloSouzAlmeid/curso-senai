USE Exercicio_1_4;

-- listar todos os usu�rios administradores, sem exibir suas senhas
SELECT 
	Usuario.IdUsuario AS [Id do Usu�rio],
	Usuario.NomeUsuario AS [Nome do Usu�rio],
	Usuario.EmailUsuario AS [Email do Usu�rio],
	Permissao.TipoPermissao AS [N�vel de Permissao]
FROM Usuario
	INNER JOIN Permissao ON Usuario.IdPermissao = Permissao.IdPermissao;

-- listar todos os �lbuns lan�ados ap�s o um determinado ano de lan�amento
SELECT 
	Album.IdAlbum AS [Album],
	Plataforma.NomePlataforma AS [Plataforma],
	Empresa.NomeEmpresa AS [Empresa],
	Artista.NomeArtista AS [Artista],
	Album.TituloAlbum AS [T�tulo do �lbum],
	Estilo.NomeEstilo AS [Estilo],
	Album.LancamentoAlbum AS [Lan�amento do �lbum],
	Album.DuracaoAlbum AS [Dura��o do �lbum],
	Album.LocalizacaoAlbum AS [Localiza��o do �lbum],
	CASE WHEN ALbum.AlbumAtivo = 'S' THEN	'Sim' ELSE 'N�o' END AS [�lbum Ativo]
FROM Album
	INNER JOIN Artista ON Album.IdArtista = Artista.IdArtista
	INNER JOIN AlbumEstilo ON Album.IdAlbum = AlbumEstilo.IdAlbum
	INNER JOIN Estilo ON AlbumEstilo.IdEstilo = Estilo.IdEstilo
	INNER JOIN Plataforma ON ALbum.IdPlataforma = Plataforma.IdPlataforma
	INNER JOIN Empresa ON Plataforma.IdEmpresa = Empresa.IdEmpresa
WHERE 
	Year(Album.LancamentoAlbum) >= 2007; 

-- listar os dados de um usu�rio atrav�s do e-mail e senha
SELECT 
	Usuario.IdUsuario AS [Id Do Usu�rio],
	Usuario.NomeUsuario AS [Nome do Usu�rio],
	Usuario.EmailUsuario AS [Email do Usu�rio],
	Permissao.TipoPermissao AS [N�vel de Permiss�o]
FROM Usuario
	INNER JOIN Permissao ON Usuario.IdPermissao = Permissao.IdPermissao
WHERE
	Usuario.EmailUsuario = 'murilo.souza@email.com' AND Usuario.SenhaUsuario = '54321';

-- listar todos os �lbuns ativos, mostrando o nome do artista e os estilos do �lbum 
SELECT 
	Album.IdAlbum AS [Album],
	Plataforma.NomePlataforma AS [Plataforma],
	Empresa.NomeEmpresa AS [Empresa],
	Artista.NomeArtista AS [Artista],
	Album.TituloAlbum AS [T�tulo do �lbum],
	Estilo.NomeEstilo AS [Estilo],
	Album.LancamentoAlbum AS [Lan�amento do �lbum],
	Album.DuracaoAlbum AS [Dura��o do �lbum],
	Album.LocalizacaoAlbum AS [Localiza��o do �lbum]
FROM Album
	INNER JOIN Artista ON Album.IdArtista = Artista.IdArtista
	INNER JOIN AlbumEstilo ON Album.IdAlbum = AlbumEstilo.IdAlbum
	INNER JOIN Estilo ON AlbumEstilo.IdEstilo = Estilo.IdEstilo
	INNER JOIN Plataforma ON ALbum.IdPlataforma = Plataforma.IdPlataforma
	INNER JOIN Empresa ON Plataforma.IdEmpresa = Empresa.IdEmpresa
WHERE 
	Album.AlbumAtivo = 'S';
