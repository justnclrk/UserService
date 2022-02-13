using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UserService.Data;
using UserService.Dtos.User;
using UserService.Models;

namespace UserService.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserDataService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string GetUserRole() => _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Role);

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var dbUsers = GetUserRole().Equals("Admin") ? await _context.Users!.ToListAsync() : await _context.Users!.Where(user => user.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = dbUsers.Select(user => _mapper.Map<GetUserDto>(user)).ToList();
            return serviceResponse;
        }

        public Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updateUser)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
