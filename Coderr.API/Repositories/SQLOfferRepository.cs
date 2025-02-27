using Coderr.API.Data;

namespace Coderr.API.Repositories
{
    public class SQLOfferRepository : IOfferRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLOfferRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
