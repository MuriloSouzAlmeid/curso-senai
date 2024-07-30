using MongoDB.Bson.Serialization.Attributes;

namespace minimalAPIMongo.ViewModels
{
    public class ClientViewModel
    {
        public string? Cpf { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public Dictionary<string, string>? AdditionalAttributes { get; set; }

        public string? UserId { get; set; }
    }
}
