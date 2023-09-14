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

        [HttpPost]
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

        //falta implementar o endpoint
        [HttpGet]
        public IActionResult GetByEmailAndPassword(string email, string senha)
        {
            try
            {
                _usuarioRepository.Login(email, senha);

                
            }catch(Exception erro)
            {
                throw;
            }
        }
    }
}
