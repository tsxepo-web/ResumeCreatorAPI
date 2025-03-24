using MongoDB.Driver;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Features.Resume.CreateResume;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly IMongoCollection<Resume> _resumeCollection;
        public ResumeRepository(MongodbContext context)
        {
            _resumeCollection = context.Resumes;
        }

        public async Task AddResumeAsync(Resume resume, CancellationToken cancellationToken)
        {
            await _resumeCollection.InsertOneAsync(resume);
        }
    }
}