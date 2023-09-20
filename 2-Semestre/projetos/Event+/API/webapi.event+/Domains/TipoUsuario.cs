using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.Domains
{
    [Table(nameof(TipoUsuario))]
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório")]
        public string? Titulo { get; set; }

        //lista de usuários que possuem determinado tipo
        public List<Usuario>? Usuarios { get; set; }
    }
}
