using MediatR;

namespace ResumeCreatorAPI.Features.Resume.Commands
{
   public record CreateResumeCommand(
    string UserId,
    Domain.Resume Resume
    ) : IRequest<Domain.Resume>;
}