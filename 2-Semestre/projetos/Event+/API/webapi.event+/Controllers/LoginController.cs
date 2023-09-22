using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;
using webapi.event_.ViewModels;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Rota para logar determinado usuário e obter suas definições de autenticação e autorização
        /// </summary>
        /// <param name="informacoesLogin">Informações de Email e Senha para a verificação de Login</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel informacoesLogin)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorEmailESenha(informacoesLogin.Email, informacoesLogin.Senha);

                if(usuario != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                        new Claim(ClaimTypes.Role, usuario.TipoUsuario.Titulo.ToString())
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projeto-webapi-evnt+-chave-autenticacao"));

                    //passaa minha própria chave
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken
                    (
                        issuer: "webapi.event+",
                        audience: "webapi.event+",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: creds
                    );

                    return Ok
                        (
                            new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(token)
                            }
                        );
                }
                else
                {
                    return NotFound("Usuário não encontrado, informe o seu email e senha novamente");
                }

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
