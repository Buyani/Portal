using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data
{
    public class PortalDataContext: IdentityDbContext<ApplicationUser>
    {
        public PortalDataContext()
        {
        }

        public PortalDataContext(DbContextOptions<PortalDataContext> options)
            : base(options)
        {
        }

        //Initialize entities
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
