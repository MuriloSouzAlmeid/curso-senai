//Anotações no arquivo Estudio.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data De Lançamento é obrigatória")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "MONEY")]
        [Required(ErrorMessage = "Preço é obrigatório")]
        public decimal Preco { get; set; }



        //Ligação com a tabela estúdio (chave estrangeira)
        public Guid IdEstudio { get; set; }

        //define a relação com a tabela estúdio pelo objeto da tabela e não pelo id da mesma
        //a datanotation ForeignKey define que no objeto está no objeto do tipo Estudio
        //dentro do parênteses colocamos qual será o campo que se ligará (REFERENCES no Sql)
        [ForeignKey("IdEstudio")]
        public Estudio Estudio { get; set; }
    }
}
