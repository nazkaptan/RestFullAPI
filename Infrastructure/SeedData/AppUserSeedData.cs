using RestFullAPI.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestFullAPI.Infrastructure.SeedData
{
    public class AppUserSeedData : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                new AppUser { Id = 1, UserName = "beast", Password = "123" },
                new AppUser { Id = 2, UserName = "savage", Password = "123" },
                new AppUser { Id = 3, UserName = "raider", Password = "123" });
        }
    }
}
