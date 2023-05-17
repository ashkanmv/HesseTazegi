using Application.Constracts.Infrastructure;
using Application.Constracts.Persistance;
using Application.DTOs;
using Domain.Entities;

namespace Infrastructure.Services.Implementation
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IUserService _userService;

        public FoodService(IFoodRepository foodRepository, IUserService userService)
        {
            _foodRepository = foodRepository;
            _userService = userService;
        }

        public async Task<Food> Add(AddFoodRequestDto dto)
        {
            //var entity = AddFoodRequestDto.MapToModel(dto);
            //var food = await _foodRepository.AddAsync(entity);
            //return food; 

            var food = new Food
            {
                Name = dto.Name
            };

            dto.FoodDetails.ForEach(d=> food.FoodDetails.Add(new FoodDetail()
            {
                IngredientId = d.IngredientId,
                Amount = d.Amount
            }));

            return await _foodRepository.AddAsync(food);
        }

        public async Task<FoodResponseDto> GetById(long id, long userId)
        {
            var food = await _foodRepository.GetByIdAsync(id);

            var user = await _userService.GetById(userId);
            var userAllergies = user.Allergies.Select(a => a.IngredientName).ToList();
            return FoodResponseDto.MapFromModel(food,userAllergies);
        }

        public async Task<IReadOnlyList<FoodResponseDto>> GetAll(long userId)
        {
            var foods = await _foodRepository.GetAllAsync();

            var user = await _userService.GetById(userId);
            var userAllergies = new List<string>();
            if(user != null)
                userAllergies = user.Allergies.Select(a => a.IngredientName).ToList();

            return foods.Select(f=>FoodResponseDto.MapFromModel(f,userAllergies)).ToList();
        }
    }
}
