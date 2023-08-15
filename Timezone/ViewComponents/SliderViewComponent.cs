using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService sliderService;
        public SliderViewComponent(ISliderService sliderService)
        {
            this.sliderService = sliderService;
        }

        public IViewComponentResult Invoke()
        {
            Slider slider = sliderService.Get();
            return View(slider);
        }
    }
}
