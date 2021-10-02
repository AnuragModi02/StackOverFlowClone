using BuissnessLayer.IdentityModels;
using BuissnessLayer.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace StackOverflow_Clone.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.CreateQuestion = TempData.ContainsKey("CreateQuestion") ? true : false;
            TempData.Remove("CreateQuestion");
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

                AppUser user = new AppUser()
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    PasswordHash = Crypto.HashPassword(registerViewModel.Password),
                };

                IdentityResult result = userManager.Create(user);

                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("My Error", "invalid data");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                AppUser user = userManager.Find(login.UserName, login.Password);
                if (user != null)
                {
                    var identity = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    //use the instance that has been created. 
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
                    return RedirectToAction("GetQuestions", "Question");
                }
            }
            ModelState.AddModelError("loginError", "Invalid username or password");
            return View(login);
        }

        public ActionResult SignOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login");
        }
    }
}

        