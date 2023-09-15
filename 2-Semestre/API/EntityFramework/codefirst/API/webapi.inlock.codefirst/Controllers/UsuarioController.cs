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
        [Authorize(Roles = "8868F802-DC18-4C02-89DD-F3151B7FDEE8")]
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
