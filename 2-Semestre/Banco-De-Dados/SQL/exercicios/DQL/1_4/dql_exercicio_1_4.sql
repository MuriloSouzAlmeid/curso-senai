USE Exercicio_1_4;

-- listar todos os usuários administradores, sem exibir suas senhas
SELECT 
	Usuario.IdUsuario AS [Id do Usuário],
	Usuario.NomeUsuario AS [Nome do Usuário],
	Usuario.EmailUsuario AS [Email do Usuário],
	Permissao.TipoPermissao AS [Nível de Permissao]
FROM Usuario
	INNER JOIN Permissao ON Usuario.IdPermissao = Permissao.IdPermissao;

-- listar todos os álbuns lançados após o um determinado ano de lançamento
SELECT 
	Album.IdAlbum AS [Album],
	Plataforma.NomePlataforma AS [Plataforma],
	Empresa.NomeEmpresa AS [Empresa],
	Artista.NomeArtista AS [Artista],
	Album.TituloAlbum AS [Título do Álbum],
	Estilo.NomeEstilo AS [Estilo],
	Album.LancamentoAlbum AS [Lançamento do Álbum],
	Album.DuracaoAlbum AS [Duração do Álbum],
	Album.LocalizacaoAlbum AS [Localização do Álbum],
	CASE WHEN ALbum.AlbumAtivo = 'S' THEN	'Sim' ELSE 'Não' END AS [Álbum Ativo]
FROM Album
	INNER JOIN Artista ON Album.IdArtista = Artista.IdArtista
	INNER JOIN AlbumEstilo ON Album.IdAlbum = AlbumEstilo.IdAlbum
	INNER JOIN Estilo ON AlbumEstilo.IdEstilo = Estilo.IdEstilo
	INNER JOIN Plataforma ON ALbum.IdPlataforma = Plataforma.IdPlataforma
	INNER JOIN Empresa ON Plataforma.IdEmpresa = Empresa.IdEmpresa
WHERE 
	Year(Album.LancamentoAlbum) >= 2007; 

-- listar os dados de um usuário através do e-mail e senha
SELECT 
	Usuario.IdUsuario AS [Id Do Usuário],
	Usuario.NomeUsuario AS [Nome do Usuário],
	Usuario.EmailUsuario AS [Email do Usuário],
	Permissao.TipoPermissao AS [Nível de Permissão]
FROM Usuario
	INNER JOIN Permissao ON Usuario.IdPermissao = Permissao.IdPermissao
WHERE
	Usuario.EmailUsuario = 'murilo.souza@email.com' AND Usuario.SenhaUsuario = '54321';

-- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 
SELECT 
	Album.IdAlbum AS [Album],
	Plataforma.NomePlataforma AS [Plataforma],
	Empresa.NomeEmpresa AS [Empresa],
	Artista.NomeArtista AS [Artista],
	Album.TituloAlbum AS [Título do Álbum],
	Estilo.NomeEstilo AS [Estilo],
	Album.LancamentoAlbum AS [Lançamento do Álbum],
	Album.DuracaoAlbum AS [Duração do Álbum],
	Album.LocalizacaoAlbum AS [Localização do Álbum]
FROM Album
	INNER JOIN Artista ON Album.IdArtista = Artista.IdArtista
	INNER JOIN AlbumEstilo ON Album.IdAlbum = AlbumEstilo.IdAlbum
	INNER JOIN Estilo ON AlbumEstilo.IdEstilo = Estilo.IdEstilo
	INNER JOIN Plataforma ON ALbum.IdPlataforma = Plataforma.IdPlataforma
	INNER JOIN Empresa ON Plataforma.IdEmpresa = Empresa.IdEmpresa
WHERE 
	Album.AlbumAtivo = 'S';
