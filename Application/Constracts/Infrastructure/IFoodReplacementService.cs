using Application.DTOs;
using Domain.Entities;

namespace Application.Constracts.Infrastructure
{
    public interface IFoodReplacementService
    {
        Task<FoodReplacement> Add(FoodReplacementRequestDto dto);
        Task<IReadOnlyList<FoodReplacementResponseDto>> GetAll(long foodId);
        Task<List<FoodReplacementResponseDto>> GetReplacement(long foodId);
    }
}
