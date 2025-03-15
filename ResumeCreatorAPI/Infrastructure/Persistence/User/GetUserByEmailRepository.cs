using MongoDB.Driver;
using ResumeCreatorAPI.Features.User.GetUserByEmail;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence.User
{
    public class GetUserByEmailRepository : IGetUserByEmailRepository
    {
        private readonly IMongoCollection<Domain.Users.User> _users;
        public GetUserByEmailRepository(MongodbContext context)
        {
            _users = context.Users;
        }
        public async Task<Domain.Users.User> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            return await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}