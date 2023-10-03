using Microsoft.EntityFrameworkCore;
using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext ctx;
        public ComentarioEventoRepository()
        {
            ctx = new EventContext();
        }
        public ComentarioEvento BuscarPorId(Guid id)
        {
            try
            {
                ComentarioEvento comentarioBuscado = ctx.ComentarioEvento
                    .Include(c => c.Usuario)
                    .Include(c => c.Evento)
                    .FirstOrDefault(c => c.IdComentarioEvento == id)!;

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

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                ctx.ComentarioEvento.Add(comentarioEvento);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            ComentarioEvento comentarioBuscado = this.BuscarPorId(id);

            ctx.ComentarioEvento.Remove(comentarioBuscado);

            ctx.SaveChanges();
        }

        public List<ComentarioEvento> Listar()
        {
            try
            {
                List<ComentarioEvento> listaDeComentarios = ctx.ComentarioEvento.Include(c => c.Usuario).Include(c => c.Evento).ToList();

                return listaDeComentarios;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
