using Microsoft.EntityFrameworkCore;
using webapi.health.clinic.project.Domains;

namespace webapi.health.clinic.project.Contexts
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<ComentarioConsulta> ComentarioConsulta { get; set; }
        public DbSet<ProntuarioConsulta> ProntuarioConsulta { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE16-S15; Database=Health_Clinic_Tarde; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
