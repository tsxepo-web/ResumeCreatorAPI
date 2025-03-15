namespace ResumeCreatorAPI.Features.Resume.UpdateResume
{
    public interface IUpdateResumeRepository
    {
        Task<bool> UpdateResumeAsync(Domain.Resume resume, CancellationToken cancellationToken);
    }
}