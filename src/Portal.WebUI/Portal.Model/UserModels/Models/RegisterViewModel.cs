using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Model.UserModels.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string Email { get; set; }
    }
}
