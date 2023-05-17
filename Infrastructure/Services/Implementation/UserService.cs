using Application.Constracts.Infrastructure;
using Application.Constracts.Persistance;
using Application.DTOs;
using Domain.Entities;

namespace Infrastructure.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAllergyService _allergyService;

        public UserService(IUserRepository userRepository, IAllergyService allergyService)
        {
            _userRepository = userRepository;
            _allergyService = allergyService;
        }

        public async Task<UserResponseDto?> GetById(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return user == null ? null : UserResponseDto.MapFromModel(user);
        }

        public async Task<List<UserResponseDto>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(UserResponseDto.MapFromModel).ToList();
        }

        public async Task<User> Add(AddUserRequestDto reqDto)
        {
            var user = AddUserRequestDto.MapToModel(reqDto);
            return await _userRepository.AddAsync(user);
        }

        public async Task Update(UpdateUserRequestDto reqDto)
        {
            var user = await _userRepository.GetByIdAsync(reqDto.Id);

            if (reqDto.Allergies.Count > 0)
            {
                if (user.Allergies.Any()) await _allergyService.DeleteRange(user.Allergies.ToList());

                reqDto.Allergies.ForEach(a=> user.Allergies.Add(new Allergy()
                {
                    IngredientId = a,
                    UserId = user.Id
                }));
            }

            user.FirstName = reqDto.FirstName;
            user.LastName = reqDto.LastName;

            await _userRepository.UpdateAsync(user);
        }
    }
}
