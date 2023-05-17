using Application.Constracts.Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddFoodService();
            services.AddIngredientService();
            services.AddUserService();
            services.AddFoodReplacementService();
            services.AddAllergyServiceService();
            return services;
        }

        public static void AddFoodService(this IServiceCollection services)
        {
            services.AddScoped<IFoodService, FoodService>();
        }
        public static void AddIngredientService(this IServiceCollection services)
        {
            services.AddScoped<IIngredientService, IngredientService>();
        }
        public static void AddUserService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
        public static void AddFoodReplacementService(this IServiceCollection services)
        {
            services.AddScoped<IFoodReplacementService, FoodReplacementService>();
        }
        public static void AddAllergyServiceService(this IServiceCollection services)
        {
            services.AddScoped<IAllergyService, AllergyService>();
        }
    }
}
