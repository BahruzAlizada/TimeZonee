using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISocialMediaService socialMediaService;
        public FooterViewComponent(ISocialMediaService socialMediaService)
        {
            this.socialMediaService = socialMediaService;
        }
        public IViewComponentResult Invoke()
        {
            SocialMedia socialMedia = socialMediaService.Get();
            return View(socialMedia);
        }
    }
}
