using MediatR;

namespace ResumeCreatorAPI.Features.User.UpdateUserTier
{
    public record UpdateUserTierCommand(string Email, string NewTier) : IRequest<bool>;
}