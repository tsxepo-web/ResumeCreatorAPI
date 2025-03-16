using MongoDB.Driver;
using ResumeCreatorAPI.Features.User.UpdateUserTier;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure.Persistence.User
{
    public class UpdateUserTierRepository : IUpdateUserTierRepository
    {
        private readonly IMongoCollection<Domain.Users.User> _users;
        public UpdateUserTierRepository(MongodbContext context)
        {
            _users = context.Users;
        }

        public async Task<bool> UpdateUserTierAsync(string email, string newTier)
        {
            var filter = Builders<Domain.Users.User>.Filter.Eq(user => user.Email, email);
            var update = Builders<Domain.Users.User>.Update.Set(user => user.Tier, newTier);

            var result = await _users.UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}