using Coderr.API.Models.Domain;

namespace Coderr.API.Repositories
{
    public interface IOfferRepository
    {
        Task<List<Offer>> GetAllAsync();
        Task<Offer?> GetByIdAsync(Guid id);
        Task<Offer> CreateAsync(Offer offer);
        Task<Offer?> UpdateAsync(Guid id, Offer offer);
        Task<Offer?> DeleteAsync(Guid id);

    }
}
