using MongoDB.Driver;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Features.Resume.DeleteResume;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence
{
    public class DeleteResumeRepository : IDeleteResumeRepository
    {
        private readonly IMongoCollection<Resume> _resumeCollection;
        public DeleteResumeRepository(MongodbContext context) => _resumeCollection = context.Resumes;
        public async Task<bool> DeleteResumeAsync(string resumeId, CancellationToken cancellationToken)
        {
            var result = await _resumeCollection.DeleteOneAsync(r => r.Id == resumeId, cancellationToken);
            return result.DeletedCount > 0;
        }
    }
}