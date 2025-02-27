using Coderr.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Coderr.API.Data
{
    public class CoderrDbContext : DbContext
    {
        public CoderrDbContext(DbContextOptions<CoderrDbContext> dbContextOptions) : base(dbContextOptions) 
        {

        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferDetails> OfferDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasOne(o => o.CustomerUser)
                .WithMany()
                .HasForeignKey(o => o.CustomerUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Order>()
                .HasOne(o => o.BusinessUser)
                .WithMany()
                .HasForeignKey(o => o.BusinessUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Review>()
            .HasOne(r => r.BusinessUser)
            .WithMany()
            .HasForeignKey(r => r.BusinessUserId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
