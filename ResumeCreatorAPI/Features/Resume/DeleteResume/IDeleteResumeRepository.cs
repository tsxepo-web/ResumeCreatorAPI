namespace ResumeCreatorAPI.Features.Resume.DeleteResume
{
    public interface IDeleteResumeRepository
    {
        Task<bool> DeleteResumeAsync(string resumeId, CancellationToken cancellationToken);
    }
}