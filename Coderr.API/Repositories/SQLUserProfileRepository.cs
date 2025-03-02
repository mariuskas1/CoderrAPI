using Coderr.API.Data;
using Coderr.API.Models.Domain;

namespace Coderr.API.Repositories
{
    public class SQLUserProfileRepository : IUserProfileRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLUserProfileRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<UserProfile> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserProfile>> GetProfilesByTypeAsync(UserProfile.UserType userType)
        {
            throw new NotImplementedException();
        }
    }
}
