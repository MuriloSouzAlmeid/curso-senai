using Microsoft.EntityFrameworkCore;
using webapi.health.clinic.project.Contexts;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;

namespace webapi.health.clinic.project.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext ctx;
        public ConsultaRepository()
        {
            this.ctx = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Consulta consultaAtualizada)
        {
            try
            {
                Consulta consultaBuscada = this.BuscarPorId(id);

                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
                consultaBuscada.Situacao = consultaAtualizada.Situacao;
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;

                ctx.Consulta.Update(consultaBuscada);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Consulta> BuscarMinhas(Guid id)
        {
            try
            {
                return ctx.Consulta.Include(c => c.Prontuario).Include(c => c.Paciente).Include(c => c.Medico).Include(c => c.Comentarios).Where(c => (c.Paciente.IdUsuario == id) || (c.Medico.IdUsuario == id)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                Consulta consultaBuscada = ctx.Consulta.Include(c => c.Clinica).Include(c => c.Paciente).Include(c => c.Medico)
                    .FirstOrDefault(c => c.IdConsulta == id)!;

                if(consultaBuscada == null)
                {
                    return null;
                }

                return consultaBuscada;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            try
            {
                ctx.Consulta.Add(novaConsulta);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Consulta consultaBuscada = this.BuscarPorId(id);

                ctx.Consulta.Remove(consultaBuscada);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Consulta> ListarTodas()
        {
            try
            {
                return ctx.Consulta.Include(c => c.Prontuario).Include(c => c.Paciente).Include(c => c.Medico).Include(c => c.Comentarios).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}