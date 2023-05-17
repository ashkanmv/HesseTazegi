using Domain.Entities;

namespace Application.DTOs
{
    public class FoodResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool UserHasAllergy { get; set; }
        public List<FoodDetailResponseDto> FoodDetails { get; set; } = new();

        public static FoodResponseDto MapFromModel(Food entity, List<string> userAllergies)
        {
            var result = new FoodResponseDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                FoodDetails = entity.FoodDetails.Select(FoodDetailResponseDto.MapFromModel).ToList(),
            };
            result.UserHasAllergy = result.FoodDetails.Any(d => userAllergies.Contains(d.IngridiantName));
            return result;
        }
    }

    public class FoodDetailResponseDto
    {
        public long Id { get; set; }
        public string IngridiantName { get; set; }
        public int Amount { get; set; }

        public static FoodDetailResponseDto MapFromModel(FoodDetail entity)
        {
            return new FoodDetailResponseDto()
            {
                Id = entity.Id,
                Amount = entity.Amount,
                IngridiantName = entity.Ingredient.Name,
            };
        }
    }
}
