
using MediatR;

namespace ResumeCreatorAPI.Features.User.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Domain.Users.User>
    {
        private readonly ICreateUserRepository _createUserRepository;
        public CreateUserHandler(ICreateUserRepository createUserRepository)
        {
            _createUserRepository = createUserRepository;
        }

        public async Task<Domain.Users.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // var existingUserByEmail = await _userService.GetUserByEmail(request.Email);
            // var existingUserByUsername = await _userService.GetUserByUsername(request.Username);
            // if (existingUserByEmail != null || existingUserByUsername != null)
            // {
            //     throw new Exception("Username or Email already exists.");
            // }
            var user = new Domain.Users.User
            (
                request.UserName,
                request.Email,
                BCrypt.Net.BCrypt.HashPassword(request.Password),
                request.Tier
            );
            await _createUserRepository.CreateUserAsync(user, cancellationToken);
            return user;

        }
    
    }
}