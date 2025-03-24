using System.Threading.Tasks;
using ResumeCreatorAPI.Domain;

namespace ResumeCreatorAPI.Infrastructure.Services;

public class TemplateService : ITemplateService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<TemplateService> _logger;
    public TemplateService(IConfiguration configuration, ILogger<TemplateService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
    public async Task<string> LoadTemplate(string templateName)
    {
        var templatePath = Path.Combine(_configuration["TemplatesPath"]!, $"{templateName}.tex");

        _logger.LogInformation("Template Path: {TemplatePath}", templatePath);

        if (File.Exists(templatePath))
        {
            return await File.ReadAllTextAsync(templatePath);
        }

        throw new FileNotFoundException($"Template {templateName} not found");

    }
    public async Task<List<string>> GetAllTemplatesAsync()
    {
        var templatePath = _configuration["TemplatesPath"];
        var directoryInfo = new DirectoryInfo(templatePath!);

        var templates = directoryInfo
            .GetFiles("*.tex")
            .Select(file => Path.GetFileNameWithoutExtension(file.Name))
            .ToList();

        return await Task.FromResult(templates);
    }

    public async Task<string> RenderResumeToLatex(Resume resume, string templateName)
    {
        var template = await LoadTemplate(templateName);

        var renderedLaTex = template
            .Replace("{{name}}", resume.Basics!.Name ?? "John Doe")
            .Replace("{email}", resume.Basics?.Email ?? "email@example.com")
            .Replace("{phone}", resume.Basics?.Phone ?? "(000) 000-0000")
            .Replace("{summary}", resume.Basics?.Summary ?? "Summary not provided");

        return renderedLaTex;
    }
}