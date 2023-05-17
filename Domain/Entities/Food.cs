using Domain.Common;

namespace Domain.Entities
{
    public class Food : EntityBase
    {
        public Food()
        {
            FoodDetails = new HashSet<FoodDetail>();
        }
        public string Name { get; set; }
        public ICollection<FoodDetail> FoodDetails { get; set; }
    }
}
