using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.project.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situação da consulta é obrigatória")]
        public bool? Situacao { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "A data da consulta é obrigatória")]
        public DateTime? DataConsulta { get; set; }




        //Referência à tabela Clinica
        [Required(ErrorMessage = "A clínica da consulta é obrigatória")]
        public Guid? IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }



        //Referência à tabela Paciente 
        [Required(ErrorMessage = "O paciente da consulta é obrigatório")]
        public Guid? IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set;}



        //Referência à tabela Paciente 
        [Required(ErrorMessage = "O médico da consulta é obrigatório")]
        public Guid? IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }



        //Relação com a tabela ProntuarioConsulta 
        public ProntuarioConsulta? Prontuario { get; set; }


        //Relação com a tabela ComentariosConsulta
        public List<ComentarioConsulta>? Comentarios { get; set; }
    }
}
