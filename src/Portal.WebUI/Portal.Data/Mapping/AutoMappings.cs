using AutoMapper;
using Portal.Data.Entities;
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
            //mappings go here
            CreateMap<ApplicationUser, UserViewModel>();
        }
    }
}
