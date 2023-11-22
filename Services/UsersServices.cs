using System;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ZeroHungerVS.Models;

namespace ZeroHungerVS.Services
{
	public class UsersServices
	{
        private readonly IMongoCollection<User> _userscollection;

        public UsersServices(IOptions<MongoDBSettings> mongoDBSettings)
		{
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase databse = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _userscollection = databse.GetCollection<User>("users");
        }

        public async Task<List<User>> GetAsync()
        {
            return await _userscollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}

