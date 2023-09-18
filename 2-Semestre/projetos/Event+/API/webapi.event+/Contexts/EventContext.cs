using Microsoft.EntityFrameworkCore;
using webapi.event_.Domains;

namespace webapi.event_.Contexts
{
    //Devemos primeiramente herdar da classe DbContext (representa a conexão com o banco de dados)
    //Tem de conhecer todas as tabelas do banco de dados através do DbSet
    public class EventContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE16-S15; Database=Event+_Tarde; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
