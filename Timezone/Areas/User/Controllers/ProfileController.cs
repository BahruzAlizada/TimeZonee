using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using Timezone.ViewsModel;

namespace Timezone.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles="User")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IWebHostEnvironment env;
        private readonly IBonusService bonusService;
        public ProfileController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,
            IWebHostEnvironment env,IBonusService bonusService)
        {
            this.userManager = userManager;
            this.signInManager=signInManager;
            this.env = env;
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
				Image = dbuser.Image,
				PhoneNumber = dbuser.PhoneNumber,
                Bio=dbuser.Bio,
				IsSalesAccount = dbuser.IsSalesAccount,
				IsVerify = dbuser.IsVerify
			};
            return View(dbuserVM);
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

		#region AccountInformation
		public async Task<IActionResult> AccountInformation()
		{
			AppUser dbuser = await userManager.FindByNameAsync(User.Identity.Name);
			UserVM dbuserVM = new UserVM
			{
				Name = dbuser.Name,
				Surname = dbuser.Surname,
				Email = dbuser.Email,
				UserName = dbuser.UserName,
                Bio=dbuser.Bio,
                Image=dbuser.Image,
                PhoneNumber=dbuser.PhoneNumber,
                IsSalesAccount=dbuser.IsSalesAccount,
                IsVerify = dbuser.IsVerify
			};
			return View(dbuserVM);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> AccountInformation(UserVM userVM)
		{
			#region Get
			AppUser dbuser = await userManager.FindByNameAsync(User.Identity.Name);
			UserVM dbuserVM = new UserVM
			{
				Name = dbuser.Name, Surname = dbuser.Surname,
				Email = dbuser.Email, UserName = dbuser.UserName, Image = dbuser.Image,
				PhoneNumber = dbuser.PhoneNumber, Bio=dbuser.Bio,
                IsSalesAccount = dbuser.IsSalesAccount, IsVerify = dbuser.IsVerify
			};
            #endregion

            #region Image
            if (userVM.Photo != null)
            {
                if (!userVM.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Sadəcə şəkil tipli fayllar");
                    return View();
                }
                if (userVM.Photo.IsOlder256Kb())
                {
                    ModelState.AddModelError("Photo", "Max 256 Kb");
                    return View();
                }
                string folder = Path.Combine(env.WebRootPath, "assets", "img", "user");
                dbuser.Image = await userVM.Photo.SaveFileAsync(folder);
                string path = Path.Combine(env.WebRootPath, folder, dbuserVM.Image);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                dbuserVM.Image = userVM.Image;
            }
            #endregion

            dbuser.Name = userVM.Name;
			dbuser.Surname = userVM.Surname;
			dbuser.UserName = userVM.UserName;
			dbuser.Email = userVM.Email;
            dbuser.IsVerify = userVM.IsVerify;
            dbuser.IsSalesAccount = userVM.IsSalesAccount;
            dbuser.PhoneNumber = userVM.PhoneNumber;
            dbuser.Bio = userVM.Bio;

			await userManager.UpdateAsync(dbuser);
			return RedirectToAction("AccountInformation");
		}
        #endregion

        #region SalesAccount
        public async Task<IActionResult> SalesAccount(string username)
        {
            AppUser user = await userManager.FindByNameAsync(username);
            user.IsSalesAccount = true;
            await userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        #endregion


    }
}
