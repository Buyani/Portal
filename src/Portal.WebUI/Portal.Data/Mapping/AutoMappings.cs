using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Portal.Data.Entities;
using Portal.Model.RolesModels;
using Portal.Model.SubjectModels;
using Portal.Model.UserModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.Mapping
{
    public class AutoMappings:Profile
    {
        public AutoMappings()
        {
            //user mappings
            CreateMap<ApplicationUser, UserViewModel>();

            //subject mappings
            CreateMap<SubjectModel, Subject>();
            CreateMap<Subject, SubjectViewModel>();

            //Roles mappings
            CreateMap<IdentityRole, RoleViewModel>();
            CreateMap<RoleViewModel, IdentityRole>();
        }
    }
}
