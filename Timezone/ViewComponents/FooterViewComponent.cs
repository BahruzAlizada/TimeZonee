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
        private readonly IBioService bioService;
        public FooterViewComponent(ISocialMediaService socialMediaService,IProductService productService,IBioService bioService)
        {
            this.socialMediaService = socialMediaService;
            this.productService = productService;
            this.bioService = bioService;
        }
        public IViewComponentResult Invoke()
        {
            FooterVM footerVM = new FooterVM
            {
                SocialMedia = socialMediaService.Get(),
                Products = productService.GetAll().OrderByDescending(x=>x.Id).Take(4).ToList(),
                Bio = bioService.GetBio()
            };
            return View(footerVM);
        }
    }
}
