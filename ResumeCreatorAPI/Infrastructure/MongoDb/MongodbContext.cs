
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ResumeCreatorAPI.Domain;

namespace ResumeCreatorAPI.Infrastructure.MongoDb
{
    public class MongodbContext
    {
        private readonly IMongoDatabase _database;

        public MongodbContext(IOptions<MongoDbSettings> options)
        {
            try
            {
                var settings = options.Value;
                var client = new MongoClient(settings.ConnectionString);
                _database = client.GetDatabase(settings.DatabaseName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to initialize MongoDB context.", ex);
            }
        }

        public IMongoCollection<Resume> Resumes => _database.GetCollection<Resume>("Resumes");
    }
}