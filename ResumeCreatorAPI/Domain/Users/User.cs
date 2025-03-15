

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ResumeCreatorAPI.Domain.Users
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("passwordHash")]
        public string PasswordHash { get; set; }

        [BsonElement("tier")]
        public string Tier { get; set; } = "free";

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public User(string username, string email, string passwordHash, string tier = "free")
        {
            Id = ObjectId.GenerateNewId().ToString();
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Tier = tier;
            CreatedAt = DateTime.UtcNow;
        }
    }
}