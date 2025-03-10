
using MediatR;

namespace ResumeCreatorAPI.Features.Resume.GetResume
{
    public class GetAllResumesHandler : IRequestHandler<GetAllResumesQuery, GetAllResumesResponce>
    {
        private readonly IGetAllResumesRepository _resumeRepository;
        public GetAllResumesHandler(IGetAllResumesRepository getAllResumesRepository)
        {
            _resumeRepository = getAllResumesRepository;
        }
        public async Task<GetAllResumesResponce> Handle(GetAllResumesQuery request, CancellationToken cancellationToken)
        {
            var resumes = await _resumeRepository.GetAllResumesAsync(cancellationToken);
            return new GetAllResumesResponce(resumes);

        }
    }
}