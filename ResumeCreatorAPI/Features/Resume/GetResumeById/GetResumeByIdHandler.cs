using MediatR;

namespace ResumeCreatorAPI.Features.Resume.GetResumeById
{
    public class GetResumeByIdHandler : IRequestHandler<GetResumeByIdQuery, GetResumeByIdResponse>
    {
    private readonly IGetResumeByIdRepository _repository;
        public GetResumeByIdHandler(IGetResumeByIdRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetResumeByIdResponse> Handle(GetResumeByIdQuery request, CancellationToken cancellationToken)
        {
                  
            var resume = await _repository.GetResumeByIdAsync(request.Id, cancellationToken) ?? throw new KeyNotFoundException($"Resume with ID {request.Id} not found.");
            return new GetResumeByIdResponse(resume);
        }
    }
}