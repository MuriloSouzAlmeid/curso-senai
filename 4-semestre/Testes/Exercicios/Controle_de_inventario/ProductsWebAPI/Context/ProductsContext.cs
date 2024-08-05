using Microsoft.EntityFrameworkCore;
using ProductsWebAPI.Domains;

namespace ProductsWebAPI.Context
{
    public class ProductsContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE07-SALA19; Initial Catalog=ProductsDatabase; User Id=sa; Pwd=Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
