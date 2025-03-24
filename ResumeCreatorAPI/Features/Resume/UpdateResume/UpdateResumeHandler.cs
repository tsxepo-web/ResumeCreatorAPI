using MediatR;
using ResumeCreatorAPI.Features.Resume.GetResumeById;

namespace ResumeCreatorAPI.Features.Resume.UpdateResume;

public class UpdateResumeHandler : IRequestHandler<UpdateResumeCommand, UpdateResumeResponse>
{
    private readonly IUpdateResumeRepository _repository;
    private readonly IGetResumeByIdRepository _getResumeByIdRepository;
    public UpdateResumeHandler(IUpdateResumeRepository repository, IGetResumeByIdRepository getResumeByIdRepository)
    {
        _repository = repository;
        _getResumeByIdRepository = getResumeByIdRepository;
    }

    public async Task<UpdateResumeResponse> Handle(UpdateResumeCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Resume.Id))
        {
           return new UpdateResumeResponse(false, "Resume ID cannot be null or empty.");
        }
        var existingResume = await _getResumeByIdRepository.GetResumeByIdAsync(request.Resume.Id, cancellationToken);

        existingResume = request.Resume;
        
        var updated = await _repository.UpdateResumeAsync(existingResume, cancellationToken);
        
        return updated
            ? new UpdateResumeResponse(true, "Resume updated successfully.")
            : new UpdateResumeResponse(false, "Failed to update resume.");
    }
}