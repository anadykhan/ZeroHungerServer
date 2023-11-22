using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ZeroHungerVS.Models
{
	public class Order
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? restraunt { get; set; }
        public string? food { get; set; }
        public string? preservation { get; set; }
        public string? employee { get; set; }
        public string? acceptance { get; set; }
    }
}

