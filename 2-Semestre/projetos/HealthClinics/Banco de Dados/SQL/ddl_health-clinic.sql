CREATE DATABASE Health_Clinic_Tarde;

USE Health_Clinic_Tarde;

CREATE TABLE TipoDeUsuario(
	IdTipoDeUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoDeUsuario VARCHAR(13) NOT NULL UNIQUE
);

CREATE TABLE Especialidade(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	TituloEspecialidade VARCHAR (200) NOT NULL UNIQUE
);

CREATE TABLE Clinica(
	IdClinica INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR (200) NOT NULL,
	RazaoSocial VARCHAR (200) NOT NULL UNIQUE,
	CNPJ CHAR(14) NOT NULL UNIQUE,
	EnderecoClinica VARCHAR (200) NOT NULL,
	HorarioInicio TIME NOT NULL,
	HorarioEncerramento TIME NOT NULL
);

CREATE TABLE Comentario(
	IdComentario INT PRIMARY KEY IDENTITY,
	TituloComentario VARCHAR(100) NOT NULL,
	DescricaoComentario VARCHAR(500) NOT NULL,
	DataComentario DATE NOT NULL,
	ComentarioExbido BIT NOT NULL
);

CREATE TABLE Situacao(
	IdSituacao INT PRIMARY KEY IDENTITY,
	TituloSituacao VARCHAR(15) NOT NULL UNIQUE
);

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoDeUsuario INT FOREIGN KEY REFERENCES TipoDeUsuario(IdTipoDeUsuario) NOT NULL,
	NomeUsuario VARCHAR(50) NOT NULL,
	EmailUsuario VARCHAR(100) NOT NULL UNIQUE,
	SenhaUsuario VARCHAR(30) NOT NULL,
	TelefoneUsuario VARCHAR(20) NOT NULL UNIQUE,
	DataNascUsuario DATE NOT NULL
);

CREATE TABLE Paciente(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	RgPaciente CHAR(9) NOT NULL,
	CpfPaciente CHAR(11) NOT NULL UNIQUE,
	CepPaciente CHAR(8) NOT NULL,
	EnderecoPaciente VARCHAR(200) NOT NULL
);

CREATE TABLE Medico(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade) NOT NULL,
	CrmMedico CHAR(9) NOT NULL UNIQUE,
	Estado CHAR(2) NOT NULL
);

CREATE TABLE Consulta(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdSituacao INT FOREIGN KEY REFERENCES Situacao(IdSituacao) NOT NULL,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
	IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL,
	IdComentario INT FOREIGN KEY REFERENCES Comentario(IdComentario),
	Prontuario VARCHAR(2500) NOT NULL,
	DataConsulta DATE NOT NULL,
	HorarioConsulta TIME NOT NULL
);

/*USE master;
DROP DATABASE Health_Clinic_Tarde;*/