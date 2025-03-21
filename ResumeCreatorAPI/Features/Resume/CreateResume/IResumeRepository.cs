namespace ResumeCreatorAPI.Features.Resume.CreateResume
{
    public interface IResumeRepository
    {
        Task<long> CountUserResumesAsync(string email);       
        Task AddResumeAsync(Domain.Resume resume, CancellationToken cancellationToken);
    }
}