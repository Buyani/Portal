using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Data.Entities
{
    public class Student:BaseEntity
    {
        [Key]
        public string Identity { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Nationality { get; set; }
        public string CellNumber { get; set; }
        public bool Active { get; set; } = true;
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public string PreviousSchoolName { get; set; }
    }
}
