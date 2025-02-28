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
