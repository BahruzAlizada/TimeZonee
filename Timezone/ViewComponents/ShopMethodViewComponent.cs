using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Timezone.ViewComponents
{
    public class ShopMethodViewComponent : ViewComponent
    {
        private readonly IShopMethodService shopMethodService;
        private readonly IMemoryCache memoryCache;
        public ShopMethodViewComponent(IShopMethodService shopMethodService,IMemoryCache memoryCache)
        {
            this.shopMethodService=shopMethodService;
            this.memoryCache = memoryCache;
        }

        public IViewComponentResult Invoke()
        {
           List<ShopMethod> shopMethods;

            if(!memoryCache.TryGetValue("shopMethods",out shopMethods))
            {
                shopMethods = shopMethodService.GetAll().Where(x => !x.IsDeactive).Take(3).ToList();

                var memoryCacheEntryOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(10),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(40),
                    Priority = CacheItemPriority.Normal
                };

                memoryCache.Set("shopMethods",shopMethods,memoryCacheEntryOptions);
            }

            return View(shopMethods);
        }
    }
}
