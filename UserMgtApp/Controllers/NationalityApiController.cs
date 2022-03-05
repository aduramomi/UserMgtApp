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
    public class NationalityApiController : ControllerBase
    {
        private readonly INationalityService nationalityService;

        public NationalityApiController(INationalityService _nationalityService)
        {
            nationalityService = _nationalityService;
        }

        [HttpGet("GetAllNationalities")]
        public async Task<IActionResult> GetAllNationalities()
        {
            string msg = "";

            try
            {
                var result = await nationalityService.GetAllNationalities();

                return Ok(result);
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }

                return BadRequest(new ApiResponse<List<Nationalities>> { Success = false, Message = "An error occured!" });
            }
        }


    }
}
