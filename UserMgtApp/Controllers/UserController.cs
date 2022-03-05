using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UserMgtApp.Classes;
using UserMgtApp.Models;
using UserMgtApp.ViewModels;

namespace UserMgtApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserApiConsumptionClass userApiConsumptionClass;

        public UserController(UserApiConsumptionClass _userApiConsumptionClass)
        {
            userApiConsumptionClass = _userApiConsumptionClass;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddUser(string dateOfBirth, string email, string firstName, string gender, string lastName, int nationalityId, string phoneNo, int userTypeId)
        {
            string msg = "";

            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                Models.User user = new User
                {
                    DateOfBirth = DateTime.Parse(dateOfBirth),
                    Email = email,
                    FirstName = firstName,
                    Gender = gender,
                    LastName = lastName,
                    NationalityId = nationalityId,
                    PhoneNo = phoneNo,
                    UserTypeId = userTypeId
                };

                response = await userApiConsumptionClass.AddUser(user);

                return Json(response);
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                response.Message = "An error occured!";
                response.Success = false;

                //log error

                return Json(response);
            }
        }

        [HttpPost]
        public async Task<JsonResult> UpdateUser(int userId, string dateOfBirth, string email, string firstName, string gender, string lastName, int nationalityId, string phoneNo, int userTypeId)
        {
            string msg = "";

            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                Models.User user = new User
                {
                    UserId = userId,
                    DateOfBirth = DateTime.Parse(dateOfBirth),
                    Email = email,
                    FirstName = firstName,
                    Gender = gender,
                    LastName = lastName,
                    NationalityId = nationalityId,
                    PhoneNo = phoneNo,
                    UserTypeId = userTypeId
                };

                response = await userApiConsumptionClass.UpdateUser(user);

                return Json(response);
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                response.Message = "An error occured!";
                response.Success = false;

                //log error

                return Json(response);
            }
        }

        [HttpPost]
        public async Task<JsonResult> DeleteUser(int userId)
        {
            string msg = "";

            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                response = await userApiConsumptionClass.DeleteUser(userId);

                return Json(response);
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                response.Message = "An error occured!";
                response.Success = false;

                //log error

                return Json(response);
            }
        }

        [HttpPost]
        public async Task<JsonResult> DeleteUsers(string userIds)
        {
            string msg = "";

            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                response = await userApiConsumptionClass.DeleteUsers(userIds);

                return Json(response);
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                response.Message = "An error occured!";
                response.Success = false;

                //log error

                return Json(response);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetAllUsers()
        {
            string msg = "";

            ApiResponse<List<User>> response = new ApiResponse<List<User>>();

            try
            {
                response = await userApiConsumptionClass.GetAllUsers();

                return Json(response);
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                response.Message = "An error occured!";
                response.Success = false;

                //log error

                return Json(response);
            }
        }       

        [HttpGet]
        public async Task<JsonResult> GetUserById(int userId)
        {
            string msg = "";

            ApiResponse<User> response = new ApiResponse<User>();

            try
            {
                response = await userApiConsumptionClass.GetUserById(userId);

                return Json(response);
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                response.Message = "An error occured!";
                response.Success = false;

                //log error

                return Json(response);
            }
        }
    }
}
