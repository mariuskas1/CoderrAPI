using System;
using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Coderr.API.Repositories
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLOrderRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Order> CreateAsync(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

        public Task<Order?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await dbContext.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await dbContext.Orders.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Order?> UpdateAsync(Guid id, Order order)
        {
            var existingOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.id == id);
            if (existingOrder == null)
            {
                return null;
            }
            existingOrder.status = order.status;
            await dbContext.SaveChangesAsync();
            return existingOrder;
        }
    }
}
