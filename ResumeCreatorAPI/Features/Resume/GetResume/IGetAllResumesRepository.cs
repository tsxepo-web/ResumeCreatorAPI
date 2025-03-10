namespace ResumeCreatorAPI.Features.Resume.GetResume
{
    public interface IGetAllResumesRepository
    {
        Task<List<Domain.Resume>> GetAllResumesAsync(CancellationToken cancellationToken);
    }
}