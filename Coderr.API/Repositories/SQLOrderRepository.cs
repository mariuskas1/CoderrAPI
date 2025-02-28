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

        public async Task<Order?> DeleteAsync(Guid id)
        {
            var existingOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.id == id);

            if (existingOrder == null)
            {
                return null;
            }

            dbContext.Orders.Remove(existingOrder);
            await dbContext.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await dbContext.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await dbContext.Orders.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<int> GetCompletedOrderCountAsync(Guid businessUserId)
        {
            return await dbContext.Orders
                .Where(o => o.BusinessUserId == businessUserId && o.status == "completed")
                .CountAsync();
        }

        public async Task<int> GetOrderCountAsync(Guid businessUserId)
        {
            return await dbContext.Orders
                .Where(o => o.BusinessUserId == businessUserId)
                .CountAsync();
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
