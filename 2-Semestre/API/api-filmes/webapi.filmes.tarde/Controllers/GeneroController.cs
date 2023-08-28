using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controllers
{

    /// <summary>
    /// Route: define que a rota de uma requisição será no seguinte formato: dominio/api/nomeController
    /// Ex: http://Localhost:5000/api/genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// ApiController: Define que é um controlador de api
    /// </summary>
    [ApiController]

    /// <summary>
    /// Route: Define que o tipo de resposta da api é JSON
    /// </summary>
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }
        public GeneroController()
        {
            /// <summary>
            /// Instância do objeto _generoRepository para que haja referência aos métodos do repositório
            /// </summary>
            _generoRepository = new GeneroRepository();
        }


        /// <summary>
        /// EndPoint que acessa o método de listar todos os generos 
        /// </summary>
        /// <returns>Lista de generos e um StatusCode</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista para receber os generos
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

                //Retorna o status code 200 "OK" e a lista de generos no formato JSON
                return StatusCode(200, ListaGeneros);
                //return Ok(ListaGeneros);
            }
            catch (Exception erro)
            {
                //Retorna um StatusCode 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// EndPoint que acessa o método de buscar determinado gênero por seu id
        /// </summary>
        /// <param name="id">Id do gênero a ser buscado</param>
        /// <returns>As informações do gênero buscado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                GeneroDomain genero = _generoRepository.BuscarPorId(id);

                if (genero == null)
                {
                    return StatusCode(404, "Não existe gênero cadastrado com o Id informado");
                }
                else
                {
                    return StatusCode(200, genero);
                }
                
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de cadastrar gêneros
        /// </summary>
        /// <param name="genero">Ojeto recebido da requisição</param>
        /// <returns>Status code e mensagen a ser exibida</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain genero)
        {
            try
            {
                //Conversando com o repository
                _generoRepository.Cadastrar(genero);

                //mandando a response com o que será exibido junto do statuscode
                //return Created("Genero cadastrado com sucsso", genero);
                return StatusCode(201, "Gênero cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                //mandando a response
                return BadRequest(erro.Message);

            }
        }

        /// <summary>
        /// Endpoint que acessa o método de deletar gêneros
        /// </summary>
        /// <param name="_id">Id do gênero a ser deletado</param>
        /// <returns>Status code e mensagen a ser exibida</returns>
        [HttpDelete("{_id}")]
        public IActionResult Delete(int _id)
        {
            try
            {
                GeneroDomain genero = _generoRepository.BuscarPorId(_id);

                if(genero == null)
                {
                    return StatusCode(404, "Não existe gênero cadastrado com o Id informado");
                    
                }
                else
                {
                    _generoRepository.Deletar(_id);

                    return StatusCode(200, "O gênero foi deletado com sucesso");
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de atualizar gêneros pelo Id no corpo
        /// </summary>
        /// <param name="_genero">Objeto com as novas informações do gênero</param>
        /// <returns>Status code e mensagen a ser exibida</returns>
        [HttpPut]
        public IActionResult Put(GeneroDomain _genero)
        {
            try
            {
                _generoRepository.AtualizarPorIdGenero(_genero);

                return StatusCode(200, "O gênero foi atualizado com sucesso");
            }
            catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de atualizar gêneros pelo Id na Url
        /// </summary>
        /// <param name="_id">Id do gênero a ser atualizado</param>
        /// <param name="_genero">Objeto com as novas informações do gênero a ser atualizado</param>
        /// <returns></returns>
        [HttpPut("{_id}")]
        public IActionResult Put(int _id, GeneroDomain _genero)
        {
            try
            {
                GeneroDomain _generoBuscado = _generoRepository.BuscarPorId(_id);

                if (_generoBuscado == null)
                {
                    return StatusCode(404, "Não existe gênero cadastrado com o Id informado");
                   
                }
                else
                {
                    _generoRepository.AtualizarIdUrl(_id, _genero);

                    return StatusCode(200, "O gênero foi atualizado com sucesso");
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}