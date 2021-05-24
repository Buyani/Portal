using Portal.Data.Entities;
using Portal.Model.UserModels.Models;
using Portal.Model.UserModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Service.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
       
        Task<RegistrationToken> CreateUserAsync(RegisterViewModel model);
        Task<bool> FindUser(string userName);
        Task<UserViewModel> UserProfile(string email);
        Task<List<UserViewModel>> Users();
        Task<UserViewModel> UpdateProfile(UserViewModel model);
        Task<bool> LogUserIn(LoginModel model, bool RememberMe);
        Task LogOut();
        //Roles methods
        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> BlockUser(string userId);
        Task<bool> Unblock(string userId);

        Task<bool> UserBlocked(string email);
    }
}
