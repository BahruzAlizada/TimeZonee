using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.ViewComponents
{
    public class ShopMethodViewComponent : ViewComponent
    {
        private readonly IShopMethodService shopMethodService;
        public ShopMethodViewComponent(IShopMethodService shopMethodService)
        {
            this.shopMethodService=shopMethodService;
        }

        public IViewComponentResult Invoke()
        {
            List<ShopMethod> shopMethods = shopMethodService.GetAll().Take(3).ToList();
            return View(shopMethods);
        }
    }
}
