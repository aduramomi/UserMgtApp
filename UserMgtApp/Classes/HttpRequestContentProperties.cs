using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMgtApp.Classes
{
    public class HttpRequestContentProperties
    {       
        public int UserId { get; set; }        
        public string FirstName { get; set; }    
        public string LastName { get; set; }      
        public string Email { get; set; }       
        public string PhoneNo { get; set; }       
        public string Gender { get; set; }       
        public DateTime DateOfBirth { get; set; }       
        public int NationalityId { get; set; }
        public int UserTypeId { get; set; }
    }
}
