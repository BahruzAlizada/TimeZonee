using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Timezone.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductController> logger;
        public ProductController(IProductService productService,ILogger<ProductController> logger)
        {
            this.productService = productService;
            this.logger = logger;
        }

        #region Index
        public IActionResult Index(string search ,int sort=1)
        {
            logger.LogInformation($"{DateTime.Now} - ProductController's index method is called");

            using var context = new Context();
            IQueryable<Product> productss = context.Products.Where(x=>!x.IsDeactive).Include(x=>x.Category).Include(x=>x.Gender).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                productss = productss.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            }


            int take = 18;
            ViewBag.ProductsCount = context.Products.Where(x =>!x.IsDeactive).ToList();
            ViewBag.Take = take;

            var productlist = productss.Where(x=>!x.IsDeactive).OrderByDescending(x=>x.Id).Take(take).ToList();
            return View(productlist);
        }
        #endregion

        #region ProductDetail
        public IActionResult Detail(int id)
        {
            var product = productService.GetProduct(id);
            return View(product);
        }
        #endregion

        #region LoadMore
        public IActionResult LoadMore(int skipCount)
        {
            using var context = new Context();

            int ProductsCount = context.Products.Where(x=>!x.IsDeactive).Count();
            if (skipCount >= ProductsCount)
                return Content(".");

            List<Product> products = context.Products.Include(x=>x.Category).Include(x=>x.Gender).Where(x=>!x.IsDeactive).
                OrderByDescending(x=>x.Id).Skip(skipCount).Take(18).ToList();
            return PartialView("_ProductsPartialView",products);
        }
        #endregion
    }
}
