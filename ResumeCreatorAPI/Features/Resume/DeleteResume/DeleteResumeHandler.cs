using MediatR;

namespace ResumeCreatorAPI.Features.Resume.DeleteResume
{
    public class DeleteResumeHandler : IRequestHandler<DeleteResumeCommand, bool>
    {
        private readonly IDeleteResumeRepository _deleteResumeRepository;
        public DeleteResumeHandler(IDeleteResumeRepository deleteResumeRepository)
        {
            _deleteResumeRepository = deleteResumeRepository;
        }

        public async Task<bool> Handle(DeleteResumeCommand request, CancellationToken cancellationToken)
        {
            return await _deleteResumeRepository.DeleteResumeAsync(request.ResumeId, cancellationToken);
        }
    }
}