using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace minimalAPIMongo.Domains
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("date")]
        public DateTime? Date { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        //Referência aos produtos do pedido
        [BsonElement("productId")]
        public List<string>? ProductId { get; set; }

        public List<Product>? Products { get; set; }


        //Referência ao cliente do pedido
        [BsonElement("clientId")]
        public string? ClientId { get; set;}

        public Client? Client { get; set; }
    }
}
