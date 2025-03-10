using MediatR;

namespace ResumeCreatorAPI.Features.Resume.GetResume
{
    public record GetAllResumesQuery() : IRequest<GetAllResumesResponce>;
}