using ResumeCreatorAPI.Domain;

namespace ResumeCreatorAPI.Infrastructure.Services
{
    public interface ITemplateService
    {
        Task<string> GenerateResumeFromTemplate(string templatePath, Resume resume);
    }
}