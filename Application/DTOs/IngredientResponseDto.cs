using Domain.Entities;

namespace Application.DTOs
{
    public class IngredientResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public static IngredientResponseDto MapFromModel(Ingredient entity)
        {
            return new IngredientResponseDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
