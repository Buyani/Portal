using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public IdentityRoleService(RoleManager<IdentityRole> roleManager)
        {

            _roleManager = roleManager;
        }
        public async Task<IdentityResult> AddRole(RoleModel model)
        {
            var results = new IdentityResult();
            if (model.Name != null)
            {
               results =  await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));

            }
            return results;
        }
        public async Task<ICollection<RoleViewModel>> RolesList()
        {
            var list = await _roleManager.Roles.ToListAsync();
            return list.Select(p => new RoleViewModel { Name = p.Name, Id = p.Id }).ToList();
        }

    }
}
