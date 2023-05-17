using Application.Constracts.Persistance;
using Infrastructure.Repositories.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddBaseRepository();
            services.AddFoodRepository();
            services.AddIngredientRepository();
            services.AddUserRepository();
            services.AddFoodReplacementRepository();
            services.AddAllergyRepositoryRepository();
            return services;
        }

        public static void AddBaseRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(RepositoryBase<>));
        }
        public static void AddFoodRepository(this IServiceCollection services)
        {
            services.AddScoped<IFoodRepository, FoodRepository>();
        }
        public static void AddIngredientRepository(this IServiceCollection services)
        {
            services.AddScoped<IIngredientRepository, IngredientRepository>();
        }
        public static void AddUserRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
        public static void AddFoodReplacementRepository(this IServiceCollection services)
        {
            services.AddScoped<IFoodReplacementRepository, FoodReplacementRepository>();
        }
        public static void AddAllergyRepositoryRepository(this IServiceCollection services)
        {
            services.AddScoped<IAllergyRepository, AllergyRepository>();
        }
    }
}
