using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgtApp.Classes;
using UserMgtApp.Models;
using UserMgtApp.Services;
using Microsoft.EntityFrameworkCore;

namespace UserMgtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService userService;

        public UserApiController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody]User user)
        {
            string msg = "";           

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<int> { Success = false, Message = "Missing parameter in the request body!" });
                }

                var result = await userService.AddUser(user);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }                
            }           
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                return BadRequest(new ApiResponse<int> { Success = false, Message = "An error occured!" + msg });
            }
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int? userId)
        {
            string msg = "";

            try
            {
                if (userId == null)
                {
                    return BadRequest(new ApiResponse<int> { Success = false, Message = "User id is required!" });
                }

                var result = await userService.DeleteUser(userId);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                return BadRequest(new ApiResponse<int> { Success = false, Message = "An error occured!" });
            }
        }

        [HttpPost("DeleteUsers")]
        public async Task<IActionResult> DeleteUsers(string userIds)
        {
            string msg = "";

            try
            {               
                var result = await userService.DeleteUsers(userIds);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                return BadRequest(new ApiResponse<int> { Success = false, Message = "An error occured!" });
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            string msg = "";

            try
            {
                var result = await userService.GetAllUsers();

                return Ok(result);
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                return BadRequest(new ApiResponse<List<User>> { Success = false, Message = "An error occured!" });
            }
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int? userId)
        {
            string msg = "";

            try
            {
                if (userId == null)
                {
                    return BadRequest(new ApiResponse<User> { Success = false, Message = "User id is required!" });
                }

                var result = await userService.GetUserById(userId);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                return BadRequest(new ApiResponse<User> { Success = false, Message = "An error occured!" });
            }
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            string msg = "";

            try
            {
                if (user == null)
                {
                    return BadRequest(new ApiResponse<int> { Success = false, Message = "Missing parameter in the request body!" });
                }

                var result = await userService.UpdateUser(user);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                return BadRequest(new ApiResponse<int> { Success = false, Message = "An error occured!" + msg });
            }
        }


    }
}
