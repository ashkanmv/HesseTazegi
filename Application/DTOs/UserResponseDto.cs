using Domain.Entities;


namespace Application.DTOs
{
    public class UserResponseDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserAllergiesResponseDto> Allergies { get; set; }

        public static UserResponseDto MapFromModel(User entity)
        {
            return new UserResponseDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Allergies = entity.Allergies.Select(UserAllergiesResponseDto.MapFromModel).ToList()
            };
        }
    }

    public class UserAllergiesResponseDto
    {
        public long Id { get; set; }
        public string IngredientName { get; set; }

        public static UserAllergiesResponseDto MapFromModel(Allergy entity)
        {
            return new UserAllergiesResponseDto()
            {
                Id = entity.Id,
                IngredientName = entity.Ingredient.Name
            };
        }
    }
}
