using Coderr.API.Data;

namespace Coderr.API.Repositories
{
    public class SQLOfferDetailsRepository : IOfferDetailsRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLOfferDetailsRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
