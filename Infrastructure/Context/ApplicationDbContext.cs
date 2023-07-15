using Microsoft.EntityFrameworkCore;
using RestFullAPI.Infrastructure.SeedData;
using RestFullAPI.Models.Entities.Concrete;

namespace RestFullAPI.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategorySeedData());
            modelBuilder.ApplyConfiguration(new AppUserSeedData());
            base.OnModelCreating(modelBuilder);
        }
    }
}
