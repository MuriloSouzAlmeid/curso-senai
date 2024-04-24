using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebAPI.Domains;
using WebAPI.Interfaces;
using WebAPI.Repositories;
using WebAPI.Utils.BlobStorage;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository usuarioRepository { get; set; }

        public UsuarioController()
        {
            usuarioRepository = new UsuarioRepository();
        }

        [HttpPut("AlterarSenha")]
        public IActionResult UpdatePassword(string email, AlterarSenhaViewModel senha)
        {
            try
            {
                usuarioRepository.AlterarSenha(email, senha.SenhaNova!);

                return Ok("Senha alterada com sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(usuarioRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlterarFotoPerfil")]
        public async Task<IActionResult> UploadProfileImage(Guid idUsuario, [FromForm] UsuarioViewModel user)
        {
            try
            {
                Usuario usuarioBuscado = usuarioRepository.BuscarPorId(idUsuario);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário com o id especificado não foi encontrado");
                }

                //Lógica para upload de imagem
                var containerName = "containervitalhubmurilosouza";

                var connectionString = "DefaultEndpointsProtocol=https;AccountName=blobvitalhubmurilosouza;AccountKey=xLTBTBQrWWeGAwbhMuF2dRXRnZODofXuT5+7J5zhoH0hh4hMUkWC8K/0g3nKq9gDa8Fnu02+YhPR+AStWEqzWQ==;EndpointSuffix=core.windows.net";


                var fotoUrl = await AzureBlobStorageHelper.UploadImageBlobAsync(user.Arquivo!, connectionString, containerName);

                usuarioRepository.AtualizarFoto(idUsuario, fotoUrl);

                return Ok("Foto de perfil atualizada com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
