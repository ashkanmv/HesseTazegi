using Domain.Entities;

namespace Application.DTOs
{
    public class AddFoodRequestDto
    {
        public string Name { get; set; }
        public List<AddFoodDetailRequestDto> FoodDetails { get; set; }

        public static Food MapToModel(AddFoodRequestDto dto)
        {
            var food = new Food()
            {
                Name = dto.Name,
                FoodDetails = new List<FoodDetail>()
            };

            dto.FoodDetails.ForEach(d=> food.FoodDetails.Add(new FoodDetail()
            {
                IngredientId = d.IngredientId,
                Amount = d.Amount
            }));

            return food;
        }
    }

    public class AddFoodDetailRequestDto
    {
        public long IngredientId { get; set; }
        public int Amount { get; set; }
    }
}
