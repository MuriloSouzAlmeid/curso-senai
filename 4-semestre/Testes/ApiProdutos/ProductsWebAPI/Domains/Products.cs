using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsWebAPI.Domains
{
    [Table("Product")]
    public class Products
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(255)")]
        public string? Name { get; set; }

        [Column(TypeName = "MONEY")]
        public float? Price { get; set; }
    }
}
