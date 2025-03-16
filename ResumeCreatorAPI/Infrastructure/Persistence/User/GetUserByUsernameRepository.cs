using MongoDB.Driver;
using ResumeCreatorAPI.Features.User.GetUserByUsername;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence.User
{
    public class GetUserByUsernameRepository : IGetUserByUsernameRepository
    {
        private readonly IMongoCollection<Domain.Users.User> _users;

        public GetUserByUsernameRepository(MongodbContext context)
        {
            _users = context.Users;
        }

        public async Task<Domain.Users.User> GetUserByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
        }
    }
}