using Microsoft.AspNetCore.Mvc;
using Timezone.Application.Abstract;
using Timezone.Domain.Entities;

namespace Timezone.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryReadRepository categoryReadRepository;
		private readonly ICategoryWriteRepository categoryWriteRepository;
        public CategoryController(ICategoryReadRepository categoryReadRepository,ICategoryWriteRepository categoryWriteRepository)
        {
			this.categoryWriteRepository = categoryWriteRepository;
			this.categoryReadRepository = categoryReadRepository;
        }

		#region Index
		public IActionResult Index()
		{
			List<Category> categories = categoryReadRepository.GetAll();
			return View(categories);
		}
		#endregion

		#region Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(Category category)
		{
			categoryWriteRepository.Add(category);
			return RedirectToAction("Index");
		}
		#endregion

		#region Update
		public IActionResult Update(int? id)
		{
			if (id == null) return NotFound();
			Category dbCategory = categoryReadRepository.Get(x => x.Id == id);
			if (dbCategory == null) return BadRequest();

			return View(dbCategory);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Update(int? id, Category category)
		{
			if (id == null) return NotFound();
			Category dbCategory = categoryReadRepository.Get(x => x.Id == id);
			if (dbCategory == null) return BadRequest();

			dbCategory.Id = category.Id;
			dbCategory.Status = category.Status;
			dbCategory.Created = category.Created;
			dbCategory.Name = category.Name;

			categoryWriteRepository.Update(category);
			return RedirectToAction("Index");
		}
		#endregion

		#region Delete
		public IActionResult Delete(int? id)
		{
			if (id == null) return NotFound();
			Category category = categoryReadRepository.Get(x => x.Id == id);
			if (category == null) return BadRequest();

			categoryWriteRepository.Delete(category);
			return RedirectToAction("Index");
		}
		#endregion

		#region Activity
		public IActionResult Activity(int? id)
		{
			if (id == null) return NotFound();
			Category category = categoryReadRepository.Get(x => x.Id == id);
			if (category == null) return BadRequest();

			categoryWriteRepository.Activity(category);
			return RedirectToAction("Index");
		}
		#endregion
	}
}
