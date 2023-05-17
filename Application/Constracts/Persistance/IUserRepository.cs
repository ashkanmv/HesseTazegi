using Domain.Entities;

namespace Application.Constracts.Persistance
{
    public interface IUserRepository : IGenericRepository<User>
    {
        new Task<User> GetByIdAsync(long id);
        new Task<List<User>> GetAllAsync();
    }
}
