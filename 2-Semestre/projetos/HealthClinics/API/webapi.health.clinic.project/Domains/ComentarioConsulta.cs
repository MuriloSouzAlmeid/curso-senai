using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.project.Domains
{
    [Table(nameof(ComentarioConsulta))]
    public class ComentarioConsulta
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do comentário é obrigatória")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A configuração de exibição do comentário é obrigatória")]
        public bool? Exibicao { get; set; }


        //Referência à tabela Consulta
        [Required(ErrorMessage = "A consulta relacionada com o comentário é obrigatória")]
        public Guid? IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
