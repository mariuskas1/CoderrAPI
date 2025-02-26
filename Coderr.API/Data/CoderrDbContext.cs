using Coderr.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Coderr.API.Data
{
    public class CoderrDbContext : DbContext
    {
        public CoderrDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
