using Application.Constracts.Infrastructure;
using Application.Constracts.Persistance;
using Application.DTOs;
using Domain.Entities;

namespace Infrastructure.Services.Implementation
{
    public class FoodReplacementService : IFoodReplacementService
    {
        private readonly IFoodReplacementRepository _foodReplacementRepository;

        public FoodReplacementService(IFoodReplacementRepository foodReplacementRepository)
        {
            _foodReplacementRepository = foodReplacementRepository;
        }

        public async Task<FoodReplacement> Add(FoodReplacementRequestDto dto)
        {
            return await _foodReplacementRepository.AddAsync(FoodReplacementRequestDto.MapToModel(dto));
        }

        public async Task<IReadOnlyList<FoodReplacementResponseDto>> GetAll(long foodId)
        {
            var result = await _foodReplacementRepository.GetAsync(x => x.FoodId == foodId,
                includes: new()
                {
                    f => f.Food,
                    f => f.AlternativeFoodId
                });
            return result.Select(FoodReplacementResponseDto.MapFromModel).ToList();
        }

        public async Task<List<FoodReplacementResponseDto>> GetReplacement(long foodId)
        {
            var result = await _foodReplacementRepository.GetAsync(f => f.FoodId == foodId,
                includes: new()
                {
                    f => f.AlternativeFood,
                    f => f.Food
                });
            return result.Select(FoodReplacementResponseDto.MapFromModel).ToList();
        }
    }
}
