﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Microservices.CatalogAPI.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string Picture { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }
    }
}