using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Model.UserModels.Models;
using Portal.Model.UserModels.ViewModels;
using Portal.Service.Interfaces;
using System.Threading.Tasks;

namespace Portal.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityservice;
        public AccountController(IIdentityService identityservice)
        {
            _identityservice = identityservice;

        }
        public IActionResult Users()
        {
            var users = _identityservice.Users();
            return View(users);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _identityservice.FindUser(model.Email))
                {
                    ModelState.AddModelError("", "User with same username already exists");
                    return View(model);
                }

                var result = await _identityservice.CreateUserAsync(model);

                if (result.Results)
                {
                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    ModelState.AddModelError("", result.ToString());
                }
            }
            return View(model);
        }


        // GET: Login
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            var loginview = new LoginModel();
            return View(loginview);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LogIn(LoginModel model, string returnUrl, bool RememberMe)
        {
            if (ModelState.IsValid)
            {
                var results = await _identityservice.LogUserIn(model, RememberMe);
                if (results)
                {
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    if(await _identityservice.UserBlocked(model.Email))
                    {
                        TempData["message"] = "This user has been blocked please contact admin";
                        return View(model);
                    }
                    TempData["message"] = "Hi " + model.Email.ToString().Split("@")[0] + " welcome back";
                    return RedirectToAction("Index","Home");
                }                 
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    return View(model);
                }
            }

            return View(model);
        }


        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOff()
        {
            await _identityservice.LogOut();
            return RedirectToAction("Index", "Home");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Profile(string email)
        {
            var profile = await _identityservice.UserProfile(email);
            return View(profile);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Profile(UserViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
               await _identityservice.UpdateProfile(model);
            }
            return RedirectToAction("Profile", "Account",new {email= model.Email });
        }



    }
}
