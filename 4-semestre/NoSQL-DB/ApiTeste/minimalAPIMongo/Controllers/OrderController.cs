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
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Users> _users;
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Product> _product;

        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
            _users = mongoDbService.GetDatabase.GetCollection<Users>("users");
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                List<Order> listaDePedidos = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();

                foreach(Order order in listaDePedidos)
                {
                    if(order.ProductId != null)
                    {
                        var filter = Builders<Product>.Filter.In(p => p.Id, order.ProductId);

                        // trás uma lista com where no caso seria o filter
                        order.Products = await _product.Find(filter).ToListAsync();
                    }

                    if(order.ClientId != null)
                    {
                        order.Client = await _client.Find(c => c.Id == order.ClientId).FirstOrDefaultAsync();
                    }
                }

                return Ok(listaDePedidos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(string id)
        {
            try
            {
                Order pedidoBuscado = await _order.Find(o => o.Id == id).FirstOrDefaultAsync();

                if(pedidoBuscado == null)
                {
                    return NotFound("Pedido não encontrado");
                }

                Client cliente = await _client.Find(c => c.Id == pedidoBuscado.ClientId).FirstOrDefaultAsync();

                if(cliente != null)
                {
                    pedidoBuscado.Client = cliente;
                }

                foreach(string idPedido in pedidoBuscado.ProductId!)
                {
                    List<Product> listaDeProdutos = await _product.Find(p => p.Id == idPedido).ToListAsync();

                    pedidoBuscado.Products = listaDeProdutos;
                }

                return Ok(pedidoBuscado);

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderViewModel infoPedido)
        {
            try
            {
                Order novoPedido = new Order() { 
                    ClientId = infoPedido.ClientId,
                    Date = infoPedido.Date,
                    Status = infoPedido.Status,
                    ProductId = infoPedido.ProductsList
                };

                Client clienteBuscado = await _client.Find(c => c.Id == infoPedido.ClientId).FirstOrDefaultAsync();

                if(clienteBuscado == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                if(infoPedido.ProductsList == null)
                {
                    return NotFound("Especifique os produtos do pedido");
                }

                foreach(string id in infoPedido.ProductsList)
                {
                    Product produto = await _product.Find(p => p.Id == id).FirstOrDefaultAsync();

                    if(produto == null)
                    {
                        return NotFound("Produto não encontrado");
                    }
                }

                await _order.InsertOneAsync(novoPedido);

                return Ok("Cadastrado com sucesso!");
               
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                Order pedidoBuscado = await _order.Find(o => o.Id == id).FirstOrDefaultAsync();

                if(pedidoBuscado == null)
                {
                    return NotFound("Pedido não encintrado");
                }

                await _order.DeleteOneAsync(o => o.Id == id);

                return Ok("Deletado com sucesso");

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] OrderViewModel pedidoAtualizado)
        {
            try
            {
                Order pedidoBuscado = await _order.Find(o => o.Id == id).FirstOrDefaultAsync();

                if (pedidoBuscado == null)
                {
                    return NotFound("Pedido não encintrado");
                }

                if (pedidoAtualizado.Status != null)
                {
                    pedidoBuscado.Status = pedidoAtualizado.Status;
                }

                if(pedidoAtualizado.Date != null)
                {
                    pedidoBuscado.Date = pedidoAtualizado.Date;
                }

                if(pedidoAtualizado.ClientId != null)
                {
                    Client clientBuscado = await _client.Find(c => c.Id == pedidoAtualizado.ClientId).FirstOrDefaultAsync();

                    if(clientBuscado == null) 
                    {
                        return NotFound("Cliente não encontrado");
                    }

                    pedidoBuscado.ClientId = pedidoAtualizado.ClientId;
                    pedidoBuscado.Client = clientBuscado;
                }

                if(pedidoAtualizado.ProductsList != null)
                {
                    List<Product> products = new List<Product>();
                    foreach(string idProduto in pedidoAtualizado.ProductsList)
                    {
                        Product produto = await _product.Find(p => p.Id == idProduto).FirstOrDefaultAsync();

                        if(produto == null)
                        {
                            return NotFound("Erro ao cadastrar produtos");
                        }

                        products.Add(produto);
                    }

                    pedidoBuscado.ProductId = pedidoAtualizado.ProductsList;
                    pedidoBuscado.Products = products;
                }

                var update = Builders<Order>.Update.Set(o => o.Status, pedidoBuscado.Status)
                                                   .Set(o => o.Date, pedidoBuscado.Date)
                                                   .Set(o => o.Products, pedidoBuscado.Products)
                                                   .Set(o => o.ProductId, pedidoBuscado.ProductId)
                                                   .Set(o => o.ClientId, pedidoBuscado.ClientId)
                                                   .Set(o => o.Client, pedidoBuscado.Client);

                var filter = Builders<Order>.Filter.Eq(o => o.Id, id);

                await _order.UpdateOneAsync(filter, update);

                return Ok("Pedido Atualizado");
            }
            catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
