using Portal.Model.RolesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Model.UserModels.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; }
        public bool Blocked { get; set; }
        public string Email { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
