using MediatR;

namespace ResumeCreatorAPI.Features.Resume.Commands
{
   public record CreateResumeCommand(
    Domain.Resume Resume
    ) : IRequest<Domain.Resume>;
}