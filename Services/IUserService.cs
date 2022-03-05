using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgtApp.Models;
using System.Threading;
using UserMgtApp.Classes;

namespace UserMgtApp.Services
{
    public interface IUserService
    {
        Task<ApiResponse<List<User>>> GetAllUsers();
        Task<ApiResponse<User>> GetUserById(int? userId);
        Task<ApiResponse<int>> AddUser(User user);
        Task<ApiResponse<int>> DeleteUser(int? userId);
        Task<ApiResponse<int>> DeleteUsers(string userIds);
        Task<ApiResponse<int>> UpdateUser(User user);
        Task<bool> IsEmailExists(string email);
        Task<ApiResponse<List<Nationalities>>> GetAllNationalities();

    }
}
