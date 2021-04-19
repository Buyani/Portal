using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public bool Blocked { get; set; }
        [PersonalData]
        public bool IsAdmin { get; set; }
    }
}
