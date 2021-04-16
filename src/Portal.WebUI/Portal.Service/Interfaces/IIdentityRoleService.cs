using Microsoft.AspNetCore.Identity;
using Portal.Model.RolesModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Service.Interfaces
{
    public interface IIdentityRoleService
    {
        Task<IdentityResult> AddRole(RoleModel model);
        Task<ICollection<RoleViewModel>> RolesList();
    }
}
