using Microsoft.EntityFrameworkCore;
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
                Paciente pacienteBuscado = this.BuscarPorId(id);

                pacienteBuscado.CPF = PacienteAtualizado.CPF;
                pacienteBuscado.CEP = PacienteAtualizado.CEP;
                pacienteBuscado.Endereco = PacienteAtualizado.Endereco;
                pacienteBuscado.RG = PacienteAtualizado.RG;

                ctx.Paciente.Update(pacienteBuscado);

                ctx.SaveChanges();
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
                Paciente pacienteBuscado = ctx.Paciente.Include(p => p.Usuario).FirstOrDefault(p => p.IdPaciente == id)!;

                if(pacienteBuscado !=  null)
                {
                    return pacienteBuscado;
                }

                return null;
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
                ctx.Paciente.Add(novoPaciente);
                ctx.SaveChanges();
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
                return ctx.Paciente.Include(p => p.Usuario).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
