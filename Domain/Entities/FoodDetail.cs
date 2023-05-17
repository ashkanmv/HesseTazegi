using Domain.Common;

namespace Domain.Entities
{
    public class FoodDetail : EntityBase
    {
        public Food Food { get; set; }
        public long FoodId { get; set; }
        public Ingredient Ingredient { get; set; }
        public long IngredientId { get; set; }
        public int Amount { get; set; }
    }
}
