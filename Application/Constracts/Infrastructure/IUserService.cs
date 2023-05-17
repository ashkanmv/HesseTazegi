using Application.DTOs;
using Domain.Entities;

namespace Application.Constracts.Infrastructure
{
    public interface IUserService
    {
        Task<UserResponseDto?> GetById(long id);
        Task<List<UserResponseDto>> GetAll();
        Task<User> Add(AddUserRequestDto reqDto);
        Task Update(UpdateUserRequestDto reqDto);
    }
}
