using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.ViewComponents
{
    public class GaleryViewComponent : ViewComponent
    {
        private readonly IGaleryService galeryService;
        public GaleryViewComponent(IGaleryService galeryService)
        {
            this.galeryService = galeryService;
        }

        public IViewComponentResult Invoke()
        {
            List<Galery> galeries = galeryService.GetAll();
            return View(galeries);
        }
    }
}
