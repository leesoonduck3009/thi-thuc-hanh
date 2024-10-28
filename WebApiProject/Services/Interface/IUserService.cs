using WebApiProject.Dtos.User;

namespace WebApiProject.Services.Interface
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterationRequestDto request);
        Task<UserDto> LoginAsync(LoginRequestDto loginRequestDto);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid userId);
        Task<UserDto> UpdateUserAsync(Guid userId, UserDto user);
        Task<UserDto> DeleteUserAsync(Guid userId);
    }
}
