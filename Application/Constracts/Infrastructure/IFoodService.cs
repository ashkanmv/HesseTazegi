using Application.DTOs;
using Domain.Entities;

namespace Application.Constracts.Infrastructure
{
    public interface IFoodService
    {
        Task<Food> Add(AddFoodRequestDto dto);
        Task<FoodResponseDto> GetById(long id, long userId);
        Task<IReadOnlyList<FoodResponseDto>> GetAll(long userId);
    }
}
