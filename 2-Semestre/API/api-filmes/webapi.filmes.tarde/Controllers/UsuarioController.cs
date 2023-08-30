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
        /// <param name="email">email do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns></returns>
        [HttpGet("{email}&{senha}")]
        public IActionResult Get(string email, string senha)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.LoginUsuario(email, senha);

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
        }
    }
}
