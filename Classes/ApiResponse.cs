using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMgtApp.Classes
{
    public class ApiResponse<T> : ApiResponseProperties
    {
        //public bool Success { get; set; } = true;
        //public string Message { get; set; }
        public T Result { get; set; }
    }

    public class ApiResponseProperties
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
       
    }
}
