using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Timezone.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        #region Index
        public IActionResult Index(string search ,int sort=1)
        {
            using var context = new Context();
            IQueryable<Product> productss = context.Products.Where(x=>!x.IsDeactive).Include(x=>x.Category).Include(x=>x.ProductImages).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                productss = productss.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            }

            switch (sort)
            {
                case 2:
                    productss.Where(x => x.IsMan);
                    break;
                case 3:
                    productss.Where(x => !x.IsMan);
                    break;
                case 4:
                    productss.OrderBy(x => x.Price);
                    break;
                case 5:
                    productss.OrderByDescending(x => x.Price);
                    break;
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

            List<Product> products = context.Products.Include(x=>x.Category).Include(x=>x.ProductImages).Where(x=>!x.IsDeactive).
                OrderByDescending(x=>x.Id).Skip(skipCount).Take(18).ToList();
            return PartialView("_ProductsPartialView",products);
        }
        #endregion
    }
}
