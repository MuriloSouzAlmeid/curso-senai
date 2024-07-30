using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IMongoCollection<Users> _users;

        public UsersController(MongoDbService mongoDbService)
        {
            _users = mongoDbService.GetDatabase.GetCollection<Users>("users");
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> Get()
        {
            try
            {
                var usersList = await _users.Find(FilterDefinition<Users>.Empty).ToListAsync();
                return Ok(usersList);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetById(string id)
        {
            try
            {
                var filter = Builders<Users>.Filter.Eq(u => u.Id, id);

                List<Users> usuarioBuscado = await _users.Find(filter).ToListAsync();

                return Ok(usuarioBuscado.First());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Users usuarioInfo)
        {
            try
            {
                Users novoUsuario = new Users()
                {
                    Name = usuarioInfo.Name,
                    Email = usuarioInfo.Email,
                    Password = usuarioInfo.Password,
                    AdditionalAttributes = usuarioInfo.AdditionalAttributes
                };

                await _users.InsertOneAsync(novoUsuario);

                return Ok(novoUsuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _users.DeleteOneAsync(u => u.Id == id);
                return Ok("Deletado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Users usuarioAtualizado)
        {
            try
            {
                var filter = Builders<Users>.Filter.Eq(u => u.Id, id);

                List<Users> lista = await _users.Find(filter).ToListAsync();

                Users usuarioBuscado = lista.First();

                if (usuarioAtualizado.Name != null)
                {
                    usuarioBuscado.Name = usuarioAtualizado.Name;
                }

                if (usuarioAtualizado.Email != null)
                {
                    usuarioBuscado.Email = usuarioAtualizado.Email;
                }

                if (usuarioAtualizado.Password != null)
                {
                    usuarioBuscado.Password = usuarioAtualizado.Password;
                }

                if (usuarioAtualizado.AdditionalAttributes != null)
                {
                    usuarioBuscado.AdditionalAttributes = usuarioAtualizado.AdditionalAttributes;
                }

                var update = Builders<Users>.Update.Set(p => p.Name, usuarioBuscado.Name)
                    .Set(u => u.Email, usuarioBuscado.Email)
                    .Set(u => u.Password, usuarioBuscado.Password)
                    .Set(u => u.AdditionalAttributes, usuarioBuscado.AdditionalAttributes);

                await _users.UpdateOneAsync(filter, update);

                return Ok("Atualizado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
