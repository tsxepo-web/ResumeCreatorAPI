using MongoDB.Driver;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Features.Resume.GetResumeById;
using ResumeCreatorAPI.Features.Resume.UpdateResume;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence
{
    public class UpdateResumeRepository : IUpdateResumeRepository
    {
        private readonly IMongoCollection<Resume> _resumeCollection;
        private readonly IGetResumeByIdRepository _getByIdRepository;
        public UpdateResumeRepository(MongodbContext context, IGetResumeByIdRepository getResumeByIdRepository)
        {
            _resumeCollection = context.Resumes;
            _getByIdRepository = getResumeByIdRepository;
}

        public async Task<bool> UpdateResumeAsync(Resume resume, CancellationToken cancellationToken)
        {
            var existingResume = await _getByIdRepository.GetResumeByIdAsync(resume.Id!, cancellationToken);
            if (existingResume == null)
            {
                return false;
            }
            var filter = Builders<Resume>.Filter.Eq(r => r.Id, resume.Id);
            var update = Builders<Resume>.Update
                .Set(r => r.PersonalInfo, resume.PersonalInfo)
                .Set(r => r.Certifications, resume.Certifications)
                .Set(r => r.Educations, resume.Educations)
                .Set(r => r.Experiences, resume.Experiences)
                .Set(r => r.Skills, resume.Skills)
                .Set(r => r.TemplateStyle, resume.TemplateStyle);

            var result = await _resumeCollection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
            return result.ModifiedCount > 0;
        }
    }
}