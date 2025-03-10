using MongoDB.Driver;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Features.Resume.GetResume;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence
{
    public class GetAllResumeRepository : IGetAllResumesRepository
    {
        private readonly IMongoCollection<Resume> _resumeCollection;
        public GetAllResumeRepository(MongodbContext context) => _resumeCollection = context.Resumes;

        public async Task<List<Resume>> GetAllResumesAsync(CancellationToken cancellationToken)
        {
            return await _resumeCollection.Find(_ => true).ToListAsync(cancellationToken);

        }
    }
}