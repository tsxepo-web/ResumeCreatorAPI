

using MediatR;

namespace ResumeCreatorAPI.Features.User.GetUserByUsername
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, GetUserByUsernameResponse>
    {
        private readonly IGetUserByUsernameRepository _getUserByUsernameRepository;
        public GetUserByUsernameHandler(IGetUserByUsernameRepository getUserByUsernameRepository)
        {
            _getUserByUsernameRepository = getUserByUsernameRepository;
        }
        public async Task<GetUserByUsernameResponse> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _getUserByUsernameRepository.GetUserByUsernameAsync(request.Username, cancellationToken) ?? throw new KeyNotFoundException($"User with Userename {request.Username} not found.");
            return new GetUserByUsernameResponse(user);
        }
    }
}