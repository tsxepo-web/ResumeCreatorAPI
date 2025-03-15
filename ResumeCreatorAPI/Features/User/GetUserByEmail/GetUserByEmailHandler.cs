using MediatR;

namespace ResumeCreatorAPI.Features.User.GetUserByEmail
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, GetUserByEmailResponse>
    {
        private readonly IGetUserByEmailRepository _getUserByEmail;
        public GetUserByEmailHandler(IGetUserByEmailRepository getUserByEmail)
        {
            _getUserByEmail = getUserByEmail;
        }

        public async Task<GetUserByEmailResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _getUserByEmail.GetUserByEmail(request.Email, cancellationToken) ?? throw new KeyNotFoundException($"User with Email {request.Email} not found.");
            return new GetUserByEmailResponse(user);
        }
    }
}