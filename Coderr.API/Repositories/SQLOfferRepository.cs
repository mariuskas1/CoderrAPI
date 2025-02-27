using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Offer>> GetAllAsync()
        {
            return await dbContext.Offers.ToListAsync();
        }

        public async Task<Offer?> GetByIdAsync(Guid id)
        {
            return await dbContext.Offers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Offer?> UpdateAsync(Guid id, Offer offer)
        {
            throw new NotImplementedException();
        }
    }
}
