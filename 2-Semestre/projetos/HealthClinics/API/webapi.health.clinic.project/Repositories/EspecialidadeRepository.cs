using Microsoft.EntityFrameworkCore;
using webapi.health.clinic.project.Contexts;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;

namespace webapi.health.clinic.project.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext ctx;
        public EspecialidadeRepository()
        {
            this.ctx = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Especialidade especialidadeAtualizada)
        {
            try
            {
                Especialidade especialidadeBuscada = this.BuscarPorId(id);

                especialidadeBuscada.Titulo = especialidadeAtualizada.Titulo;

                ctx.Especialidade.Update(especialidadeBuscada);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Especialidade BuscarPorId(Guid id)
        {
            try
            {
                Especialidade especialidadeBuscada = ctx.Especialidade.FirstOrDefault(e => e.IdEspecialidade == id)!;

                if(especialidadeBuscada== null)
                {
                    return null;
                }

                return especialidadeBuscada;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            try
            {
                ctx.Especialidade.Add(novaEspecialidade);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Especialidade> Listar()
        {
            try
            {
                List<Especialidade> lista = ctx.Especialidade.ToList();

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
