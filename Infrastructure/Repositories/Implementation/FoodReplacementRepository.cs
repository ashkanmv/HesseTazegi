using Application.Constracts.Persistance;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Implementation
{
    public class FoodReplacementRepository : RepositoryBase<FoodReplacement>, IFoodReplacementRepository
    {
        public FoodReplacementRepository(ContentContext dbContext) : base(dbContext) { }
    }
}
