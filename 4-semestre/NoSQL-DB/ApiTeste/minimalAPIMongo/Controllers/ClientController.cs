using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using minimalAPIMongo.ViewModels;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Users> _users;

        public ClientController(MongoDbService mongoDbServices)
        {
            _client = mongoDbServices.GetDatabase.GetCollection<Client>("client");
            _users = mongoDbServices.GetDatabase.GetCollection<Users>("users");
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            try
            {
                var clientList = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();

                foreach (Client client in clientList)
                {
                    client.User = await _users.Find(u => u.Id == client.UserId).FirstOrDefaultAsync();
                }

                return Ok(clientList);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById(string id)
        {
            try
            {
                //var filter = Builders<Client>.Filter.Eq(c => c.Id, id);

                Client clienteBuscado = await _client.Find(c => c.Id == id).FirstOrDefaultAsync();

                clienteBuscado.User = await _users.Find(u => u.Id == clienteBuscado.UserId).FirstOrDefaultAsync();

                return Ok(clienteBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientViewModel clienteInfo)
        {
            try
            {
                Client novoCliente = new Client()
                {
                    Cpf = clienteInfo.Cpf,
                    Address = clienteInfo.Address,
                    Phone = clienteInfo.Phone,
                    UserId = clienteInfo.UserId,
                    AdditionalAttributes = clienteInfo.AdditionalAttributes
                };

                var usuario = await _users.Find(u => u.Id == clienteInfo.UserId).FirstOrDefaultAsync();

                if(usuario == null)
                {
                    return NotFound("Usuário não existe");
                }

                novoCliente.User = usuario;

                await _client.InsertOneAsync(novoCliente);

                return Ok(novoCliente);
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
                await _client.DeleteOneAsync(c => c.Id == id);
                return Ok("Deletado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ClientViewModel clienteAtualizado)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq(c => c.Id, id);

                List<Client> lista = await _client.Find(filter).ToListAsync();

                Client clienteBuscado = lista.First();

                if (clienteAtualizado.Address != null)
                {
                    clienteBuscado.Address = clienteAtualizado.Address;
                }

                if (clienteAtualizado.Cpf != null)
                {
                    clienteBuscado.Cpf = clienteAtualizado.Cpf;
                }

                if (clienteAtualizado.Phone != null)
                {
                    clienteBuscado.Phone = clienteAtualizado.Phone;
                }

                if (clienteAtualizado.AdditionalAttributes != null)
                {
                    clienteBuscado.AdditionalAttributes = clienteAtualizado.AdditionalAttributes;
                }

                var update = Builders<Client>.Update.Set(c => c.Address, clienteBuscado.Address)
                    .Set(c => c.Cpf, clienteBuscado.Cpf)
                    .Set(c => c.Phone, clienteBuscado.Phone)
                    .Set(c => c.AdditionalAttributes, clienteBuscado.AdditionalAttributes);

                await _client.UpdateOneAsync(filter, update);

                return Ok("Atualizado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
