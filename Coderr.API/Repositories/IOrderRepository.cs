using Coderr.API.Models.Domain;

namespace Coderr.API.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task<Order> CreateAsync(Order order);
        Task<Order?> UpdateAsync(Guid id, Order order);
        Task<Order?> DeleteAsync(Guid id);

        Task<int> GetOrderCountAsync(Guid businessUserId);
        Task<int> GetCompletedOrderCountAsync(Guid businessUserId);
    }
}
