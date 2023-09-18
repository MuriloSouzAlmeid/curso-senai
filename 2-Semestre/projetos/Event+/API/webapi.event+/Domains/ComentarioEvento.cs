using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace webapi.event_.Domains
{
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do comentário é obrigatória")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A exibição do comentário é obrigatória")]
        public bool Exibe { get; set; }



        //Referência à tabela Usuario
        [Required(ErrorMessage = "O id do usuário é obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //Referência à tabela Evento
        [Required(ErrorMessage = "O id do evento é obrigatório")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
