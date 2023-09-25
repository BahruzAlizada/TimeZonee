using Microsoft.AspNetCore.Mvc;

namespace Timezone.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
