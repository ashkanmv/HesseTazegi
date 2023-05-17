using Application.Constracts.Persistance;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Implementation
{
    public class AllergyRepository : RepositoryBase<Allergy> , IAllergyRepository
    {
        public AllergyRepository(ContentContext dbContext) : base(dbContext) { }
    }
}
