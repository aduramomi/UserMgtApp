using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgtApp.Classes;
using UserMgtApp.Models;

namespace UserMgtApp.Controllers
{
    public class UserTypeController : Controller
    {       
        private readonly UserTypeApiConsumptionClass userTypeApiConsumptionClass;

        public UserTypeController(UserTypeApiConsumptionClass _userTypeApiConsumptionClass)
        {
            userTypeApiConsumptionClass = _userTypeApiConsumptionClass;
        }

        [HttpGet]
        public async Task<JsonResult> GetAllUserType()
        {
            string msg = "";

            ApiResponse<List<UserType>> response = new ApiResponse<List<UserType>>();

            try
            {
                response = await userTypeApiConsumptionClass.GetAllUserType();

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
