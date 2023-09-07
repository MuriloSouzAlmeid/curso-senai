using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    //define o nome da rota/endpooint
    [Route("api/[controller]")]
    //define que esta rota é um controller
    [ApiController]
    //deine que as requisições e respostas passadas pelo corpo da rota serão em formato json
    [Produces("application/json")]
    //define que precisa estar autenticado para acessar as rotas presentes neste controller
    [Authorize]
    public class EstudioController : ControllerBase
    {
        //instancia o objeto que conterá os métodos necessários para a rota
        private IEstudioRepository _estudioRepository { get; set; }

        //atribui os métodos necessários para o objeto vazio
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Rota responsável por listar todos os estúdios cadastrados no banco de dados
        /// </summary>
        /// <returns>Status code da requisição e a lista dos estúdios</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //instancia a lista que receberá o retorno do método no repositório
                List<EstudioDomain> listaEstudios = _estudioRepository.ListarEstudios();
                
                //retorna a lista com os estúdios
                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                //retorna uma requisição ruim com a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota responsável por buscar determinado estúdio pelo seu id
        /// </summary>
        /// <param name="id">Id do estúdio a ser buscado</param>
        /// <returns>O objeto com as informações do estúdio buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //instancia um objeto recebendo o valor do método de buscar por id
                EstudioDomain estudio = _estudioRepository.BuscarEstudioPorId(id);

                //verifica se o objeto retornado é válido ou nulo
                if (estudio != null)
                {
                    //caso o objeto buscado seja válido retorna um statuscode Ok(200) com o objeto encontrado
                    return Ok(estudio);
                }
                else
                {
                    //caso o objeto encontrado seja nulo retorna um statuscode NotFound(404) com a mensagem dizendo que o objeto não foi encontrado
                    return NotFound("O estúdio com o id informado não foi encontrado.");
                }

            }catch(Exception erro)
            {
                //caso de algum erro retorna uma request ruim informando também qual o erro que deu
                return BadRequest(erro.Message);
            }
        }
    }
}
