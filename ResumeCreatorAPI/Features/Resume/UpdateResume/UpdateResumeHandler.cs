using MediatR;
using ResumeCreatorAPI.Features.Resume.GetResumeById;

namespace ResumeCreatorAPI.Features.Resume.UpdateResume
{
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
            var existingResume = await _getResumeByIdRepository.GetResumeByIdAsync(request.Id, cancellationToken);
            if (existingResume == null)
            {
                return new UpdateResumeResponse(false, $"Resume with ID {request.Id} not found.");
            }
            existingResume.PersonalInfo = request.PersonalInfo;
            existingResume.Educations = request.Educations;
            existingResume.Experiences = request.Experiences;
            existingResume.Skills = request.Skills;
            existingResume.Certifications = request.Certifications;
            existingResume.TemplateStyle = request.TemplateStyle;

            var updated = await _repository.UpdateResumeAsync(existingResume, cancellationToken);
            
            return updated
                ? new UpdateResumeResponse(true, "Resume updated successfully.")
                : new UpdateResumeResponse(false, "Failed to update resume.");
        }
    }
}