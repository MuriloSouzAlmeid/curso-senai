using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.project.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(RG), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(9)")]
        [Required(ErrorMessage = "O RG do paciente é obrigatório")]
        [StringLength(9,ErrorMessage = "O RG do paciente deve ter 9 caracteres")]
        public string? RG { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "O CPF do paciente do paciente é obrigatório")]
        [StringLength(11, ErrorMessage = "O CPF do paciente deve ter 11 caracteres")]
        public string? CPF { get; set; }

        [Column(TypeName = "CHAR(8)")]
        [Required(ErrorMessage = "O CEP do paciente do paciente é obrigatório")]
        [StringLength(8, ErrorMessage = "O CEP do paciente deve ter 8 caracteres")]
        public string? CEP { get; set; }

        [Column(TypeName = "VARCHAR(300)")]
        [Required(ErrorMessage = "O endereço do usuário do paciente é obrigatório")]
        public string? Endereco { get; set; }


        //Referência à tabela Usuario
        [Required(ErrorMessage = "O id do usuário do paciente é obrigatório")]
        public Guid? IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
