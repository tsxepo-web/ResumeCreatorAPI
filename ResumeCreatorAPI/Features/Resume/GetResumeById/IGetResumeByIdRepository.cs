namespace ResumeCreatorAPI.Features.Resume.GetResumeById
{
    public interface IGetResumeByIdRepository
    {
        Task<Domain.Resume> GetResumeByIdAsync(string id, CancellationToken cancellationToken);
    }
}