using Coderr.API.Data;

namespace Coderr.API.Repositories
{
    public class SQLUserProfileRepository : IUserProfileRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLUserProfileRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
