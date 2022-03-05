using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgtApp.Services;
using UserMgtApp.Models;
using Microsoft.EntityFrameworkCore;
using UserMgtApp.Classes;

namespace UserMgtApp.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly UserMgtDbContext db;

        public UserTypeService(UserMgtDbContext _db)
        {
            db = _db;
        }        

        public async Task<ApiResponse<List<UserType>>> GetAllUserType()
        {
            ApiResponse<List<UserType>> apiResponse = new ApiResponse<List<UserType>>();

            var queryUserType = await db.UserTypes.ToListAsync();

            apiResponse.Result = queryUserType;

            return apiResponse;
        }

        
    }
}
