using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Timezone.ViewsModel;

namespace Timezone.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles="User")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public ProfileController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager=signInManager;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            AppUser dbuser = await userManager.FindByNameAsync(User.Identity.Name);
            UserVM dbuserVM = new UserVM
            {
                Name = dbuser.Name,
                Surname = dbuser.Surname,
                Email = dbuser.Email,
                UserName = dbuser.UserName,
            };
            return View(dbuserVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index(UserVM userVM)
        {
            #region Get
            AppUser dbuser = await userManager.FindByNameAsync(User.Identity.Name);
            UserVM dbuserVM = new UserVM
            {
                Name = dbuser.Name,
                Surname = dbuser.Surname,
                Email = dbuser.Email,
                UserName = dbuser.UserName,
            };
            #endregion

            dbuser.Name = userVM.Name;
            dbuser.Surname = userVM.Surname;
            dbuser.UserName = userVM.UserName;
            dbuser.Email = userVM.Email;

            await userManager.UpdateAsync(dbuser);
            return RedirectToAction("Index", "Profile");
        }
        #endregion

        #region DeactiveAccount
        public async Task<IActionResult> DeactiveAccount()
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user.IsDeactive == false)
                user.IsDeactive = true;

            await userManager.UpdateAsync(user);
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "default" });
        }
        #endregion

        #region ChangePassword
        public async Task<IActionResult> ChangePassword()
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ChangePassword(ChangePasswordVM changePassword)
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            bool oldPasswordIsValid = await userManager.CheckPasswordAsync(user, changePassword.OldPassword);

            if(oldPasswordIsValid)
            {
                string newPasswordHash = userManager.PasswordHasher.HashPassword(user, changePassword.NewPassword);
                user.PasswordHash = newPasswordHash;
                var result = await userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                    return View();
                }
                await signInManager.SignOutAsync(); //Əgər şifrə dəyişsə hesabdan çıxış et və Login səhifəsinə dön
                return RedirectToAction("Login", "Account", new { area = "default" });
            }
            else
            {
                ModelState.AddModelError("OldPassword", "Sizin köhnə şifrəniz düzgün deyil");
                return View();
            }
        }
        #endregion

    }
}
