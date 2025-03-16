namespace ResumeCreatorAPI.Features.User.GetUserByUsername
{
    public interface IGetUserByUsernameRepository
    {
        Task<Domain.Users.User> GetUserByUsernameAsync(string username, CancellationToken cancellationToken);
    }
}