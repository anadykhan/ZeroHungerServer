﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ZeroHungerVS.Models
{
	public class User
	{
		[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
		public string? name { get; set; }
		public string? email { get; set; }
		public string? password { get; set; }
    }
}

