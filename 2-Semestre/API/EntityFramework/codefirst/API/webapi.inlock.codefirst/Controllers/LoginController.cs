using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Repositories;
using webapi.inlock.codefirst.ViewModels;

namespace webapi.inlock.codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        //quando coloca readonly não precisa do {get;set;}
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel informacoesLogin)
        {
            try
            {
                Usuario usuario = _usuarioRepository.Login(informacoesLogin.Email, informacoesLogin.Senha);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado, verifique se o email ou a senha foram digitados corretamente e tente novamente");   
                }

                //1 - cria as claims do token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString())
                };

                //2 - dafine a chave de decodificação
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-games-chave-autenticacao-webapi-codefirst"));

                //3 - define as credenciais do token (primeiro o tipo - chave; e depois o tamanho - 256 bytes)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 - define as configurações do token
                var token = new JwtSecurityToken(
                    //de onde vem
                    issuer: "webapi.inlock.codefirst",
                    //para onde vai
                    audience: "webapi.inlock.codefirst",
                    //quais as informações dentro dele
                    claims: claims,
                    //qual o seu tempo de expiração
                    expires: DateTime.Now.AddMinutes(20),
                    //quais são as suas credenciais
                    signingCredentials: creds
                );

                //5 - construir e retornar o token
                return Ok(
                    //instancia uma nova resposta
                    new
                    {
                        //
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                 );

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
