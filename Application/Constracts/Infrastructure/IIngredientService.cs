using Application.DTOs;
using Domain.Entities;

namespace Application.Constracts.Infrastructure
{
    public interface IIngredientService
    {
        Task<List<IngredientResponseDto>> AddRange(List<AddIngredientRequestDto> dto);
        Task<IngredientResponseDto> GetById(long id);
        Task<IReadOnlyList<IngredientResponseDto>> GetAll();
    }
}
