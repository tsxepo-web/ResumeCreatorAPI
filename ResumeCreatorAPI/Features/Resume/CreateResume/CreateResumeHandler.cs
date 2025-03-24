using MediatR;
using ResumeCreatorAPI.Features.Resume.CreateResume;
using ResumeCreatorAPI.Infrastructure.Services;

namespace ResumeCreatorAPI.Features.Resume.Commands;

public class CreateResumeHandler : IRequestHandler<CreateResumeCommand, Domain.Resume>
{
    private readonly IResumeRepository _resumeRepository;

    public CreateResumeHandler(IResumeRepository resumeRepository)
    {
        _resumeRepository = resumeRepository;
    }   

    public async Task<Domain.Resume> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
    {
        if (request.Resume == null || request == null)
        {
            throw new ArgumentNullException(nameof(request.Resume), "Resume cannot be null.");
        }
        await _resumeRepository.AddResumeAsync(request.Resume, cancellationToken);

        return request.Resume;
    
    }
}