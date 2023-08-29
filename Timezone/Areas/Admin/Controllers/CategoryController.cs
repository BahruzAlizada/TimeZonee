using BusinessLayer.Abstract;
using BusinessLayer.ValidationRule.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation;
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
            #region Validator
            var validator = new CategoryValidator();
            var result = validator.Validate(category);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
            #endregion

            #region Exist
            bool isExist = categoryService.GetAll().Any(x => x.Name == category.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu addan hal-hazırda var");
                return View();
            }
            #endregion

            category.Image = "null";
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

            return View(dbcat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,Category category)
        {
            var dbcat = categoryService.GetById(id);
            if (dbcat == null)
                return BadRequest();

            #region Validator
            var validator = new CategoryValidator();
            var result = validator.Validate(category);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            #endregion

            #region Exist
            bool isExist = categoryService.GetAll().Any(x => x.Name == category.Name && x.Id!=category.Id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu addan hal-hazırda var");
                return View();
            }
            #endregion

            dbcat.Name = category.Name;
            category.Image = "c";
            categoryService.Update(category);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            categoryService.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
