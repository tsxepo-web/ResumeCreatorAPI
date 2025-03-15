namespace ResumeCreatorAPI.Features.User.GetUserByEmail
{
    public interface IGetUserByEmailRepository
    {
        Task<Domain.Users.User> GetUserByEmail(string email, CancellationToken cancellationToken);
    }
}