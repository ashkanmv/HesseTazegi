using Application.Constracts.Infrastructure;
using Application.Constracts.Persistance;
using Application.DTOs;
using Domain.Entities;

namespace Infrastructure.Services.Implementation
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository foodRepository)
        {
            _ingredientRepository = foodRepository;
        }

        public async Task<List<IngredientResponseDto>> AddRange(List<AddIngredientRequestDto> dto)
        {
            var entities = dto.Select(AddIngredientRequestDto.MapToModel).ToList();
            var ingredients = await _ingredientRepository.AddRangeAsync(entities);
            return ingredients.Select(IngredientResponseDto.MapFromModel).ToList();
        }

        public async Task<IngredientResponseDto> GetById(long id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);
            return IngredientResponseDto.MapFromModel(ingredient);
        }

        public async Task<IReadOnlyList<IngredientResponseDto>> GetAll()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            return ingredients.Select(IngredientResponseDto.MapFromModel).ToList();
        }
    }
}
