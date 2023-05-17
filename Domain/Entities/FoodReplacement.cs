using Domain.Common;

namespace Domain.Entities
{
    public class FoodReplacement : EntityBase
    {
        public long FoodId { get; set; }
        public Food Food { get; set; }

        public long AlternativeFoodId { get; set; }
        public Food AlternativeFood { get; set; }
    }
}
