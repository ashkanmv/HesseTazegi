using Domain.Common;

namespace Domain.Entities
{
    public class Allergy : EntityBase
    {
        public User User { get; set; }
        public long UserId { get; set; }
        public Ingredient Ingredient { get; set; }
        public long IngredientId { get; set; }
    }
}
