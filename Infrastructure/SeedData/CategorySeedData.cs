using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFullAPI.Models.Entities.Concrete;

namespace RestFullAPI.Infrastructure.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "UFC Gloves", Description = "Best MMA boxing gloves here..!", Slug = "ufc-gloves" },
                new Category { Id = 2, Name = "Protected Equipment", Description = "Best MMA equipments here..!", Slug = "protected-equipment" },
                new Category { Id = 3, Name = "Hand Wraps", Description = "Best MMA bandages here..!", Slug = "hand-wraps" });
        }
    }
}
