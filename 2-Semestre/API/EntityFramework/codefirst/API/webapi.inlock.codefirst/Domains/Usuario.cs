using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        //possível resposta para a chave única
        [Index(IsUnique = true)]
        [Required(ErrorMessage = "O email do usuário é obrigatório")]
        public string Email { get; set; }

        //maior que o tamanho máximo da string para que não dê problemas no registro
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A senha de usuário é obrigatória")]

        //O primeiro número indica o máximo
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O campo senha aceita no mínimo 5 e no máximo 30 caracteres")]
        public string Senha { get; set; }

        //referência a tabela TiposUsuario
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario TipoUsuario { get; set; }
    }
}
