using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Timezone.ViewsModel;

namespace Timezone.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginVM login)
        {
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("","Email və yaxud Şifrə yanlışdır");
                return View();
            }
            if (user.IsDeactive)
            {
                ModelState.AddModelError("", "Sizin hesabınız bloklanıb");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, login.Password,
                login.IsRemember, true);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email və yaxud Şifrə yanlışdır");
                return View();
            }
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Sizin hesabınız 1 dəqiqəlik blokandı.");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterVM register)
        {
            AppUser newuser = new AppUser
            {
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                UserName = register.UserName
            };
            IdentityResult identityResult = await _userManager.CreateAsync(newuser, register.Password);
            if(!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            var rolename = await _roleManager.FindByNameAsync("User");
            await _userManager.AddToRoleAsync(newuser,rolename.Name);
            await _signInManager.SignInAsync(newuser,register.IsRemember);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region SignOut
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
