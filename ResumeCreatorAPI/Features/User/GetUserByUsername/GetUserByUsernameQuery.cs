using MediatR;

namespace ResumeCreatorAPI.Features.User.GetUserByUsername
{
    public record GetUserByUsernameQuery(string Username) : IRequest<GetUserByUsernameResponse>;
}