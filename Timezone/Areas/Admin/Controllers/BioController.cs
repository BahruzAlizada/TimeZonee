using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Timezone.Models;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BioController : Controller
    {
        private readonly IBioService bioService;
        private readonly IWebHostEnvironment env;
        public BioController(IBioService bioService,IWebHostEnvironment env)
        {
            this.bioService = bioService;
            this.env = env;
        }

        #region Index
        public IActionResult Index()
        {
            Bio bio = bioService.Get();
            return View(bio);
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            var dbBio = bioService.GetById(id);
            if (dbBio == null) return NotFound();

            BioModel dbModel = new BioModel
            {
                Id = dbBio.Id,
                HeaderImage = dbBio.HeaderImage,
                FooterImage = dbBio.FooterImage,
                FooterDescription = dbBio.FooterDescription
            };

            return View(dbModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id,BioModel model)
        {
            #region Get
            var dbBio = bioService.GetById(id);
            if (dbBio == null) return NotFound();

            BioModel dbModel = new BioModel
            {
                Id = dbBio.Id,
                HeaderImage = dbBio.HeaderImage,
                FooterImage = dbBio.FooterImage,
                FooterDescription = dbBio.FooterDescription
            };
            #endregion

            #region HeaderImage
            if (model.HeaderPhoto != null)
            {
                if (!model.HeaderPhoto.IsImage())
                {
                    ModelState.AddModelError("HeaderPhoto", "Sadəcə şəkil tipli fayllar");
                    return View();
                }
                if (model.HeaderPhoto.IsOlder256Kb())
                {
                    ModelState.AddModelError("HeaderPhoto", "Max 256Kb");
                    return View();
                }
                string folder = Path.Combine(env.WebRootPath, "assets", "img", "logo");
                model.HeaderImage = await model.HeaderPhoto.SaveFileAsync(folder);
                string path = Path.Combine(env.WebRootPath, folder, dbBio.HeaderImage);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                dbModel.HeaderImage = model.HeaderImage;
            }
            if(model.HeaderPhoto is null)
                model.HeaderImage = dbModel.HeaderImage;
            #endregion


            #region FooterImage
            if (model.FooterPhoto != null)
            {
                if (!model.FooterPhoto.IsImage())
                {
                    ModelState.AddModelError("FooterPhoto", "Sadəcə şəkil tipli fayllar");
                    return View();
                }
                if (model.FooterPhoto.IsOlder256Kb())
                {
                    ModelState.AddModelError("FooterPhoto", "Max 256Kb");
                    return View();
                }
                string folder = Path.Combine(env.WebRootPath, "assets", "img", "logo");
                model.FooterImage = await model.FooterPhoto.SaveFileAsync(folder);
                string path = Path.Combine(env.WebRootPath, folder, dbBio.FooterImage);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                dbModel.FooterImage = model.FooterImage;
            }
            if (model.FooterPhoto is null)
                model.FooterImage = dbModel.FooterImage;
            #endregion

            dbModel.Id = model.Id;
            dbModel.FooterDescription = model.FooterDescription;

            Bio bio = new Bio
            {
                Id = model.Id,
                HeaderImage = model.HeaderImage,
                FooterImage = model.FooterImage,
                FooterDescription = model.FooterDescription
            };

            bioService.Update(bio);
            return RedirectToAction("Index");
        }
        #endregion

    }
}
