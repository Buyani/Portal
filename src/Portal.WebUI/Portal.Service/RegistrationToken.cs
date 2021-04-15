using Portal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Service
{
    public class RegistrationToken
    {
        public bool Results { get; set; }
        public string EmailConfimationToken { get; set; }
        public ApplicationUser User { get; set; }
    }
}
