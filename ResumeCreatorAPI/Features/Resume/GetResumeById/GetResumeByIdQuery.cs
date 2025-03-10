using MediatR;

namespace ResumeCreatorAPI.Features.Resume.GetResumeById
{
    public record GetResumeByIdQuery(string Id) : IRequest<GetResumeByIdResponse>;
}