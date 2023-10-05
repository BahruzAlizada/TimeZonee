using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timezone.Models;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "ProductManager,Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #region Index
        public IActionResult Index(int page=1)
        {
            double take = 10;
            ViewBag.PageCount = Math.Ceiling(categoryService.GetAll().Count / take);
            ViewBag.CurrentPage = page;

            List<Category> categories = categoryService.GetAll().OrderByDescending(x=>x.Id)
                .Skip((page-1)*(int)take).Take((int)take).ToList();

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

        public IActionResult Create(CategoryModel model)
        {

            #region Exist
            bool isExist = categoryService.GetAll().Any(x => x.Name == model.CategoryName);
            if (isExist)
            {
                ModelState.AddModelError("CategoryName", "Bu adda kateqoriya hal-hazırda var");
                return View();
            }
            #endregion

            Category category = new Category
            {
                Id = model.Id,
                Image = "1",
                Name = model.CategoryName,
                IsDeactive = false
            };
            
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

            CategoryModel dbModel = new CategoryModel
            {
                Id = dbcat.Id,
                CategoryName = dbcat.Name
            };

            return View(dbModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,CategoryModel model)
        {
            #region Get
            var dbcat = categoryService.GetById(id);
            if (dbcat == null)
                return BadRequest();

            CategoryModel dbModel = new CategoryModel
            {
                Id = dbcat.Id,
                CategoryName = dbcat.Name
            };
            #endregion

            #region Exist
            bool isExist = categoryService.GetAll().Any(x => x.Name == model.CategoryName && x.Id!=model.Id);
            if (isExist)
            {
                ModelState.AddModelError("CategoryName", "Bu adda kateqoriya hal-hazırda var");
                return View();
            }
            #endregion

            dbModel.Id = model.Id;
            dbModel.CategoryName = model.CategoryName;

            Category category = new Category
            {
                Id = model.Id,
                Name = model.CategoryName,
                Image = "1",
                IsDeactive = false
            };

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
