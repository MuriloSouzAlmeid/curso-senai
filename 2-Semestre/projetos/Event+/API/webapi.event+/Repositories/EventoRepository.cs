using Microsoft.EntityFrameworkCore;
using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext ctx;
        public EventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, Evento eventoAtualizado)
        {
            try
            {
                Evento eventoBuscado = this.BuscarPorId(id);
                
                eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
                eventoBuscado.Descricao = eventoAtualizado.Descricao;
                eventoBuscado.DataEvento = eventoAtualizado.DataEvento;
                eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
                eventoBuscado.IdInstituicao = eventoAtualizado.IdInstituicao;
                eventoBuscado.TipoEvento = new TipoEvento() 
                {
                    IdTipoEvento = eventoAtualizado.IdTipoEvento,
                    Titulo = eventoAtualizado.TipoEvento.Titulo
                };
                eventoBuscado.Instituicao = new Instituicao()
                {
                    IdInstituicao = eventoAtualizado.IdInstituicao,
                    CNPJ = eventoAtualizado.Instituicao.CNPJ,
                    Endereco = eventoAtualizado.Instituicao.Endereco,
                    NomeFantasia = eventoAtualizado.Instituicao.NomeFantasia
                };

                ctx.Evento.Update(eventoBuscado);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento eventoBuscado = ctx.Evento.Include(e => e.TipoEvento).Include(e => e.Instituicao).FirstOrDefault(e => e.IdEvento == id)!;

                if(eventoBuscado != null)
                {
                    return eventoBuscado;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                ctx.Evento.Add(novoEvento);

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
                Evento eventoBuscado = this.BuscarPorId(id);

                ctx.Evento.Remove(eventoBuscado);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                List<Evento> listaDeEventos = ctx.Evento.Include(e => e.TipoEvento).Include(e => e.Instituicao).ToList();

                return listaDeEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
