using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Timezone.ViewsModel;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "UserManager,Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IBonusService bonusService;
        public UserController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager,IBonusService bonusService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.bonusService = bonusService;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = await userManager.Users.ToListAsync();
            List<UserListVM> usersVM = new List<UserListVM>();

            

            foreach (var item in users)
            {
                UserListVM userList = new UserListVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Email = item.Email,
                    UserName = item.UserName,
                    PhoneNumber = item.PhoneNumber,
                    Image = item.Image,
                    Role = (await userManager.GetRolesAsync(item))[0],
                    Amount = await bonusService.GetBonusAmountUser(item.Id),
                    IsDeactive=item.IsDeactive
                    
                };
                usersVM.Add(userList);
            }

            return View(usersVM);
        }
        #endregion

        #region RoleChange
        public async Task<IActionResult> RoleChange(string username)
        {
            AppUser user = await userManager.FindByNameAsync(username);

            ViewBag.Roles = await roleManager.Roles.Select(x=>x.Name).ToListAsync();

            RoleVM roleVM = new RoleVM
            {
                UserName = user.UserName,
                Role = (await userManager.GetRolesAsync(user))[0]
            };

            return View(roleVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> RoleChange(string username,string role)
        {
            AppUser user = await userManager.FindByNameAsync(username);

            ViewBag.Roles = await roleManager.Roles.Select(x => x.Name).ToListAsync();

            RoleVM roleVM = new RoleVM
            {
                UserName = user.UserName,
                Role = (await userManager.GetRolesAsync(user))[0]
            };

            await userManager.RemoveFromRoleAsync(user,roleVM.Role);
            await userManager.AddToRoleAsync(user,role);

            return RedirectToAction("Index");
        }
        #endregion

        #region ResetPassword

        public async Task<IActionResult> ResetPassword(string userName)
        {
            AppUser user = await userManager.FindByNameAsync(userName);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ResetPassword(string userName,ResetPasswordVM resetPassword)
        {
            AppUser user = await userManager.FindByNameAsync(userName);

            string token=await userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult identityResult = await userManager.ResetPasswordAsync(user, token, resetPassword.NewPassword);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public async Task<IActionResult> Activity(string userName)
        {
            AppUser user = await userManager.FindByNameAsync(userName);
            if (user.IsDeactive)
                user.IsDeactive = false;
            else
                user.IsDeactive = true;

            await userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
