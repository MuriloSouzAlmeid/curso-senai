using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.project.Domains
{
    [Table(nameof(TiposUsuario))]
    [Index(nameof(Titulo), IsUnique = true)]
    public class TiposUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O título do tipo de usuário obrigatório")]
        public string? Titulo { get; set; }

        //Relação com a tabela Usuario
        public List<Usuario>? Usuarios { get; set; }
    }
}
