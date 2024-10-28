using AutoMapper;
using TestWebApplication.Repositories.Interface;
using WebApiProject.Dtos.User;
using WebApiProject.Entities;
using WebApiProject.Enums;
using WebApiProject.Services.Interface;

namespace WebApiProject.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IBaseRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(p => p.Username == loginRequestDto.UserName && p.Password == loginRequestDto.Password);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<string> RegisterAsync(RegisterationRequestDto request)
        {
            if (await _userRepository.GetFirstOrDefaultAsync(p => p.Username == request.UserName) != null)
            {
                throw new Exception("User already existed");
            }
            User user = _mapper.Map<User>(request);
            user.Role = UserRole.User.ToString();
            await _userRepository.UpdateAsync(user);
            return "success";
        }
        public async Task<UserDto> DeleteUserAsync(Guid userId)
        {
            User user = await _userRepository.GetFirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            await _userRepository.DeleteAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {

            var response = await _userRepository.GetAllAsync(p => true);
            return _mapper.Map<List<UserDto>>(response);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid userId)
        {
            var response = await _userRepository.GetFirstOrDefaultAsync(p => p.Id == userId);
            return _mapper.Map<UserDto>(response);
        }
        public async Task<UserDto> UpdateUserAsync(Guid userId, UserDto userDto)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(p => p.Id == userId);
            _mapper.Map(userDto, user);
            await _userRepository.UpdateAsync(user);
            return userDto;
        }
    }
}
