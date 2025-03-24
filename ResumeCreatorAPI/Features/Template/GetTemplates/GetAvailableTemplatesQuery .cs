using MediatR;

namespace ResumeCreatorAPI.Features.Templates.GetTemplates;

public record GetAvailableTemplatesQuery(string TemplateName) : IRequest<List<string>>;