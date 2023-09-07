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
    }
}
