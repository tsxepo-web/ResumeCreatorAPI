using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using ResumeCreatorAPI.Features.Resume.GetResumeById;
using ResumeCreatorAPI.Infrastructure.Services;

namespace ResumeCreatorAPI.Features.Templates;

public class RenderResumeCommandHandler : IRequestHandler<RenderResumeCommand, string>
{
    private readonly ITemplateService _templateService;
    private readonly IGetResumeByIdRepository _getResumeByIdRepository;
    public RenderResumeCommandHandler(ITemplateService templateService, IGetResumeByIdRepository getResumeByIdRepository)
    {
        _templateService = templateService;
        _getResumeByIdRepository = getResumeByIdRepository;
    }
    public async Task<string> Handle(RenderResumeCommand request, CancellationToken cancellationToken)
    {
        var resume = await _getResumeByIdRepository.GetResumeByIdAsync(request.ResumeId, cancellationToken);
        if (resume == null)
        {
            throw new KeyNotFoundException("Resume not found");
        }

        return await _templateService.RenderResumeToLatex(resume, request.TemplateName);
    }
}