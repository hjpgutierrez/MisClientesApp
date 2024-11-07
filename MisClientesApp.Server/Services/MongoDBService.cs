using Microsoft.Extensions.Options;
using MisClientesApp.Server.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MisClientesApp.Server.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Cliente> _clienteCollection;
        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _clienteCollection = database.GetCollection<Cliente>(mongoDBSettings.Value.CollectionName);
        }
        public async Task<List<Cliente>> GetAsync() {
            return await _clienteCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(Cliente client) {
            await _clienteCollection.InsertOneAsync(client);
            return;
        }

        public async Task DeleteAsync(string id) {
            FilterDefinition<Cliente> filter = Builders<Cliente>.Filter.Eq("Id", id);
            await _clienteCollection.DeleteOneAsync(filter);            
            return;
        }
    }
}
