using Domain.Entities;

namespace Application.DTOs
{
    public class FoodReplacementRequestDto
    {
        public long FoodId { get; set; }
        public long ReplacementId { get; set; }

        public static FoodReplacement MapToModel(FoodReplacementRequestDto dto)
        {
            return new FoodReplacement
            {
                FoodId = dto.FoodId,
                AlternativeFoodId = dto.ReplacementId
            };
        }
    }
}
