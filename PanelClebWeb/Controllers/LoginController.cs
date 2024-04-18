using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PanelClebWeb.Models;

namespace PanelClebWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AdminUser> _signInManager;

        public LoginController(SignInManager<AdminUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(u.UserName, u.Password, true, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre!");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                ViewBag.StackTrace = ex.StackTrace;
                return View("Error");
            }
        }
    }
}
