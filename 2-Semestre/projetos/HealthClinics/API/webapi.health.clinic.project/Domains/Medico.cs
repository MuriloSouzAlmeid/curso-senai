using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.project.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(9)")]
        [Required(ErrorMessage = "O CRM do médico é obrigatório")]
        [StringLength(9,ErrorMessage = "O CRM deve ter 9 caracteres")]
        public string? CRM { get; set; }

        [Column(TypeName = "CHAR(2)")]
        [Required(ErrorMessage = "O estado do CRM do médico é obrigatório")]
        [StringLength(2, ErrorMessage = "Deve ser informado apenas a sigla do estado")]
        public string? EstadoCRM { get; set; }


        //Referência à tabela Usuario

        [Required(ErrorMessage = "O id do usuário é obrigaório")]
        public Guid? IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }


        //Referência à tabela Especialidade
        [Required(ErrorMessage = "A especialidade do médico é obrigatória")]
        public Guid? IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }
    }
}
