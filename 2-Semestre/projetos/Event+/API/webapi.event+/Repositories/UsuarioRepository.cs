using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Utils;

namespace webapi.event_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext ctx;
        public UsuarioRepository()
        {
            ctx = new EventContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario.Include(u => u.TipoUsuario).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario
                    //Com o select podemos especificar quais os dados serão buscados na tabela (Tipo o SELECT do Sql)
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,

                        //instancia um objeto do tipo TipoUsuario
                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.TipoUsuario.IdTipoUsuario,
                            Titulo = u.TipoUsuario.Titulo
                        }

                        //expressão lâmbda serve para executar uma linha de comando dentro de um parâmetro de uma função
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                //gera a hash com a senha
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);

                ctx.Usuario.Add(novoUsuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
