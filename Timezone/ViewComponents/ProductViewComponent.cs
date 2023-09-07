using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductService productService;
        public ProductViewComponent(IProductService productService)
        {
            this.productService= productService;
        }

        public IViewComponentResult Invoke()
        {
            var products = productService.GetProducts().Where(x=>!x.IsDeactive).OrderByDescending(x=>x.Id).Take(6).ToList();
            return View(products);
        }
    }
}
