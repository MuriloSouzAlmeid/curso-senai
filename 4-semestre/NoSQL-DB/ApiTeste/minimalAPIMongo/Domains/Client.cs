using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace minimalAPIMongo.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("cpf")]
        public string? Cpf { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        public Dictionary<string, string>? AdditionalAttributes { get; set; }


        //Referência do usuário
        public string? UserId { get; set; }

        public Users? User { get; set; }


        public Client()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }
    }
}
