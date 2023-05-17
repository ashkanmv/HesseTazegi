using Application.Constracts.Persistance;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Implementation
{
    public class IngredientRepository : RepositoryBase<Ingredient> , IIngredientRepository
    {
        public IngredientRepository(ContentContext dbContext) : base(dbContext) { }
    }
}
