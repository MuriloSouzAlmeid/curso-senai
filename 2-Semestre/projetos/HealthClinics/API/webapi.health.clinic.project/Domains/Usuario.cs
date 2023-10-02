using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.project.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Telefone), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email do usuário é obrigatório")]
        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatório")]
        [StringLength(60,MinimumLength = 5, ErrorMessage = "A senha tem de ter entre 5 a 60 caracteres")]
        public string? Senha { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "O telefone do usuário é obrigatório")]
        public string? Telefone { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de nascimento do usuário é obrigatório")]
        public DateTime? DataNascimento { get; set; }



        //Referência à tabela TiposUsuario - FK

        [Required(ErrorMessage = "O tipo do usuário é obrigatório")]
        public Guid? IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]  
        public TiposUsuario? TipoUsuario { get; set; }
    }
}
