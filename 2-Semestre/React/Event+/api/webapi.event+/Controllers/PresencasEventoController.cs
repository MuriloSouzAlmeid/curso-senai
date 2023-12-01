using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEventoRepository { get; set; }

        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, _presencasEventoRepository.Listar());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarMInhas/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_presencasEventoRepository.ListarMinhas(id));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(PresencasEvento novaPresenca)
        {
            try
            {
                _presencasEventoRepository.Inscrever(novaPresenca);

                return StatusCode(201, "Inscrição realizada com sucesso");
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
