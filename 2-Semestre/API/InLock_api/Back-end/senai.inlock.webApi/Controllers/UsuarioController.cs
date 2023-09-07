using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
{
    //define o nome da rota
    [Route("api/[controller]")]
    //define que será um controller
    [ApiController]
    //define que a resposta passada pelo corpo será em formato json
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        //instancia um objeto que conterá os métodos necessários
        private IUsuarioRepository _usuarioRepository { get; set; }

        //atribui os métodos para o objeto
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Rota responsável por logar um usuário e definir suas definições de autenticação e autorização
        /// </summary>
        /// <param name="informacoesLogin">Objeto contendo o email e a senha para o login</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(UsuarioDomain informacoesLogin)
        {
            try
            {
                //objeto que determinará se o usuário está cadastrado ou não
                UsuarioDomain usuario = _usuarioRepository.Login(informacoesLogin.Email, informacoesLogin.Senha);

                if(usuario != null)
                {
                    //criação do token

                    //1 - Definir as Claims/Informações que serão passadas para o token (Payloads)
                    var claims = new[]
                    {
                        //instancia a claim de Id - Jti
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),

                        //instancia a claim de email
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),

                        //instancia a claim de permissão para autorização posteriormente
                        new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString())
                    };

                    //2 - Definir a chave de acesso ao token
                    //instancia a chave simétrica de decodificação
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-games-chave-autenticacao-webApi"));

                    //3 - Definir as credenciais do token (Header)
                    //instancia que será uma chave e qual o tipo de algorítimo da mesma
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //4 - Geração do token
                    //instancia o token do tipo JWT
                    var token = new JwtSecurityToken
                    (
                        //emissor do token - quem está enviando
                        issuer: "senai.inlock.webApi",

                        //destinatário do token - quem está recebendo
                        audience: "senai.inlock.webApi",

                        //quais as claims do token (Payloads)
                        claims: claims,

                        //tempo de expiração do token
                        expires: DateTime.Now.AddMinutes(20),

                        //quais as credenciais do token
                        signingCredentials: creds
                    );

                    //5- Retornar o token criado
                    return Ok
                    (
                        new
                        {
                            //criação do mainupador para gerar o token
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        }
                    );
                }
                else
                {
                    return NotFound("Usuário não encontrado, verifique se o email e a senha estão digitados corretamente e tente novamente.");
                }
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
