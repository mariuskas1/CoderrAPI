using Coderr.API.Data;
using Coderr.API.Models.Domain;

namespace Coderr.API.Repositories
{
    public class SQLOfferDetailsRepository : IOfferDetailsRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLOfferDetailsRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<OfferDetails?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
