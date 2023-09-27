using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Timezone.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;
        private readonly IMemoryCache memoryCache;
        public AboutController(IAboutService aboutService,IMemoryCache memoryCache)
        {
            this.aboutService = aboutService;
            this.memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            About about = aboutService.Get();
            return View(about);
        }
    }
}
