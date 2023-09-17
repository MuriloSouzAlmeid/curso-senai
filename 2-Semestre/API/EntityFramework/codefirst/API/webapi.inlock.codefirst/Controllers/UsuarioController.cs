using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Repositories;

namespace webapi.inlock.codefirst.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Rota para cadastrar um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto contendo as informações do usuário a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.CadastrarUsuario(usuario);

                return Ok("Usuário cadastrado com sucesso");
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
