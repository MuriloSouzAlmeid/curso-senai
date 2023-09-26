using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.project.Domains
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O título da especialidade é obrigatório")]
        public string? Titulo { get; set; }

        //Relação com a tabela Medico
        public List<Medico>? ListaDeMedicos { get; set; }
    }
}
