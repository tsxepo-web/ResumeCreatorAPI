using MediatR;
using ResumeCreatorAPI.Domain;

namespace ResumeCreatorAPI.Features.Resume.UpdateResume;

public record UpdateResumeCommand(
    Domain.Resume Resume
) : IRequest<UpdateResumeResponse>;
