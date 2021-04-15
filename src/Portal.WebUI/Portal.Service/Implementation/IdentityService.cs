using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portal.Data.Entities;
using Portal.Model.UserModels.Models;
using Portal.Model.UserModels.ViewModels;
using Portal.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Service.Implementation
{
    public class IdentityService: IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IMapper _mapper;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<RegistrationToken> CreateUserAsync(RegisterViewModel model)
        {
            var token = new RegistrationToken();
            var user = new ApplicationUser { FirstName = model.FirstName, LastName = model.LastName, UserName = model.Email, Email = model.Email, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Client");
                token.Results = true;
                token.EmailConfimationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                token.User = user;
            }

            return token;
        }
        public async Task<bool> FindUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<UserViewModel> UserProfile(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return _mapper.Map<UserViewModel>(user);
        }

        public List<UserViewModel> Users()
        {
            var list = _userManager.Users;
            return list.Select(_mapper.Map<ApplicationUser, UserViewModel>).ToList();
        }
        public async Task<UserViewModel> UpdateProfile(UserViewModel model)
        {
            var userview = new UserViewModel();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    userview = _mapper.Map<UserViewModel>(user);
                }
            }
            return userview;
        }
        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }
        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return await _userManager.IsInRoleAsync(user, role);
        }
        public async Task<bool> LogUserIn(LoginModel model, bool RememberMe)
        {
            bool token = false;
            var user = await _userManager.FindByNameAsync(model.Email);
            var paswsord = await _userManager.CheckPasswordAsync(user, model.Password);
            if (paswsord)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    token = true;
                }
            }
            return token;
        }
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
