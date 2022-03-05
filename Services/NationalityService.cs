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
    public class NationalityService : INationalityService
    {
        private readonly UserMgtDbContext db;

        public NationalityService(UserMgtDbContext _db)
        {
            db = _db;
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
