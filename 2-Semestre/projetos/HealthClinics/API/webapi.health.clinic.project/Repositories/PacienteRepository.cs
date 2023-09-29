using webapi.health.clinic.project.Contexts;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;

namespace webapi.health.clinic.project.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext ctx;
        public PacienteRepository()
        {
            this.ctx = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Paciente PacienteAtualizado)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Paciente> Listar()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
