using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Coderr.API.Repositories
{
    public class SQLUserProfileRepository : IUserProfileRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLUserProfileRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserProfile> GetByIdAsync(Guid id)
        {
            return await dbContext.UserProfiles
            .FirstOrDefaultAsync(u => u.id == id);
        }

        public async Task<List<UserProfile>> GetProfilesByTypeAsync(UserProfile.UserType userType)
        {
            return await dbContext.UserProfiles
                .Where(u => u.type == userType)
                .ToListAsync();
        }
    }
}
