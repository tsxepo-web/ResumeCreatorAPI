namespace ResumeCreatorAPI.Infrastructure.Services
{
    public class TemplateService : ITemplateService
    {
        public string GenerateTemplate(string? templateStyle)
        {
            return templateStyle ?? "default-template";
        }

    }
}