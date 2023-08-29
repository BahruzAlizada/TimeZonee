using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #region Index
        public IActionResult Index()
        {
            List<Category> categories = categoryService.GetAll().OrderByDescending(x => x.Id).ToList();
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

            categoryService.Add(category);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            var dbcat = categoryService.GetById(id);
            if (dbcat == null)
                return BadRequest();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,Category category)
        {
            var dbcat = categoryService.GetById(id);
            if (dbcat == null)
                return BadRequest();

            dbcat.Name = category.Name;

            categoryService.Update(category);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
