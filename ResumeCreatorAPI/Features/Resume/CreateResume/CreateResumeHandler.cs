using MediatR;
using ResumeCreatorAPI.Features.Resume.CreateResume;
using ResumeCreatorAPI.Infrastructure.Services;

namespace ResumeCreatorAPI.Features.Resume.Commands
{
    public class CreateResumeHandler : IRequestHandler<CreateResumeCommand, CreateResumeResponse>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ITemplateService _templateService;
        public CreateResumeHandler(IResumeRepository resumeRepository, ITemplateService templateService)
        {
            _resumeRepository = resumeRepository;
            _templateService = templateService;
        }   

        public async Task<CreateResumeResponse> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
        {
            var resume = new Domain.Resume(

                request.PersonalInfo,
                request.Educations,
                request.Experiences,
                request.Skills,
                request.Certifications,
                _templateService.GenerateTemplate(request.TemplateStyle)
            );
            await _resumeRepository.AddResumeAsync(resume, cancellationToken: cancellationToken);

            return new CreateResumeResponse(resume.Id!);
        }
    }

}