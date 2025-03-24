using MediatR;

namespace ResumeCreatorAPI.Features.Templates;


public record RenderResumeCommand(string ResumeId, string TemplateName) : IRequest<string>;