namespace ResumeCreatorAPI.Features.Resume.CreateResume
{
    public interface IResumeRepository
    {
        Task AddResumeAsync(Domain.Resume resume, CancellationToken cancellationToken);
    }
}