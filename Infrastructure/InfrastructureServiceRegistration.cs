using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddServices();
            services.AddRepositories();

            return services;
        }
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContentContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        public static async Task SeedDatabase(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetService<ContentContext>();
            if(context == null || context.Foods.Any()) return;

            var ingredient = GetPreconfiguredIngredients();
            var foods = GetPreconfiguredFoods(ingredient);
            await context.Foods.AddRangeAsync(foods);

            await context.SaveChangesAsync();
        }


        private static IEnumerable<Ingredient> GetPreconfiguredIngredients()
        {
            return new List<Ingredient>()
            {
                new()
                {
                    Name = "بادمجان"
                },
                new()
                {
                    Name = "گوشت چرخ کرده"
                },
                new()
                {
                    Name = "پاستا"
                },
                new()
                {
                    Name = "نمک"
                },
                new()
                {
                    Name = "فلفل"
                }
            };
        }
        private static IEnumerable<Food> GetPreconfiguredFoods(IEnumerable<Ingredient> ingredients)
        {
            return new List<Food>()
            {
                new()
                {
                    FoodDetails = new List<FoodDetail>(),
                    Name = "میرزا قاسمی"
                },
                new()
                {
                    FoodDetails = new List<FoodDetail>(),
                    Name = "ماکارونی"
                },
                new()
                {
                    FoodDetails = new List<FoodDetail>(),
                    Name = "کشک بادمجان"
                }
            };
        }
    }
}
