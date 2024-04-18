using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PanelClebWeb.Models;

namespace PanelClebWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AdminUser> _userManager;

        public UserController(UserManager<AdminUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allUsers = _userManager.Users.ToList();
            return View(allUsers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                AdminUser w = new AdminUser()
                {
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email

                };
                var result = await _userManager.CreateAsync(w, user.Password);
                Console.WriteLine(result);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            UserEditViewModel model = new UserEditViewModel();
            model.FullName = user.FullName;
            model.UserName = user.UserName;
            model.Email = user.Email;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel u, string OldPassword, string NewPassword, string NewPasswordConfirm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine(u.Id);
                    var user = await _userManager.FindByIdAsync(u.Id.ToString());
                    if (user == null)
                    {
                        return RedirectToAction("Error");
                    }
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, OldPassword);

                    if (!passwordCheck)
                    {
                        ModelState.AddModelError(nameof(UserEditViewModel.OldPassword), "Eski Şifre Yanlış!");
                        return View(u);
                    }

                    if (!string.IsNullOrEmpty(NewPassword) && !string.IsNullOrEmpty(NewPasswordConfirm))
                    {
                        if (NewPassword != NewPasswordConfirm)
                        {
                            ModelState.AddModelError(nameof(UserEditViewModel.NewPassword), "Şifreler Eşleşmiyor!");
                            ModelState.AddModelError(nameof(UserEditViewModel.NewPasswordConfirm), "Şifreler Eşleşmiyor!");
                            return View(u);
                        }

                        var passwordChangeResult = await _userManager.ChangePasswordAsync(user, OldPassword, NewPassword);
                        Console.WriteLine(passwordChangeResult);
                        if (!passwordChangeResult.Succeeded)
                        {
                            ModelState.AddModelError(nameof(UserEditViewModel.OldPassword), "Şifre Güncellenirken Bir Hata Oluştu!");
                            return View(u);
                        }
                    }

                    user.FullName = u.FullName;
                    user.Email = u.Email;
                    user.UserName = u.UserName;

                    var updateResult = await _userManager.UpdateAsync(user);
                    Console.WriteLine(updateResult);
                    if (updateResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(UserEditViewModel.UserName), "Kullanıcı Güncellenemedi!");
                        return View(u);
                    }
                }
                return View(u);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                ViewBag.StackTrace = ex.StackTrace;
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());

                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {

                        return RedirectToAction("Error");
                    }
                }
                return View("Error");
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
