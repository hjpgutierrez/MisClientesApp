using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MisClientesApp.Server.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string username { get; set; } = null!;

        public int totalDeuda { get; set; }
        public string celular { get; set; } = null!;

        public Cliente(string username, int totalDeuda, string celular)
        {
            this.username = username;
            this.totalDeuda = totalDeuda;
            this.celular = celular;
        }
    }
}
