using MediatR;
using ResumeCreatorAPI.Infrastructure.Services;

namespace ResumeCreatorAPI.Features.Templates.GetTemplates;

public class GetAvailableTemplatesQueryHandler : IRequestHandler<GetAvailableTemplatesQuery, List<string>>
{
    private readonly ITemplateService _templateService;
    public GetAvailableTemplatesQueryHandler(ITemplateService templateService)
    {
        _templateService = templateService;
    }


    public async Task<List<string>> Handle(GetAvailableTemplatesQuery request, CancellationToken cancellationToken)
    {
        var allTemplates = _templateService.GetAllTemplatesAsync();
        if (!string.IsNullOrEmpty(request.TemplateName))
        {
            var filteredTemplates = allTemplates
                .Where(template => template.Contains(request.TemplateName, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return filteredTemplates;
        }
        return allTemplates;
    }
}