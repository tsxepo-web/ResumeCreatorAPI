using MediatR;
using Microsoft.AspNetCore.Identity;
using ResumeCreatorAPI.Features.Resume.CreateResume;
using ResumeCreatorAPI.Infrastructure.Services;

namespace ResumeCreatorAPI.Features.Resume.Commands
{
    public class CreateResumeHandler : IRequestHandler<CreateResumeCommand, Domain.Resume>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ITemplateService _templateService;
        public CreateResumeHandler(IResumeRepository resumeRepository, ITemplateService templateService)
        {
            _resumeRepository = resumeRepository;
            _templateService = templateService;
        }   

        public async Task<Domain.Resume> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
        {
            var resumeCount = await _resumeRepository.CountUserResumesAsync(request.UserId);

        if (resumeCount >= 1)
        {
            return null!;
        }
        await _resumeRepository.AddResumeAsync(request.Resume, cancellationToken: cancellationToken);

        return request.Resume;
        }
    }

}