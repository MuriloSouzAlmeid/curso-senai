using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("Usuario")]
    //indica que o atributo dentro do nameof vai ter um índice próprio especificado após a vírgula e esse índice é IsUnique = true pra adicionar uma chave Unique
    [Index(nameof(Email),IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email do usuário é obrigatório")]
        public string Email { get; set; }

        //maior que o tamanho máximo da string para que não dê problemas no registro
        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "A senha de usuário é obrigatória")]
        //O primeiro número indica o máximo que tem que ser o máximo de caracteres o tamanho da hash (60 caracteres) 
        [StringLength(60, MinimumLength = 5, ErrorMessage = "O campo senha aceita no mínimo 5 e no máximo 60 caracteres")]
        public string Senha { get; set; }

        //referência a tabela TiposUsuario
        [Required(ErrorMessage = "O Id do Tipo de usuário é origatório")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario? TipoUsuario { get; set; }
    }
}
