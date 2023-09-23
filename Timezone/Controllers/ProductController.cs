using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            List<Product> products = productService.GetProducts();
            return View(products);
        }
        #endregion

        #region ProductDetail
        public IActionResult Detail(int id)
        {
            var product = productService.GetProduct(id);
            return View(product);
        }
        #endregion
    }
}
