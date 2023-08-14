using Microsoft.AspNetCore.Mvc;

namespace Timezone.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
