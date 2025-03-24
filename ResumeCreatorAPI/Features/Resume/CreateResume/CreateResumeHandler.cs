using MediatR;
using MongoDB.Driver;
using ResumeCreatorAPI.Features.Resume.CreateResume;
using ResumeCreatorAPI.Infrastructure.Services;

namespace ResumeCreatorAPI.Features.Resume.Commands
{
    public class CreateResumeHandler : IRequestHandler<CreateResumeCommand, Domain.Resume>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ITemplateService _templateService;
        private readonly ILogger<CreateResumeHandler> _logger;

        public CreateResumeHandler(IResumeRepository resumeRepository, ITemplateService templateService, ILogger<CreateResumeHandler> logger)
        {
            _resumeRepository = resumeRepository;
            _templateService = templateService;
            _logger = logger;
        }   

        public async Task<Domain.Resume> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
        {
            if (request.Resume == null || request == null)
            {
                throw new ArgumentNullException(nameof(request.Resume), "Resume cannot be null.");
            }
            var templatePath = Path.Combine("ResumeCreatorAPI", "Features", "Resume", "CreateResume", "Templates", "sample.tex");
            var resumeContent = await _templateService.GenerateResumeFromTemplate(templatePath, request.Resume);
            // var resume = new Domain.Resume { Content = resumeContent };

            await _resumeRepository.AddResumeAsync(request.Resume, cancellationToken);

            return request.Resume;
        
        }
    }

}