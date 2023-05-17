using Domain.Entities;

namespace Application.DTOs
{
    public class UpdateUserRequestDto : AddUserRequestDto
    {
        public long Id { get; set; }
    }
}
