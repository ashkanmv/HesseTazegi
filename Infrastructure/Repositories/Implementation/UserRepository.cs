using Application.Constracts.Persistance;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementation
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        public UserRepository(ContentContext dbContext) : base(dbContext) { }
        public async Task<User> GetByIdAsync(long id)
        {
            return await _dbContext.Users.Include(u => u.Allergies)
                .ThenInclude(u => u.Ingredient)
                .FirstAsync(u => u.Id == id);
        }

        public new async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.Include(u => u.Allergies).ThenInclude(u=>u.Ingredient).ToListAsync();
        }
    }
}
