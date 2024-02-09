using Microsoft.AspNetCore.Mvc;
using Timezone.Application.Abstract;
using Timezone.Domain.Entities;

namespace Timezone.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class GenderController : Controller
	{
		private readonly IGenderReadRepository genderReadRepository;
		private readonly IGenderWriteRepository genderWriteRepository;
        public GenderController(IGenderReadRepository genderReadRepository, IGenderWriteRepository genderWriteRepository)
        {
			this.genderReadRepository = genderReadRepository;
			this.genderWriteRepository = genderWriteRepository;
        }

		#region Index
		public IActionResult Index()
		{
			List<Gender> genders = genderReadRepository.GetAll();
			return View(genders);
		}
		#endregion

		#region Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(Gender gender)
		{
			genderWriteRepository.Add(gender);
			return RedirectToAction("Index");
		}
		#endregion

		#region Update
		public IActionResult Update(int? id)
		{
			if (id == null) return NotFound();
			Gender dbGender = genderReadRepository.Get(x => x.Id == id);
			if (dbGender == null) return BadRequest();

			return View(dbGender);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Update(int? id,Gender gender)
		{
			if (id == null) return NotFound();
			Gender dbGender = genderReadRepository.Get(x => x.Id == id);
			if (dbGender == null) return BadRequest();

			dbGender.Id = gender.Id;
			dbGender.Name = gender.Name;
			dbGender.Status= gender.Status;
			dbGender.Created = gender.Created;

			genderWriteRepository.Update(gender);
			return RedirectToAction("Index");
		}
		#endregion

		#region Delete
		public IActionResult Delete(int? id)
		{
			if (id == null) return NotFound();
			Gender gender = genderReadRepository.Get(x=>x.Id== id);
			if(gender==null) return BadRequest();

			genderWriteRepository.Delete(gender);
			return RedirectToAction("Index");
		}
		#endregion

		#region Activity
		public IActionResult Activity(int? id)
		{
			if (id == null) return NotFound();
			Gender gender = genderReadRepository.Get(x => x.Id == id);
			if (gender == null) return BadRequest();

			genderWriteRepository.Activity(gender);
			return RedirectToAction("Index");
		}
		#endregion
	}
}
