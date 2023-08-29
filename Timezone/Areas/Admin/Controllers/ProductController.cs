using Microsoft.AspNetCore.Mvc;

namespace Timezone.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
