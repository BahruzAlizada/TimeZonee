using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Timezone.ViewsModel;

namespace Timezone.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISocialMediaService socialMediaService;
        private readonly IProductService productService;
        public FooterViewComponent(ISocialMediaService socialMediaService,IProductService productService)
        {
            this.socialMediaService = socialMediaService;
            this.productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            FooterVM footerVM = new FooterVM
            {
                SocialMedia = socialMediaService.Get(),
                Products = productService.GetAll().OrderByDescending(x=>x.Id).Take(4).ToList()
            };
            return View(footerVM);
        }
    }
}
