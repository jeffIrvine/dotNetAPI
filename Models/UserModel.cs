using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace dotNetAPI.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("TrailName")]
        public string ?TrailName { get; set; }

        [BsonElement("Email")]
        public string ?Email { get; set; }

        public List<ItemModel> Items { get; set; } = new();
    }
}
