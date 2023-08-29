using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;
        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        #region Index
        public IActionResult Index()
        {
            About about = aboutService.Get();
            return View(about);
        }
        #endregion

        #region Update
        public IActionResult Update()
        {
            About dbabout = aboutService.Get();
            return View(dbabout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(About about)
        {
            About dbabout = aboutService.Get();
            dbabout.Mision = about.Mision;
            dbabout.Vision = about.Vision;

            aboutService.Update(about);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
