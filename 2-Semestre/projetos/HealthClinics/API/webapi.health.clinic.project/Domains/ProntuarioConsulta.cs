using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.project.Domains
{
    [Table(nameof(ProntuarioConsulta))]
    public class ProntuarioConsulta
    {
        [Key]
        public Guid IdProntuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do prontuário da consulta é obrigatória")]
        public string? Descricao { get; set; }



        //Referência à tabela Consulta
        [Required(ErrorMessage = "A consulta relacionada com o prontuário é obrigatória")]
        public Guid? IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
