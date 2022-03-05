using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgtApp.Models;
using System.Threading;
using UserMgtApp.Classes;

namespace UserMgtApp.Services
{
    public interface IUserTypeService
    {       
        Task<ApiResponse<List<UserType>>> GetAllUserType();
    }
}
