using AutoMapper;
using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Coderr.API.Repositories
{
    public class SQLOfferRepository : IOfferRepository
    {
        private readonly CoderrDbContext dbContext;
        private readonly IMapper mapper;

        public SQLOfferRepository(CoderrDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
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

        public async Task<Offer?> UpdateAsync(Guid id, Offer offer)
        {
            var existingOffer = await dbContext.Offers
                .Include(o => o.details) 
                .FirstOrDefaultAsync(o => o.id == id);

            if (existingOffer == null)
            {
                return null;
            }

            mapper.Map(offer, existingOffer);
            existingOffer.updated_at = DateTime.UtcNow; 

            await dbContext.SaveChangesAsync();
            return existingOffer;
        }
    }
}
