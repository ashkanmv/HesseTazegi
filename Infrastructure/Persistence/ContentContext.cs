using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ContentContext : DbContext
    {
        public ContentContext() { }

        public ContentContext(DbContextOptions<ContentContext> options)
            : base(options) { }

        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodDetail> FoodDetails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FoodReplacement> FoodReplacements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.FoodDetailConfiguration();
            modelBuilder.FoodReplacementConfiguration();
            base.OnModelCreating(modelBuilder);

        }
    }
}
