using Microsoft.EntityFrameworkCore;
using UserAPI.Entities;

namespace UserAPI.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(b => b.Name).HasColumnName("name");
            modelBuilder.Entity<User>().Property(b => b.Email).HasColumnName("email");
            modelBuilder.Entity<User>().Property(b => b.SubscriptionId).HasColumnName("subscriptionId");

            modelBuilder.Entity<Subscription>().ToTable("subscription");
            modelBuilder.Entity<Subscription>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<Subscription>().Property(b => b.Type).HasColumnName("type");
            modelBuilder.Entity<Subscription>().Property(b => b.StartDate).HasColumnName("startDate");
            modelBuilder.Entity<Subscription>().Property(b => b.EndDate).HasColumnName("endDate");
        }
    }
}
