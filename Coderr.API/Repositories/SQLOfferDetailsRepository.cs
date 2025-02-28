using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Coderr.API.Repositories
{
    public class SQLOfferDetailsRepository : IOfferDetailsRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLOfferDetailsRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<OfferDetails?> GetByIdAsync(Guid id)
        {
            return await dbContext.OfferDetails.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
