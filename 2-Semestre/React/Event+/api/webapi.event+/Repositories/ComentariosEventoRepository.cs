using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class ComentariosEventoRepository : IComentariosEventoRepository
    {
        private readonly Event_Context _context;

        public ComentariosEventoRepository()
        {
            _context = new Event_Context();
        }

        public ComentariosEvento BuscarPorId(Guid id)
        {
            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.IdComentarioEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ComentariosEvento BuscarPorIdUsuarioEvento(Guid idUsuario, Guid idEvento)
        {
            try
            {
                ComentariosEvento comentarioBuscado = _context.ComentariosEvento.FirstOrDefault(
                    c => c.IdEvento == idEvento && c.IdUsuario == idUsuario)!;

                if(comentarioBuscado == null)
                {
                    return null;
                }

                return comentarioBuscado;

            }catch(Exception erro)
            {
                throw;
            }
        }

        public void Cadastrar(ComentariosEvento comentarioEvento)
        {
            try
            {
                _context.ComentariosEvento.Add(comentarioEvento);
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
                ComentariosEvento comentarioEventoBuscado = _context.ComentariosEvento.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentariosEvento.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentariosEvento> Listar()
        {

            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentariosEvento> ListarPorIdEvento(Guid idEvento)
        {
            List<ComentariosEvento> comentariosBuscados = _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.IdEvento == idEvento).ToList();

            if(comentariosBuscados.Count < 1)
            {
                return null;
            }

            return comentariosBuscados;
        }

        public List<ComentariosEvento> ListarPorUsuarioEvento(Guid idUsuario, Guid idEvento)
        {
            try
            {
                ComentariosEvento comentarioBuscado = BuscarPorIdUsuarioEvento(idUsuario, idEvento);

                if(comentarioBuscado == null)
                {
                    return null;
                }

                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.IdUsuario == idUsuario && c.IdEvento == idEvento).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentariosEvento> ListarSometeExibe(Guid idEvento)
        {
            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.Exibe == true && c.IdEvento == idEvento).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}