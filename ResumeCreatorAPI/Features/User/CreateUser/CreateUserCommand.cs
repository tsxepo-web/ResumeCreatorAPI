using MediatR;

namespace ResumeCreatorAPI.Features.User.CreateUser
{
    public record CreateUserCommand(
        string UserName,
        string Email,
        string Password,
        string Tier

    ) : IRequest<Domain.Users.User>;
}