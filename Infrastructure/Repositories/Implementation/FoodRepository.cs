using Application.Constracts.Persistance;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementation
{
    public class FoodRepository : RepositoryBase<Food>, IFoodRepository
    {
        public FoodRepository(ContentContext dbContext) : base(dbContext) { }

        public async Task<Food> GetByIdAsync(int id)
        {
            return await _dbContext.Foods.Include(f => f.FoodDetails)
                .ThenInclude(f => f.Ingredient)
                .FirstAsync(f => f.Id == id);
        }

        public new async Task<List<Food>> GetAllAsync()
        {
            return await _dbContext.Foods.Include(f => f.FoodDetails)
                .ThenInclude(f => f.Ingredient).ToListAsync();
        }
    }
}
