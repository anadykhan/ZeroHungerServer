using System;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ZeroHungerVS.Models;

namespace ZeroHungerVS.Services
{
	public class OrdersServices
	{
		private readonly IMongoCollection<Order> _ordersCollection;

		public OrdersServices (IOptions<MongoDBSettings> mongoDBSettings)
		{
			MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
			IMongoDatabase databse = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
			_ordersCollection = databse.GetCollection<Order>("orders");
		}

        public async Task CreateAsync(Order order)
        {
            await _ordersCollection.InsertOneAsync(order);
            return;
        }

        public async Task<List<Order>> GetAsync()
        {
            return await _ordersCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateAsync(string id, Order order)
        {
            await _ordersCollection.ReplaceOneAsync(x => x.Id == id, order);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Order> filter = Builders<Order>.Filter.Eq("Id", id);
            await _ordersCollection.DeleteOneAsync(filter);
            return;
        }
    }

}

