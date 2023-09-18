using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.Domains
{
    [Table(nameof(Usuario))]
    //adiciona a chave única ao campo de email
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email de usuário é obrigatório")]
        public string? Email { get; set; }

        //usamos CHAR pois já sabemos que uma hash tem tamanho padrão de 60 caracteres
        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "A senha de usuário é obrigatória")]
        [StringLength(60,MinimumLength = 5, ErrorMessage = "A senha deve ter entre 5 e 60 caracteres de comprimento")]
        public string? Senha { get; set; }



        //referência à tabela de TipoUsuario = FK

        [Required(ErrorMessage = "O tipo do usuário é obrigatório.")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
