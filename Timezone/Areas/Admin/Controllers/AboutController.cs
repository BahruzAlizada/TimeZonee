using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timezone.Models;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "ComManager,Admin")]
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
        public IActionResult Update(int id)
        {
            About dbabout = aboutService.GetById(id);
            if (dbabout is null) return BadRequest();

            AboutModel dbModel = new AboutModel
            {
                Id = dbabout.Id,
                Vision = dbabout.Vision,
                Mision = dbabout.Mision
            };

            return View(dbModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,AboutModel model)
        {
            #region Get
            About dbabout = aboutService.GetById(id);
            if (dbabout is null) return BadRequest();

            AboutModel dbModel = new AboutModel
            {
                Id = dbabout.Id,
                Vision = dbabout.Vision,
                Mision = dbabout.Mision
            };
            #endregion

            dbModel.Id = model.Id;
            dbModel.Mision = model.Mision;
            dbModel.Vision = model.Vision;

            About about = new About
            {
                Id = model.Id,
                Vision = model.Vision,
                Mision = model.Mision
            };

            aboutService.Update(about);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
