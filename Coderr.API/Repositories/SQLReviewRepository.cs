using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Coderr.API.Repositories
{
    public class SQLReviewRepository : IReviewRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLReviewRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Review> CreateAsync(Review review)
        {
            await dbContext.AddAsync(review);
            await dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> DeleteAsync(Guid id)
        {
            var existingReview = await dbContext.Reviews.FirstOrDefaultAsync(x => x.id == id);
            
            if (existingReview == null)
            {
                return null;
            }

            dbContext.Reviews.Remove(existingReview);
            await dbContext.SaveChangesAsync();
            return existingReview;
        }

        public async Task<List<Review>> GetAllAsync(Guid businessUserId, string ordering)
        {
            var query = dbContext.Reviews
             .Where(r => r.BusinessUserId == businessUserId);

            if (!string.IsNullOrEmpty(ordering))
            {
                if (ordering.ToLower() == "rating")
                {
                    query = query.OrderByDescending(r => r.rating);
                }
                else if (ordering.ToLower() == "date")
                {
                    query = query.OrderByDescending(r => r.created_at);
                }
            }

            return await query.ToListAsync();

        }

        public async Task<Review> GetByIdAsync(Guid id)
        {
            return await dbContext.Reviews.FirstOrDefaultAsync(r => r.id == id);
        }

        public async Task<Review> UpdateAsync(Guid id, Review review)
        {
            var existingReview = await dbContext.Reviews.FirstOrDefaultAsync(x => x.id == id);
            
            if(existingReview == null)
            {
                return null;
            }

            existingReview.rating = review.rating;
            existingReview.description = review.description;

            await dbContext.SaveChangesAsync();
            return existingReview;
           
        }
    }
}
