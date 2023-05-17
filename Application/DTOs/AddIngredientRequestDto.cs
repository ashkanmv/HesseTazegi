using Domain.Entities;

namespace Application.DTOs
{
    public class AddIngredientRequestDto
    {
        public string Name { get; set; }

        public static Ingredient MapToModel(AddIngredientRequestDto dto)
        {
            return new Ingredient()
            {
                Name = dto.Name
            };
        }
    }
}
