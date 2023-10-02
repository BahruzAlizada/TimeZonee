using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timezone.Models;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "ComManager,Admin")]
    public class ShopMethodController : Controller
    {
        private readonly IShopMethodService shopMethodService;
        public ShopMethodController(IShopMethodService shopMethodService)
        {
            this.shopMethodService = shopMethodService;
        }

        #region Index
        public IActionResult Index()
        {
            List<ShopMethod> shopMethods = shopMethodService.GetAll();
            return View(shopMethods);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ShopMethodModel shopMethodModel)
        {
            #region Exist
            bool result = shopMethodService.GetAll().Any(x => x.Title == shopMethodModel.Title);
            if (result)
            {
                ModelState.AddModelError("Title", "Bu Metod hal-hazırda mövcuddur");
                return View();
            }
            #endregion

            ShopMethod shopMethod = new ShopMethod
            {
                Id = shopMethodModel.Id,
                Title = shopMethodModel.Title,
                Description = shopMethodModel.Description,
                Icon = shopMethodModel.Icon,
                IsDeactive = false
            };

            shopMethodService.Add(shopMethod);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            var dbShopMethod = shopMethodService.GetById(id);
            if (dbShopMethod is null) return BadRequest();

            ShopMethodModel dbModel = new ShopMethodModel    
            {
                Id = dbShopMethod.Id,
                Icon = dbShopMethod.Icon,
                Title = dbShopMethod.Title,
                Description = dbShopMethod.Description,
            };

            return View(dbModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,ShopMethodModel model)
        {
            #region Get
            var dbShopMethod = shopMethodService.GetById(id);
            if (dbShopMethod is null) return BadRequest();

            ShopMethodModel dbModel = new ShopMethodModel
            {
                Id = dbShopMethod.Id,
                Icon = dbShopMethod.Icon,
                Title = dbShopMethod.Title,
                Description = dbShopMethod.Description,
            };
            #endregion

            #region Exist
            bool result = shopMethodService.GetAll().Any(x => x.Title == model.Title && x.Id != id);
            if (result)
            {
                ModelState.AddModelError("Title", "Bu Metod hal-hazırda mövcuddur");
                return View();
            }
            #endregion

            dbModel.Id = model.Id;
            dbModel.Icon = model.Icon;
            dbModel.Title = model.Title;
            dbModel.Description = model.Description;

            ShopMethod shopMethod = new ShopMethod
            {
                Id = model.Id,
                Icon = model.Icon,
                Title = model.Title,
                Description = model.Description,
                IsDeactive = false
            };

            shopMethodService.Update(shopMethod);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            shopMethodService.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
