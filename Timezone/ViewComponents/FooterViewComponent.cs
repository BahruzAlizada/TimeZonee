using Microsoft.AspNetCore.Mvc;

namespace Timezone.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
