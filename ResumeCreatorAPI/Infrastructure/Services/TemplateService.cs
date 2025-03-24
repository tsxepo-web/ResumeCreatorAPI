using ResumeCreatorAPI.Domain;

namespace ResumeCreatorAPI.Infrastructure.Services
{
    public class TemplateService : ITemplateService
    {
        public async Task<string> GenerateResumeFromTemplate(string templatePath, Resume resume)
        {
            var templateContent = await File.ReadAllTextAsync(templatePath);
            var filledTemplate = templateContent.Replace("{{Name}}", resume.PersonalInfo!.Name).Replace("{{Email}}", resume.PersonalInfo.Email);

            return filledTemplate;
        }
    }
}