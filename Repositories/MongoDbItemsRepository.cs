using MongoDB.Bson;
using MongoDB.Driver;
using RestService.Entities;

namespace RestService.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {

        private const string databaseName = "rest";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDbItemsRepository(IMongoClient mongoClient) 
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }


        public async Task<Item> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        { 
            return await itemsCollection.Find(new BsonDocument()).ToListAsync();    // why not FindAsync
        }

        
        public async Task CreateItemAsync(Item item)
        {
            await itemsCollection.InsertOneAsync(item);
        }


        public async Task UpdateItemAsync(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await itemsCollection.ReplaceOneAsync(filter, item);
        }

        
        public async Task DeleteItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            await itemsCollection.DeleteOneAsync(filter);
        }
    }
}