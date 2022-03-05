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
    public class UserService : IUserService
    {
        private readonly UserMgtDbContext db;

        public UserService(UserMgtDbContext _db)
        {
            db = _db;
        }

        public async Task<ApiResponse<int>> AddUser(User user)
        {
            ApiResponse<int> apiResponse = new ApiResponse<int>();

            //if email already exists, do not add user
            if(await IsEmailExists(user.Email))
            {
                apiResponse.Success = false;
                apiResponse.Message = "Email already exists. Choose another email.";               

                return apiResponse;
            }

            //add the new user
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            apiResponse.Result = user.UserId;

            return apiResponse;
        }

        public async Task<ApiResponse<int>> DeleteUser(int? userId)
        {
            ApiResponse<int> apiResponse = new ApiResponse<int>();

            var user = await GetUserById(userId);

            if (!user.Success)
            {
                apiResponse.Message = user.Message;
                apiResponse.Success = user.Success;

                return apiResponse;
            }

            //delete user
            db.Users.Remove(user.Result);
            await db.SaveChangesAsync();

            apiResponse.Result = 1;

            return apiResponse;
        }

        public async Task<ApiResponse<List<User>>> GetAllUsers()
        {
            ApiResponse<List<User>> apiResponse = new ApiResponse<List<User>>();

            var queryUsers = await db.Users.ToListAsync();

            apiResponse.Result = queryUsers;

            return apiResponse;
        }

        public async Task<ApiResponse<User>> GetUserById(int? userId)
        {
            ApiResponse<User> apiResponse = new ApiResponse<User>();

            if (userId == null)
            {
                apiResponse.Success = false;
                apiResponse.Message = "User id is required";

                return apiResponse;
            }

            var user = await db.Users.FindAsync(userId.Value);

            if (user == null)
            {
                apiResponse.Success = false;
                apiResponse.Message = "User not found";
            }
            else
            {
                apiResponse.Result = user;
            }

            return apiResponse;
        }

        public async Task<bool> IsEmailExists(string email)
        {
            return await db.Users.AnyAsync(m => m.Email.ToLower() == email.ToLower());
        }

        public async Task<ApiResponse<int>> UpdateUser(User user)
        {
            ApiResponse<int> apiResponse = new ApiResponse<int>();

            //check if user exists
            var userToUpdate = await GetUserById(user.UserId);

            if (!userToUpdate.Success)
            {
                apiResponse.Message = userToUpdate.Message;
                apiResponse.Success = userToUpdate.Success;

                return apiResponse;
            }

            //update the user
            //db.Entry<User>(user).State = EntityState.Modified;
            //await db.SaveChangesAsync();
            var queryUser = await db.Users.FindAsync(user.UserId);

            queryUser.DateOfBirth = user.DateOfBirth;
            queryUser.Email = user.Email;
            queryUser.FirstName = user.FirstName;
            queryUser.Gender = user.Gender;
            queryUser.LastName = user.LastName;
            queryUser.NationalityId = user.NationalityId;
            queryUser.PhoneNo = user.PhoneNo;
            queryUser.UserTypeId = user.UserTypeId;

            await db.SaveChangesAsync();

            apiResponse.Result = 1;

            return apiResponse;
        }

        public async Task<ApiResponse<int>> DeleteUsers(string userIds)
        {
            ApiResponse<int> apiResponse = new ApiResponse<int>();          

            if (string.IsNullOrEmpty(userIds))
            {
                apiResponse.Message = "User ids are required";
                apiResponse.Success = false;

                return apiResponse;
            }

            //split the user ids
            string[] userIdsInArray = userIds.Split(',');

            List<int> listUserIds = new List<int>();

            foreach (var item in userIdsInArray)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    int userId = 0;

                    if (int.TryParse(item.Trim(), out userId))
                    {
                        listUserIds.Add(userId);
                    }
                }
            }

            //search for all the users to delete
            var users = db.Users.Where(m => listUserIds.Contains(m.UserId));

            if (!users.Any())
            {
                apiResponse.Message = "Users not found";
                apiResponse.Success = false;

                return apiResponse;
            }

            //delete the users            
            db.Users.RemoveRange(users.ToList());
            await db.SaveChangesAsync();

            apiResponse.Result = 1;

            return apiResponse;
        }

        public async Task<ApiResponse<List<Nationalities>>> GetAllNationalities()
        {
            ApiResponse<List<Nationalities>> apiResponse = new ApiResponse<List<Nationalities>>();

            var queryNationalities = await db.Nationalities.ToListAsync();

            apiResponse.Result = queryNationalities;

            return apiResponse;
        }
    }
}
