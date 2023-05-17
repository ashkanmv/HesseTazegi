using Domain.Entities;

namespace Application.Constracts.Infrastructure
{
    public interface IAllergyService
    {
        Task<IReadOnlyList<Allergy>> AddRange(List<Allergy> entities);
        Task<IReadOnlyList<Allergy>> DeleteRange(List<Allergy> entities);
    }
}
