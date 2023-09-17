using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Repositories;
using webapi.inlock.codefirst.ViewModels;

namespace webapi.inlock.codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class EstudioController : ControllerBase
    {
        private readonly IEstudioRepository _estudioRepository;
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Rota para listar todos os estúdios cadastrados junto com seus jogos.
        /// </summary>
        /// <returns>Lista com os estúdios cadastrados</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Estudio> listaDeEstudios = _estudioRepository.ListarEstudios();

                return Ok(listaDeEstudios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para buscar determinado estúdio pelo seu id
        /// </summary>
        /// <param name="id">Id do estúdio a ser buscado</param>
        /// <returns>Estudio com o id informado</returns>
        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Estudio estudioBuscado = _estudioRepository.BuscarEstudioPorId(id);

                return Ok(estudioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para cadastrar um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto contendo as informações do estúdio a ser cadastrado</param>
        /// <returns>StatusCode da requisição</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult CadastrarEstudio(EstudioViewModel novoEstudio)
        {
            try
            {
                Estudio estudio = new Estudio()
                {
                    Nome = novoEstudio.NomeEstudio
                };

                _estudioRepository.CadastarEstudio(estudio);

                return Ok("O estúdio foi cadastrado com sucesso!");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para deletar um estúdio por seu id
        /// </summary>
        /// <param name="id">Id do estúdio a ser deletado</param>
        /// <returns>StatusCode da requisição</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Estudio estudioBuscado = _estudioRepository.BuscarEstudioPorId(id);

                if(estudioBuscado == null)
                {
                    return NotFound("Não há estúdio cadastrado com o id informado.");
                }
                else
                {
                    _estudioRepository.DeletarEsudio(id);
                }

                return Ok("Estúdio deletado com sucesso");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar um estúdio pelo seu id
        /// </summary>
        /// <param name="id">Id do estúdio a ser atualizado</param>
        /// <param name="estudioAtualizado">Objeto contendo as novas informações do estúdio</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, EstudioViewModel estudioAtualizado)
        {
            try
            {
                Estudio estudioBuscado = _estudioRepository.BuscarEstudioPorId(id);

                if(estudioBuscado == null)
                {
                    return NotFound("Não há estúdio cadastrado com o id informado.");
                }
                else
                {
                    Estudio estudio = new Estudio()
                    {
                        Nome = estudioAtualizado.NomeEstudio
                    };

                    _estudioRepository.AtualizarEstudio(id, estudio);

                    return Ok("Estúdio atualizado com sucesso!");
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);   
            }
        }
    }
}
