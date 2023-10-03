using Microsoft.EntityFrameworkCore;
using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext ctx;
        public PresencaEventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                PresencaEvento presencaBuscada = this.BuscarPorId(id);

                presencaBuscada.Situacao = presencaEvento.Situacao;
                presencaBuscada.IdEvento = presencaEvento.IdEvento;
                presencaBuscada.IdUsuario = presencaEvento.IdUsuario;

                ctx.PresencaEvento.Update(presencaBuscada);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                PresencaEvento presencaBuscada = ctx.PresencaEvento.Include(pe => pe.Evento).Include(pe => pe.Usuario).FirstOrDefault(pe => pe.IdPresencaEvento == id)!;

                if(presencaBuscada != null)
                {
                    return presencaBuscada;
                }

                return null;
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
                PresencaEvento presencaBuscada = this.BuscarPorId(id);

                ctx.PresencaEvento.Remove(presencaBuscada);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscrever(PresencaEvento inscricao)
        {
            try
            {
                ctx.PresencaEvento.Add(inscricao);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencaEvento> Listar()
        {
            try
            {
                List<PresencaEvento> listaDePresencas = ctx.PresencaEvento.Include(pe => pe.Evento).Include(pe => pe.Usuario).ToList();

                return listaDePresencas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            try
            {
                List<PresencaEvento> listaMinhas = ctx.PresencaEvento.Include(pe => pe.Evento).Include(pe => pe.Usuario)
                    .Where(pe => pe.IdUsuario == id).ToList()!;

                if (listaMinhas != null)
                {
                    return listaMinhas;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
