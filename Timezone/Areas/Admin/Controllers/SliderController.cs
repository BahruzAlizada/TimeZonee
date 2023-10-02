using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timezone.Models;

namespace Timezone.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "ComManager,Admin")]
    public class SliderController : Controller
	{
		private readonly ISliderService sliderService;
		private readonly IWebHostEnvironment env;
        public SliderController(ISliderService sliderService,IWebHostEnvironment env)
        {
            this.sliderService=sliderService;
			this.env=env;
        }

		#region Index
		public IActionResult Index()
		{
			Slider slider = sliderService.Get();
			return View(slider);
		}
		#endregion

		#region Update
		public IActionResult Update(int id)
		{
			Slider dbSlider = sliderService.GetById(id);

			SliderModel dbModel = new SliderModel
			{
				Id = dbSlider.Id,
				Title = dbSlider.Title,
				Image = dbSlider.Image,
				SubTitle = dbSlider.SubTitle
			};

			return View(dbModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> Update(int id,SliderModel model)
		{
			#region Get
			Slider dbSlider = sliderService.GetById(id);

			SliderModel dbModel = new SliderModel
			{
				Id = dbSlider.Id,
				Title = dbSlider.Title,
				Image = dbSlider.Image,
				SubTitle = dbSlider.SubTitle
			};
			#endregion

			#region Image
			if (model.Photo != null)
			{
				if (!model.Photo.IsImage())
				{
					ModelState.AddModelError("Photo", "Sadəcə Şəkil tipli fayllar");
					return View();
				}
				if (model.Photo.IsOlder512Kb())
				{
					ModelState.AddModelError("Photo", "Maksimum 256 Kb");
					return View();
				}
				string folder = Path.Combine(env.WebRootPath, "assets", "img", "slider");
				model.Image = await model.Photo.SaveFileAsync(folder);
				string path = Path.Combine(env.WebRootPath, folder, dbSlider.Image);
				if (System.IO.File.Exists(path))
					System.IO.File.Delete(path);
				dbModel.Image = model.Image;
			}
			if (model.Photo is null)
				model.Image = dbModel.Image;
			#endregion

			dbModel.Id = model.Id;
			dbModel.Title = model.Title;
			dbModel.SubTitle = model.SubTitle;

			Slider slider = new Slider
			{
				Id = model.Id,
				Image = model.Image,
				Title = model.Title,
				SubTitle = model.SubTitle
			};

			sliderService.Update(slider);
			return RedirectToAction("Index");
		}
		#endregion
	}
}
