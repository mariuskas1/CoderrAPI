using System.Reflection.Emit;
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

            foreach (var relationship in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<Order>()
                .HasOne(o => o.customer_user)
                .WithMany()
                .HasForeignKey(o => o.CustomerUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Order>()
                .HasOne(o => o.business_user)
                .WithMany()
                .HasForeignKey(o => o.BusinessUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Review>()
            .HasOne(r => r.business_user)
            .WithMany()
            .HasForeignKey(r => r.BusinessUserId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Review>()
                .HasOne(r => r.reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
