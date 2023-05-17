using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public static class ContextConfigurations
    {
        public static void FoodReplacementConfiguration(this ModelBuilder builder)
        {
            builder.Entity<FoodReplacement>()
                .HasOne(e => e.Food)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<FoodReplacement>()
                .HasOne(e => e.AlternativeFood)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

        }

        public static void FoodDetailConfiguration(this ModelBuilder builder)
        {
            builder.Entity<FoodDetail>()
                .HasOne(e => e.Food)
                .WithMany(e => e.FoodDetails)
                .HasForeignKey(e => e.FoodId);
        }
    }
}
