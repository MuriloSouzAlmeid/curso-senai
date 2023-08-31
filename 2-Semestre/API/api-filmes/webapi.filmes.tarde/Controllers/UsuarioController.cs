using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository= new UsuarioRepository();
        }

        /// <summary>
        /// Método para logar um usuário
        /// </summary>
        /// <param name="usuario">Objeto com as informações de login do usuário</param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.LoginUsuario(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado");
                }
                else
                {
                    return StatusCode(200, $"Usuário logado, bem vindo {usuarioBuscado.Nome}. Nível de permissão: {usuarioBuscado.Permissao}");
                }
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /*[HttpGet]
        public IActionResult Get(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.LoginUsuario(usuario.Email,usuario.Senha);

                if(usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado, email ou senha digitado incorretamente. Tente novamente");
                }
                else
                {
                    return StatusCode(200, $"Usuário logado, bem vindo ao sistema {usuarioBuscado.Nome}, permissão de usuário: {usuarioBuscado.Permissao}");
                }


            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }*/
    }
}
