using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;
using webapi.health.clinic.project.Repositories;
using webapi.health.clinic.project.ViewModels;

namespace webapi.health.clinic.project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController()
        {
            this._usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Rota para realizar o Login de um usuário
        /// </summary>
        /// <param name="informacoesLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel informacoesLogin)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(informacoesLogin.Email, informacoesLogin.Senha);

                if(usuarioBuscado == null)
                {
                    return NotFound("Email ou senha digitados incorretamente, tente novamente.");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario.Titulo.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projeto-health-clinic-webapi-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                        issuer: "webapi.health.clinic.project",
                        audience: "webapi.health.clinic.project",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok
                    (
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        }
                    );
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
