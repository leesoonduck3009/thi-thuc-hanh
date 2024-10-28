using AutoMapper;
using WebApiProject.Dtos.User;
using WebApiProject.Entities;

namespace WebApiProject.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<RegisterationRequestDto, User>();
        }
    }
}
