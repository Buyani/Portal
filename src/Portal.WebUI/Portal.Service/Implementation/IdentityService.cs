using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portal.Data.Entities;
using Portal.Model.RolesModels;
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
            var result = await _userManager.CreateAsync(user,GeneratePassword());
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
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
        private async Task<List<string>> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        public async Task<List<UserViewModel>> Users()
        {
            var list =  _userManager.Users;
            var userviewlist= list.Select(_mapper.Map<ApplicationUser, UserViewModel>).ToList();
            foreach(var user in userviewlist)
            {
                user.UserRoles = await GetUserRoles(user.Id);
            }

            return userviewlist;
        }
        public async Task<UserViewModel> UpdateProfile(UserViewModel model)
        {
            var userview = new UserViewModel();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                user.LastName = model.LastName;
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
            var user = await _userManager.FindByEmailAsync(model.Email);
            var results = await _userManager.CheckPasswordAsync(user, model.Password);
            if (results)
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
        public async Task<bool> BlockUser(string userId)
        {
            var output = false;
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.Blocked = true;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    output = true;
                }
            }
            return output;
        }
        public async Task<bool>  Unblock(string userId)
        {
            var output = false;
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.Blocked = false;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    output = true;
                }
            }
            return output;
        }
        public async Task<bool> UserBlocked(string email)
        {
            var blocked = false;
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                blocked = user.Blocked;
            }
            return blocked;
        }
        public string GeneratePassword()
        {
            var options = _userManager.Options.Password;

            int length = options.RequiredLength;

            bool nonAlphanumeric = options.RequireNonAlphanumeric;
            bool digit = options.RequireDigit;
            bool lowercase = options.RequireLowercase;
            bool uppercase = options.RequireUppercase;

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            while (password.Length < length)
            {
                char c = (char)random.Next(32, 126);

                password.Append(c);

                if (char.IsDigit(c))
                    digit = false;
                else if (char.IsLower(c))
                    lowercase = false;
                else if (char.IsUpper(c))
                    uppercase = false;
                else if (!char.IsLetterOrDigit(c))
                    nonAlphanumeric = false;
            }

            if (nonAlphanumeric)
                password.Append((char)random.Next(33, 48));
            if (digit)
                password.Append((char)random.Next(48, 58));
            if (lowercase)
                password.Append((char)random.Next(97, 123));
            if (uppercase)
                password.Append((char)random.Next(65, 91));

            return password.ToString();
        }

    }
}
