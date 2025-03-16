namespace ResumeCreatorAPI.Features.User.UpdateUserTier
{
    public interface IUpdateUserTierRepository
    {
        Task<bool> UpdateUserTierAsync(string email, string newTier);
    }
}