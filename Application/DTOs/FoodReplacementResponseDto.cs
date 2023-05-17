using Domain.Entities;

namespace Application.DTOs
{
    public class FoodReplacementResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static FoodReplacementResponseDto MapFromModel(FoodReplacement entity)
        {
            return new FoodReplacementResponseDto()
            {
                Id = entity.AlternativeFoodId,
                Name = entity.AlternativeFood.Name
            };
        }
    }
}
