using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using BusinessLayer.ValidationRule.FluentValidation;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "ProductManager,Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IProductImageService productImageService;
        private readonly IWebHostEnvironment env;
        public ProductController(IProductService productService, ICategoryService categoryService,IWebHostEnvironment env)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.env = env;
        }

        #region Index
        public IActionResult Index(string search, int page = 1)
        {
            List<Product> products = new List<Product>();
            if (!string.IsNullOrEmpty(search))
            {
                var prdct = from x in productService.GetAll() select x;
                products = productService.GetProducts().Where(x => x.Name.Contains(search)).OrderByDescending(x => x.Id).ToList();
                
                return View(products);
            }

            decimal take = 8;
            ViewBag.PageCount = Math.Ceiling(productService.GetAll().Count() / take);
            ViewBag.CurrentPage = page;
            products = productService.GetProducts().OrderByDescending(x => x.Id).Skip((page - 1) * (int)take).Take((int)take).ToList();

            return View(products);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            using(var context = new Context())
            {
                ViewBag.Categories = context.Categories.Where(x=>!x.IsDeactive).ToList();
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(int catId,Product product)
        {
            using (var context = new Context())
            {
                ViewBag.Categories = context.Categories.Where(x => !x.IsDeactive).ToList();

                #region Validator
                var validator = new ProductValidator();
                var result = validator.Validate(product);
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    return View();
                }
                #endregion

                #region Existed
                bool isExisted = context.Products.ToList().Any(x=>x.Name==product.Name);
                if (isExisted)
                {
                    ModelState.AddModelError("Name", "Bu adda product zatən var");
                    return View();
                }
                #endregion

                #region Image
                if (product.Photos == null)
                {
                    ModelState.AddModelError("Photos","Şəkil Seçin");
                    return View();
                }
                List<ProductImage> productImages = new List<ProductImage>();
                foreach (IFormFile photo in product.Photos)
                {
                    if (!photo.IsImage())
                    {
                        ModelState.AddModelError("Photos", "Sadəcə Şəkil tipli fayllar");
                        return View();
                    }
                    if (photo.IsOlder256Kb())
                    {
                        ModelState.AddModelError("Photos", "Max 256Kb");
                        return View();
                    }
                    string folder = Path.Combine(env.WebRootPath, "assets", "img", "product");
                    ProductImage image = new ProductImage
                    {
                        ProductId = product.Id,
                        Image = await photo.SaveFileAsync(folder)
                    };
                    productImages.Add(image);
                }
                product.ProductImages = productImages;
                #endregion

                product.CategoryId = catId;

                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            using(var context = new Context())
            {
                ViewBag.Categories = context.Categories.Where(x =>!x.IsDeactive).ToList();
                var dbproduct = context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
                if (dbproduct == null)
                    return BadRequest();

                return View(dbproduct);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id,int catId,Product product)
        {
            using (var context = new Context())
            {
                ViewBag.Categories = context.Categories.Where(x => !x.IsDeactive).ToList();
                var dbproduct = context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
                if (dbproduct == null)
                    return BadRequest();

                #region Validate
                var validator = new ProductValidator();
                var result = validator.Validate(product);
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    return View();
                }
                #endregion

                #region Existed
                bool isExisted = context.Products.ToList().Any(x=>x.Name == product.Name && x.Id!=id);
                if (isExisted)
                {
                    ModelState.AddModelError("Name", "Bu məhsul hal-hazırda mövcuddur");
                    return View();
                }
                #endregion

                #region Image
                if (product.Photos != null)
                {
                    List<ProductImage> productImages = new List<ProductImage>();
                    foreach (IFormFile photo in product.Photos)
                    {
                        if (!photo.IsImage())
                        {
                            ModelState.AddModelError("Photo", "Yanlız şəkil tipli fayllar");
                            return View();
                        }
                        if (photo.IsOlder256Kb())
                        {
                            ModelState.AddModelError("Photo", "Max 256Kb");
                            return View();
                        }
                        string folder = Path.Combine(env.WebRootPath, "assets", "img", "product");

                        ProductImage productImage = new ProductImage
                        {
                            Image = await photo.SaveFileAsync(folder)
                        };
                        productImages.Add(productImage);
                    }
                    dbproduct.ProductImages.AddRange(productImages);
                }
                #endregion

                dbproduct.Name = product.Name;
                dbproduct.Price = product.Price;
                dbproduct.Quantity = product.Quantity;
                dbproduct.IsDelivery = product.IsDelivery;
                dbproduct.IsStock = product.IsStock;
                dbproduct.IsFavorite=product.IsFavorite;
                dbproduct.IsMan = product.IsMan;
                dbproduct.IsChild = product.IsChild;
                dbproduct.CategoryId = catId;


                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            productService.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Image
        public IActionResult DeleteImage(int proImageId)
        {
            using var context = new Context();

            var proImage = context.ProductImages.FirstOrDefault(x => x.Id == proImageId);
            int count = context.ProductImages.Where(x => x.ProductId == proImage.ProductId).Count();
            if (count == 1)
                return Ok(".");
           
            context.ProductImages.Remove(proImage);
            context.SaveChanges();
           
            return Ok(count-1);
        }
        #endregion
    }
}
