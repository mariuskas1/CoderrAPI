using Coderr.API.Models.Domain;

namespace Coderr.API.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> GetByIdAsync(Guid id);
        Task<List<UserProfile>> GetProfilesByTypeAsync();
    }
}
