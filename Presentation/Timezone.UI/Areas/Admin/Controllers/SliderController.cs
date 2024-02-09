using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Timezone.Application.Abstract;
using Timezone.Domain.Entities;

namespace Timezone.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{
		private readonly ISliderReadRepository sliderReadRepository;
		private readonly ISliderWriteRepository sliderWriteRepository;
        public SliderController(ISliderReadRepository sliderReadRepository, ISliderWriteRepository sliderWriteRepository)
        {
			this.sliderReadRepository= sliderReadRepository;	
			this.sliderWriteRepository = sliderWriteRepository;
        }

		#region Index
		public IActionResult Index()
		{
			Slider slider = sliderReadRepository.Get();
			return View(slider);
		}
		#endregion

		#region Update
		public IActionResult Update(int? id)
		{
			if (id == null) return NotFound();
			Slider dbSlider = sliderReadRepository.Get(x => x.Id == id);
			if (dbSlider == null) return BadRequest();

			return View(dbSlider);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Update(int? id, Slider slider)
		{
			if (id == null) return NotFound();
			Slider dbSlider = sliderReadRepository.Get(x => x.Id == id);
			if (dbSlider == null) return BadRequest();

			dbSlider.Id = slider.Id;
			dbSlider.Status = slider.Status;
			dbSlider.Created=slider.Created;
			dbSlider.Title=slider.Title;
			dbSlider.SubTitle=slider.SubTitle;

			sliderWriteRepository.Update(slider);
			return RedirectToAction("Index");
		}
		#endregion

	}
}
