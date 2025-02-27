using Coderr.API.Data;

namespace Coderr.API.Repositories
{
    public class SQLReviewRepository : IReviewRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLReviewRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
