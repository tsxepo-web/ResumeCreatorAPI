using MongoDB.Driver;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence
{
    public class DeleteResumeRepository
    {
        private readonly IMongoCollection<Resume> _resumeCollection;
        public DeleteResumeRepository(MongodbContext context) => _resumeCollection = context.Resumes;
        public async Task<bool> DeleteResumeAsync(string id, CancellationToken cancellationToken)
        {
            var result = await _resumeCollection.DeleteOneAsync(r => r.Id == id, cancellationToken);
            return result.DeletedCount > 0;
        }
    }
}