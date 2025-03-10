

using MediatR;

namespace ResumeCreatorAPI.Features.Resume.DeleteResume
{
    public record DeleteResumeCommand(string ResumeId) : IRequest<bool>;
}