using UserService.Dtos.User;
using UserService.Models;

namespace UserService.Services
{
    public interface IUserDataService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updateUser);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
    }
}
