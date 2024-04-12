using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contexts;
using WebAPI.Domains;
using WebAPI.Utils.Mail;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperarSenhaController : ControllerBase
    {
        private readonly VitalContext _context;
        private readonly EmailSendingService _emailSendingService;
        public RecuperarSenhaController(VitalContext context, EmailSendingService emailSendingService)
        {
            _context = context;
            _emailSendingService = emailSendingService;
        }

        [HttpPost]
        public async Task<IActionResult> SendRecoveryCodePassword(string email)
        {
            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

                if (user == null)
                {
                    return NotFound("Usuario não encontrado");
                }

                //Gerar um código com 4 algarismos

                Random random = new Random();
                int recoveryCode = random.Next(1000, 9999);

                user.CodRecupSenha = recoveryCode;

                await _context.SaveChangesAsync();

                await _emailSendingService.SendRecovery(user.Email!, recoveryCode);

                return Ok("Enviado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("EnviarCodigo")]
        public async Task<IActionResult> PostCodigoRedefinir(string email, int codigo)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(user => user.Email == email)!;

                if(usuario == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                if(usuario.CodRecupSenha != codigo)
                {
                    return BadRequest("Código informado inválido, tente novamente");
                }
             
                usuario.CodRecupSenha = null;

                await _context.SaveChangesAsync();

                return Ok("Código válido, recupera a senha aí");
                
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);   
            }
        }
    }
}
