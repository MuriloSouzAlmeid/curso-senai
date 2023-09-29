using Microsoft.EntityFrameworkCore;
using webapi.health.clinic.project.Contexts;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;
using webapi.health.clinic.project.Utils;

namespace webapi.health.clinic.project.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext ctx;
        public UsuarioRepository()
        {
            this.ctx = new HealthClinicContext();
        }
        public void Atualizar(Guid id, Usuario usuarioAtualizado)
        {
            try
            {
                Usuario usuarioBuscado = this.BuscarPorId(id);

                usuarioBuscado.Nome = usuarioAtualizado.Nome;
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Telefone = usuarioAtualizado.Telefone;
                usuarioBuscado.DataNascimento = usuarioAtualizado.DataNascimento;
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

                ctx.Usuario.Update(usuarioBuscado);

                ctx.SaveChanges();
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
                Usuario usuarioBUscado = ctx.Usuario.Include(u => u.TipoUsuario).FirstOrDefault(u => u.IdTipoUsuario == id)!;

                if(usuarioBUscado == null)
                {
                    return null;
                }

                return usuarioBUscado;
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
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);

                ctx.Usuario.Add(novoUsuario);

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
                Usuario usuarioBUscado = this.BuscarPorId(id);

                ctx.Usuario.Remove(usuarioBUscado);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario Login(string email, string senha)
        {
            try
            {
                Usuario usuarioBusacdo = ctx.Usuario.Include(u => u.TipoUsuario).FirstOrDefault(u => u.Email == email)!;

                if(usuarioBusacdo != null)
                {
                    if (Criptografia.ComrararHash(senha, usuarioBusacdo.Senha!))
                    {
                        return usuarioBusacdo;
                    }
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
