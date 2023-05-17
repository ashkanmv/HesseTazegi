using Application.Constracts.Infrastructure;
using Application.Constracts.Persistance;
using Domain.Entities;

namespace Infrastructure.Services.Implementation
{
    public class AllergyService : IAllergyService
    {
        private readonly IAllergyRepository _allergyRepository;

        public AllergyService(IAllergyRepository allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        public async Task<IReadOnlyList<Allergy>> AddRange(List<Allergy> entities)
        {
            return await _allergyRepository.AddRangeAsync(entities);
        }

        public Task<IReadOnlyList<Allergy>> DeleteRange(List<Allergy> entities)
        {
            return _allergyRepository.DeleteRangeAsync(entities);
        }
    }
}
