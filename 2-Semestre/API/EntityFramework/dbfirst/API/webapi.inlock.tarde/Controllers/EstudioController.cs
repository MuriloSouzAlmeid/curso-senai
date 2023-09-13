using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;
using webapi.inlock.tarde.Repositories;

namespace webapi.inlock.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception erro)
            {
                //criar uma exceção própria:
                //throw new Exception("Deu Ruim");
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("ListarComJogos")]
        public IActionResult GetWithGames()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Estudio estudio = _estudioRepository.BuscarPorId(id);

                if (estudio != null)
                {
                    return Ok(estudio);
                }
                else
                {
                    return NotFound("Não foi encontrado estúdio com o id informado");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Estudio estudioBuscado = _estudioRepository.BuscarPorId(id);

                if (estudioBuscado != null)
                {
                    _estudioRepository.Deletar(id);

                    return StatusCode(200, "Estúdio deletado com sucesso");
                }
                else
                {
                    return NotFound("Não foi encontrado estúdio com o id informado");
                }
                
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Estudio estudio)
        {
            try
            {
                _estudioRepository.Cadatrar(estudio);

                return StatusCode(201, "Estúdio cadastrado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,Estudio estudio)
        {
            try
            {
                Estudio estudioBuscado = _estudioRepository.BuscarPorId(id);

                if (estudioBuscado != null)
                {
                    _estudioRepository.Atualizar(id, estudio);

                    return Ok("Estúdio Atualizado com sucesso");
                }
                else
                {
                    return NotFound("Não foi encontrado estúdio com o id informado");
                }

                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
