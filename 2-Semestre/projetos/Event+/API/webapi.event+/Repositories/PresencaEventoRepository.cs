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
                PresencaEvento presencaBuscada = ctx.PresencaEvento
                    .Select(pe => new PresencaEvento()
                    {
                        IdPresencaEvento = pe.IdPresencaEvento,
                        Situacao = pe.Situacao,
                        IdUsuario = pe.IdUsuario,
                        IdEvento = pe.IdEvento,

                        Usuario = new Usuario()
                        {
                            IdUsuario = pe.IdUsuario
                        },

                        Evento = new Evento()
                        {
                            IdEvento = pe.IdEvento
                        }

                    }).FirstOrDefault(pe => pe.IdPresencaEvento == id)!;

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
                List<PresencaEvento> listaDePresencas = ctx.PresencaEvento
                    .Select(pe => new PresencaEvento()
                    {
                        IdPresencaEvento = pe.IdPresencaEvento,
                        Situacao = pe.Situacao,
                        IdUsuario = pe.IdUsuario,
                        IdEvento = pe.IdEvento,

                        Usuario = new Usuario()
                        {
                            IdUsuario = pe.IdUsuario
                        },

                        Evento = new Evento()
                        {
                            IdEvento= pe.IdEvento
                        }

                    }).ToList();

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
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
