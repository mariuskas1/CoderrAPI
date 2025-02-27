using Coderr.API.Models.Domain;

namespace Coderr.API.Repositories
{
    public interface IOfferDetailsRepository
    {
        Task<OfferDetails?> GetByIdAsync(Guid id);
    }
}
