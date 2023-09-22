using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext ctx;
        public TipoEventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento tipoBuscado = this.BuscarPorId(id);

                tipoBuscado.Titulo = tipoEvento.Titulo;             

                ctx.TipoEvento.Update(tipoBuscado);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                TipoEvento tipoBuscado = ctx.TipoEvento.FirstOrDefault(t => t.IdTipoEvento == id)!;

                if(tipoBuscado != null)
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

        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                ctx.TipoEvento.Add(tipoEvento);

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
                TipoEvento tipoBuscado = this.BuscarPorId(id);

                ctx.TipoEvento.Remove(tipoBuscado);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoEvento> Listar()
        {
            try
            {
                List<TipoEvento> listaDeEventos = ctx.TipoEvento.ToList();

                return listaDeEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
