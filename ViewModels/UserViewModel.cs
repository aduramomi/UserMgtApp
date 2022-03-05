using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgtApp.Classes;

namespace UserMgtApp.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityId { get; set; }
    }

    public class ListUserViewModel : ApiResponseProperties
    {
        public List<UserViewModel> Users { get; set; }
    }
}
