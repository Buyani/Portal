using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.Entities
{
    public class BaseEntity
    {
        public DateTime DateCreated { get; set; }
        public BaseEntity()
        {
            this.DateCreated = DateTime.Now;
        }
    }
}
