USE Health_Clinic_Tarde;

SELECT 
	Consulta.IdConsulta AS [Id Da Consulta],
	Consulta.DataConsulta AS [Data da Consulta],
	Consulta.HorarioConsulta AS [Hor�rio da Consulta],
	Clinica.NomeFantasia AS [Nome da Cl�nica],
	UP.NomeUsuario AS [Nome Do Paciente],
	UM.NomeUsuario AS [Nome Do M�dico],
	Especialidade.TituloEspecialidade AS [Especialidade do M�dico],
	Medico.CrmMedico AS [CRM do M�dico],
	Consulta.Prontuario AS [Prontu�rio],
	Comentario.DescricaoComentario AS [Feedback da Consulta]
FROM
	Consulta
	INNER JOIN Paciente ON Consulta.IdPaciente = Paciente.IdPaciente
	INNER JOIN Usuario AS UP ON UP.IdUsuario = Paciente.IdUsuario
	INNER JOIN Medico ON Consulta.IdMedico = Medico.IdMedico
	INNER JOIN Usuario AS UM ON UM.IdUsuario = Medico.IdUsuario
	INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
	INNER JOIN Clinica ON Consulta.IdClinica = Clinica.IdClinica
	INNER JOIN Comentario ON Consulta.IdComentario = Comentario.IdComentario