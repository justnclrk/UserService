using AutoMapper;
using UserService.Dtos.User;
using UserService.Models;

namespace UserService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<User, UpdateUserDto>();
        }
    }
}
