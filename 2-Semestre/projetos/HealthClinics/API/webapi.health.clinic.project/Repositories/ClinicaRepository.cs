using webapi.health.clinic.project.Contexts;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;

namespace webapi.health.clinic.project.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext ctx;
        public ClinicaRepository()
        {
            ctx = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Clinica clinicaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Clinica BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Clinica novaClinica)
        {
            try
            {
                ctx.Clinica.Add(novaClinica);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Clinica> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
