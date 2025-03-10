using MongoDB.Driver;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Features.Resume.GetResumeById;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence
{
    public class GetResumeByIdRepository : IGetResumeByIdRepository
    {
        private readonly IMongoCollection<Resume> _resumeCollection;
        public GetResumeByIdRepository(MongodbContext context) => _resumeCollection = context.Resumes;
        public async Task<Resume> GetResumeByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _resumeCollection.Find(r => r.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}