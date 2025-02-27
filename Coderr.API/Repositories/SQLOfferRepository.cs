using Coderr.API.Data;
using Coderr.API.Models.Domain;

namespace Coderr.API.Repositories
{
    public class SQLOfferRepository : IOfferRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLOfferRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Offer> CreateAsync(Offer offer)
        {
            throw new NotImplementedException();
        }

        public Task<Offer?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Offer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Offer?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Offer?> UpdateAsync(Guid id, Offer offer)
        {
            throw new NotImplementedException();
        }
    }
}
