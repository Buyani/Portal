using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IIdentityRoleService _identityroleservice;

        public AdminController(IIdentityService identityservice, IIdentityRoleService identityroleservice)
        {
            _identityservice = identityservice;
            _identityroleservice = identityroleservice;
        }
        public IActionResult Users()
        {
            var userlist = _identityservice.Users();
            return View(userlist);
        }
        // GET: AdminController
        public ActionResult CreateAdmin()
        {
            var user = new RegisterViewModel();
            return View(user);
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(RegisterViewModel model)
        {
            try
            {
                _identityservice.CreateUserAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateRole()
        {
            var role = new RoleModel();
            return View(role);
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole(RoleModel model)
        {
            try
            {
                _identityroleservice.AddRole(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
