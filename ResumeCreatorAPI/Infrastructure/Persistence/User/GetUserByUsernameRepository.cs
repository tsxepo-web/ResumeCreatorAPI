using MongoDB.Driver;

namespace ResumeCreatorAPI.Infrastructure.Persistence.User
{
    public class GetUserByUsernameRepository
    {
        private readonly IMongoCollection<Domain.Users.User> _users;

        public GetUserByUsernameRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<Domain.Users.User>("Users");
        }

        public async Task<Domain.Users.User> GetUserByUsername(string username)
        {
            return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
        }
    }
}