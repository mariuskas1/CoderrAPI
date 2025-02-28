using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Coderr.API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Coderr.API.Repositories
{
    public class SQLBaseInfoRepository : IBaseInfoRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLBaseInfoRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BaseInfoResponseDTO> GetBaseInfoAsync()
        {
            var reviewCount = await dbContext.Reviews.CountAsync();
            var averageRating = await dbContext.Reviews.AnyAsync() ? await dbContext.Reviews.AverageAsync(r => r.rating) : 0;
            var businessProfileCount = await dbContext.UserProfiles.CountAsync(u => u.type == UserProfile.UserType.Business);
            var offerCount = await dbContext.Offers.CountAsync();

            return new BaseInfoResponseDTO
            {
                review_count = reviewCount,
                average_rating = averageRating,
                business_profile_count = businessProfileCount,
                offer_count = offerCount
            };
        }
    }
}
