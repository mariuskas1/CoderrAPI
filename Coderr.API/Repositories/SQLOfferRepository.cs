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


        public async Task<Offer> CreateAsync(Offer offer)
        {
           await dbContext.Offers.AddAsync(offer);
           await dbContext.SaveChangesAsync();
           return offer;
        }

        public Task<Offer?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Offer>> GetAllAsync()
        {
            return await dbContext.Offers
                .Include(o => o.details)
                .Include(o => o.user)
                .ToListAsync();
        }

        public async Task<Offer?> GetByIdAsync(Guid id)
        {
            return await dbContext.Offers
                .Include(o => o.details) 
                .Include(o => o.user)    
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public Task<Offer?> UpdateAsync(Guid id, Offer offer)
        {
            throw new NotImplementedException();
        }
    }
}
