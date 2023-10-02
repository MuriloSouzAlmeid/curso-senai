using webapi.health.clinic.project.Contexts;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;

namespace webapi.health.clinic.project.Repositories
{
    public class ComentarioRepository : IComentarioConsultaRepository
    {
        private readonly HealthClinicContext ctx;
        public ComentarioRepository()
        {
            this.ctx = new HealthClinicContext();
        }

        public ComentarioConsulta BuscarPorId(Guid id)
        {
            try
            {
                ComentarioConsulta comentarioBuscado = ctx.ComentarioConsulta.FirstOrDefault(c => c.IdComentario == id)!;

                if(comentarioBuscado == null)
                {
                    return null;
                }

                return comentarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentarioConsulta novoComentario)
        {
            try
            {
                ctx.ComentarioConsulta.Add(novoComentario);
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
                ComentarioConsulta comentarioBuscado = this.BuscarPorId(id);

                ctx.ComentarioConsulta.Remove(comentarioBuscado);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
