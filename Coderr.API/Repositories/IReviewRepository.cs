using Coderr.API.Models.Domain;

namespace Coderr.API.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllAsync(Guid businessUserId, string ordering);
        Task<Review> GetByIdAsync(Guid id);
        Task<Review> CreateAsync(Review review);
        Task<Review> UpdateAsync(Guid id, Review review);
        Task<Review> DeleteAsync(Guid id);
    }
}
