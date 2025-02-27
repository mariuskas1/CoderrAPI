using Coderr.API.Data;
using Coderr.API.Models.Domain;

namespace Coderr.API.Repositories
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLOrderRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Order> CreateAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> UpdateAsync(Guid id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
