using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgtApp.Classes;
using UserMgtApp.Models;

namespace UserMgtApp.Controllers
{
    public class NationalityController : Controller
    {
        private readonly NationalityApiConsumptionClass nationalityApiConsumptionClass;

        public NationalityController(NationalityApiConsumptionClass _nationalityApiConsumptionClass)
        {
            nationalityApiConsumptionClass = _nationalityApiConsumptionClass;
        }

        [HttpGet]
        public async Task<JsonResult> GetAllNationalities()
        {
            string msg = "";

            ApiResponse<List<Nationalities>> response = new ApiResponse<List<Nationalities>>();

            try
            {
                response = await nationalityApiConsumptionClass.GetAllNationalities();

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
