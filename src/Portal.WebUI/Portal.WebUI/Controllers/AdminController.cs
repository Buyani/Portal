using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Data.Entities;
using Portal.Model.RolesModels;
using Portal.Model.UserModels.Models;
using Portal.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IIdentityService _identityservice;

        RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityRoleService _identityroleservice;
        public AdminController(UserManager<ApplicationUser> userManager,IIdentityService identityservice, IIdentityRoleService identityroleservice, RoleManager<IdentityRole> roleManager)
        {
            _identityservice = identityservice;
            _identityroleservice = identityroleservice;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Users(string searchString)
        {
            var userlist = await _identityservice.Users();
            if (!String.IsNullOrEmpty(searchString))
            {
                userlist = userlist.Where(s => s.FirstName.Contains(searchString)).ToList();
            }
            return View(userlist);
        }

        public async Task<IActionResult> Roles()
        {
            var roles =await _identityroleservice.RolesList();
            return View(roles);

        }
        public ActionResult CreateAdmin()
        {
            var user = new RegisterViewModel();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAdmin(RegisterViewModel model)
        {
            try
            {
               await _identityservice.CreateUserAsync(model);
                return RedirectToAction(nameof(Users));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateRole()
        {
            var role = new IdentityRole();
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>CreateRole(IdentityRole model)
        {
            try
            {
                await _roleManager.CreateAsync(model);
                return RedirectToAction("Roles");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Block(string userId)
        {
            await _identityservice.BlockUser(userId);
            return RedirectToAction("Users");
        }
        public async Task<ActionResult> Unblock(string userId)
        {
            await _identityservice.Unblock(userId);
            return RedirectToAction("Users");
        }




        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Users");
        }
    }
}
