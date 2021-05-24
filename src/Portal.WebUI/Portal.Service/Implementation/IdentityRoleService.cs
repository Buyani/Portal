using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portal.Data.Entities;
using Portal.Model.RolesModels;
using Portal.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Service.Implementation
{
    public class IdentityRoleService : IIdentityRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public IdentityRoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IdentityResult> AddRole(RoleModel model)
        {
            return await _roleManager.CreateAsync(new IdentityRole {Name=model.Name });
        }
        public async Task<ICollection<RoleViewModel>> RolesList()
        {
            var list = await _roleManager.Roles.ToListAsync();
            return list.Select(_mapper.Map<IdentityRole, RoleViewModel>).ToList();

        }
    }
}
