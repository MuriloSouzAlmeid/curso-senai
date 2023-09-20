using Microsoft.EntityFrameworkCore;
using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext ctx;
        public TipoUsuarioRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = this.BuscarPorId(id);

                tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;

                ctx.TipoUsuario.Update(tipoUsuarioBuscado);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Include(t => t.Usuarios).FirstOrDefault(t => t.IdTipoUsuario == id)!;

                if (tipoUsuarioBuscado != null)
                {
                    return tipoUsuarioBuscado;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.TipoUsuario.Add(tipoUsuario);

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
                TipoUsuario tipoUsuarioBuscado = this.BuscarPorId(id);

                ctx.TipoUsuario.Remove(tipoUsuarioBuscado);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                List<TipoUsuario> listaDeTiposDeUsuarios = ctx.TipoUsuario.Include(t => t.Usuarios).ToList();

                return listaDeTiposDeUsuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
