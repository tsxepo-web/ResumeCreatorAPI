namespace ResumeCreatorAPI.Features.Resume.UpdateResume
{
    public interface IUpdateResumeRepository
    {
        Task<bool> UpdateResumeAsync(string resumeId, Domain.Resume UpdatedResume, CancellationToken cancellationToken);
    }
}