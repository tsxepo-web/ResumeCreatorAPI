using ResumeCreatorAPI.Domain;

namespace ResumeCreatorAPI.Infrastructure.Services
{
    public interface ITemplateService
    {
        Task<string> LoadTemplate(string templateName);
        Task<string> RenderResumeToLatex(Resume resume, string templateName);
        List<string> GetAllTemplatesAsync();
    }
}