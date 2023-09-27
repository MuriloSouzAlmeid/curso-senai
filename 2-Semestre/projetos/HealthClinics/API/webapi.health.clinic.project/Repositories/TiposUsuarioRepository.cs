using webapi.health.clinic.project.Contexts;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;

namespace webapi.health.clinic.project.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly HealthClinicContext ctx;
        public TiposUsuarioRepository()
        {
            ctx = new HealthClinicContext();
        }
        public TiposUsuario BuscarPorId(Guid id)
        {
            try
            {
                TiposUsuario tipoBuscado = ctx.TiposUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id)!;

                if (tipoBuscado != null)
                {
                    return tipoBuscado;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TiposUsuario novoTipo)
        {
            try
            {
                ctx.TiposUsuarios.Add(novoTipo);

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
                TiposUsuario tipoBuscado = BuscarPorId(id);

                ctx.TiposUsuarios.Remove(tipoBuscado);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
