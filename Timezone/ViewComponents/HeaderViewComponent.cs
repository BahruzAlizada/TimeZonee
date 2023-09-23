using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace Timezone.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IBonusService bonusService;
        private readonly UserManager<AppUser> userManager;
        public HeaderViewComponent(IBonusService bonusService,UserManager<AppUser> userManager)
        {
            this.bonusService = bonusService;
            this.userManager=userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                Bonus bonus = await bonusService.GetBonusUser(user.Id);
                ViewBag.Bonus = bonus.Amount;
                return View();
            }
            return View();
        }
    }
}
