--USE master;
USE Health_Clinic_Tarde;

INSERT INTO TipoDeUsuario 
	(TituloTipoDeUsuario)
VALUES 
	('Administrador'),('Paciente'),('Médico');
SELECT * FROM TipoDeUsuario;

INSERT INTO Especialidade 
	(TituloEspecialidade)
VALUES 
	('Nutricionista'),('Cardiologista');
SELECT * FROM Especialidade;

INSERT INTO Clinica 
	(NomeFantasia,RazaoSocial,CNPJ,EnderecoClinica,HorarioInicio,HorarioEncerramento)
VALUES 
	('Health Clinic','Health Clinic - Clínica de saúde LTDA','65793057738022','Rua dos Bobos, n0 - SP','07:00:00','22:30:00');
SELECT * FROM Clinica;

INSERT INTO Comentario 
	(TituloComentario,DescricaoComentario,DataComentario,ComentarioExbido)
VALUES 
	('Atendimento muito bom!','Médico atencioso e educado, a consulta foi muito boa.','15-08-2023',1),
	('Que LIXO!','Atendimento ruim e o médico examina igual a bunda dele, foda-se','22-08-2023',0);
SELECT * FROM Comentario;

INSERT INTO Situacao 
	(TituloSituacao)
VALUES 
	('Agendada'),('Cancelada'),('Em andamento'),('Finalizada');
SELECT * FROM Situacao;

INSERT INTO Usuario 
	(IdTipoDeUsuario,NomeUsuario,EmailUsuario,SenhaUsuario,TelefoneUsuario,DataNascUsuario)
VALUES
	(1,'Murilo Souza Almeida','murilo.souza@email.com','Murilo12$','11995135732','1999-11-12'),
	(2,'Leonardo Christian Oliveira Xavier','leonardo.xavier@email.com','Leo123','11974829477','1986-05-23'),
	(3,'João Pedro Lipporoni','joao.lipporoni@email.com','Joao456','11955368294','1992-07-17'),
	(3,'Arthur lins Belarmino','arthur.lins@email.com','Arthur123','11965489366','1982-12-05'),
	(2,'Laura Tabarelli Capossi','laura.tabarelli@email.com','Laura123','11942187901','1973-10-14');
SELECT * FROM Usuario;

INSERT INTO Paciente 
	(Idusuario,RgPaciente,CpfPaciente,CepPaciente,EnderecoPaciente)
VALUES
	(2,'648834751','57839557303','04875392','Rua das Luas, n22 - Santo André'),
	(5,'473995612','46722749501','09452284','Parque dos Bosques, n6 - Mauá');
SELECT * FROM Paciente;

INSERT INTO Medico 
	(IdUsuario,IdEspecialidade,CrmMedico,Estado) 
VALUES
	(3,1,'578488321','SP'),
	(4,2,'885392104','MG');
SELECT * FROM Medico;

INSERT INTO Consulta
	(IdSituacao,IdClinica,IdPaciente,IdMedico,IdComentario,Prontuario,DataConsulta,HorarioConsulta)
VALUES
	(4,1,1,2,1,'Culsulta do paciente tal, com o médico tal, sobre tal problema, ao tal horario, feito tais exames, exibidos tais resultados, medicados tais medicamentos, voltar tal dia','12-08-2023','14:00:00'),
	(3,1,2,1,2,'Culsulta não sei o que que não seio que lá','05-03-2023','08:30:00');
SELECT * FROM Consulta;