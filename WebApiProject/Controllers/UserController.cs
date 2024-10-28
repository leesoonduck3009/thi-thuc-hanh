using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Dtos;
using WebApiProject.Dtos.User;
using WebApiProject.Services.Interface;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterationRequestDto request)
        {
            return Ok(ApiResult<string>.Success(await _userService.RegisterAsync(request)));
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto request)
        {
            return Ok(ApiResult<UserDto>.Success(await _userService.LoginAsync(request)));
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return Ok(ApiResult<List<UserDto>>.Success(await _userService.GetAllUsersAsync()));
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid userId)
        {
            return Ok(ApiResult<UserDto>.Success(await _userService.GetUserByIdAsync(userId)));
        }
        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUserAsync(Guid userId, UserDto userDto)
        {
            return Ok(ApiResult<UserDto>.Success(await _userService.UpdateUserAsync(userId, userDto)));
        }
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUserAsync(Guid userId)
        {
            return Ok(ApiResult<UserDto>.Success(await _userService.DeleteUserAsync(userId)));
        }
    }
}
