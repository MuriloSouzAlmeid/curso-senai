using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.Domains
{
    //jeito mais correto de colocar o nome de algo como parâmetro em uma data annotation é utlizando o nameof()
    //usamos o nameof() para fazer referência à uma classe ou a um atributo
    [Table(nameof(TipoEvento))]
    public class TipoEvento
    {
        [Key]
        public Guid IdTipoEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Título do tipo de evento é obrigatório")]
        public string? Titulo { get; set; }


    }
}
