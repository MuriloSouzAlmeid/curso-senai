using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        [Key]
        public Guid IdTipoEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "O nome da permissao é obrigatório")]
        public string Permissao { get; set; }

        //referência ao usuário
        public List<Usuario> Usuarios { get; set; }
    }
}
