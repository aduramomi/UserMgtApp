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
    public class UserTypeApiController : ControllerBase
    {       
        private readonly IUserTypeService userTypeService;

        public UserTypeApiController(IUserTypeService _userTypeService)
        {
            userTypeService = _userTypeService;
        }

        [HttpGet("GetAllUserType")]
        public async Task<IActionResult> GetAllUserType()
        {
            string msg = "";

            try
            {
                var result = await userTypeService.GetAllUserType();

                return Ok(result);
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                return BadRequest(new ApiResponse<List<UserType>> { Success = false, Message = "An error occured!" });
            }
        }


    }
}
