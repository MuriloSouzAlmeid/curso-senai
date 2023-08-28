USE Exercicio_1_4;

/* Filtragem por caracteres e textos usando o like '%o que contém%'
SELECT * FROM Usuario WHERE Usuario.NomeUsuario LIKE '%Murilo%';*/
SELECT * FROM AlbumEstilo;

INSERT INTO Permissao (TipoPermissao) VALUES ('Comun'),('Administrador');

INSERT INTO Usuario (IdPermissao,NomeUsuario) VALUES (1,'Gabriela Akiko'),(2,'Murilo Souza'),(1,'Leonardo Xavier');

INSERT INTO Empresa (NomeEmpresa,EmailEmpresa,TelefoneEmpresa) VALUES ('Optus','optus.music@email.com','11945294528');

INSERT INTO Plataforma (IdEmpresa,NomePlataforma) VALUES (1,'Optus - Plataforma de Musica');

INSERT INTO [Login] (IdUsuario, IdPlataforma, EmailLogin,SenhaLogin) 
VALUES (1,2,'gabriela.akiko@email.com','gabi123'),(3,2,'leonardo123xavier@email.com','naotemsenha'),(2,2,'murio.souza@gmail.com','12345');

INSERT INTO Artista (NomeArtista) VALUES ('Kanye West'),('Eminem');

INSERT INTO Estilo (NomeEstilo) VALUES ('Rap'),('Hip Hop'),('R&B');

INSERT INTO 
	Album (IdPlataforma,IdEmpresa,IdArtista,TituloAlbum,LancamentoAlbum,AlbumAtivo,DuracaoAlbum,LocalizacaoAlbum) 
VALUES 
	(2,1,1,'I Wonder','11-09-2007','S','00:54:29','EUA'),
	(2,1,2,'Without Me','26-05-2005','S','01:17:00','EUA'),
	(2,1,1,'Bound 2','18-06-2013','S','00:40:04','EUA');

INSERT INTO 
	AlbumEstilo (IdAlbum,IdEstilo) 
VALUES 
	(2,1),
	(3,2),
	(1,3);