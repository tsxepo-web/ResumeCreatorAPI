namespace ResumeCreatorAPI.Features.User.CreateUser
{
    public interface ICreateUserRepository
    {
        Task CreateUserAsync(Domain.Users.User user, CancellationToken cancellationToken);
        // Task UpdateUserTier(string userId, string newTier);
        // Task<bool> CanCreateResume(string userId);
    }
}