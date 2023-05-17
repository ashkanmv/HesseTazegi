using Domain.Entities;

namespace Application.Constracts.Persistance
{
    public interface IFoodRepository : IGenericRepository<Food>
    {
        Task<Food> GetByIdAsync(int id);
        new Task<List<Food>> GetAllAsync();
    }
}
