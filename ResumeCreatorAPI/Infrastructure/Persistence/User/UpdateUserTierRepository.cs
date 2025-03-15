using MongoDB.Driver;

namespace ResumeCreatorAPI.Infrastructure.Persistence.User
{
    public class UpdateUserTierRepository
    {
        private readonly IMongoCollection<Domain.Users.User> _users;
        public UpdateUserTierRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<Domain.Users.User>("Users");
        }

        public async Task UpdateUserTier(string userId, string newTier)
        {
            var update = Builders<Domain.Users.User>.Update.Set(u => u.Tier, newTier);
            await _users.UpdateOneAsync(u => u.Id == userId, update);
        }

         public async Task<bool> CanCreateResume(string userId)
        {
            var user = await _users.Find(u => u.Id == userId).FirstOrDefaultAsync();
            if (user == null) return false;

            if (user.Tier == "free")
            {
                var resumeCount = await CountUserResumes(userId);
                return resumeCount < 1;
            }
            else if (user.Tier == "paid")
            {
                var resumeCount = await CountUserResumes(userId);
                return resumeCount < 2;
            }

            return false;
        }

        private async Task<int> CountUserResumes(string userId)
        {
            // var resumeService = new ResumeService(/* inject database here */);
            // return await resumeService.CountResumesByUserId(userId); 
            return 1;
        }
    }
}