using MongoDB.Driver;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence
{
    public class UpdateResumeRepository
    {
        private readonly IMongoCollection<Resume> _resumeCollection;
        public UpdateResumeRepository(MongodbContext context) => _resumeCollection = context.Resumes;
        public async Task<bool> UpdateResumeAsync(string id, Resume updatedResume, CancellationToken cancellationToken)
        {
            var result = await _resumeCollection.ReplaceOneAsync(r => r.Id == id, updatedResume, cancellationToken: cancellationToken);
            return result.ModifiedCount > 0;
        }
    }
}