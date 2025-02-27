using Coderr.API.Data;

namespace Coderr.API.Repositories
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly CoderrDbContext dbContext;

        public SQLOrderRepository(CoderrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
