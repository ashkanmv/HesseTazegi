using Domain.Entities;

namespace Application.DTOs
{
    public class AddUserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<long> Allergies { get; set; }

        public static User MapToModel(AddUserRequestDto dto)
        {
            var user = new User()
            {
                Allergies = new List<Allergy>(),
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            dto.Allergies.ForEach(a =>
            {
                user.Allergies.Add(new Allergy {IngredientId = a});
            });

            return user;
        }
    }
}
