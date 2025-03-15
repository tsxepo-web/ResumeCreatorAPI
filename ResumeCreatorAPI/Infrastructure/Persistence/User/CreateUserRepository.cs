using MongoDB.Driver;
using ResumeCreatorAPI.Domain.Users;
using ResumeCreatorAPI.Features.User.CreateUser;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence.User
{
    public class CreateUserRepository : ICreateUserRepository
    {
        private readonly IMongoCollection<Domain.Users.User> _users;
        public CreateUserRepository(MongodbContext context)
        {
            _users = context.Users;
        }

        public async Task CreateUserAsync(Domain.Users.User user, CancellationToken cancellationToken)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            await _users.InsertOneAsync(user);
        }
        
        public bool VerifyPassword(string storeHash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, storeHash);
        }
    }
}