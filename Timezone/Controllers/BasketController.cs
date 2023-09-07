using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;
using Timezone.ViewsModel;

namespace Timezone.Controllers
{
	public class BasketController : Controller
	{
		private readonly IProductService productService;
        public BasketController(IProductService productService)
        {
			this.productService = productService;
        }
        public IActionResult AddBasket(int id)
		{
			var product = productService.GetProduct(id);
			if (product is null) return NotFound();

			List<ProductVM> productVms = new List<ProductVM>();
			ProductVM prVM = null;

			if (Request.Cookies["Products"]!=null)
			{
				productVms = JsonConvert.DeserializeObject<List<ProductVM>>(Request.Cookies["Products"]);
				prVM = productVms.FirstOrDefault(x => x.Id == id);
			}

			return View();
		}
	}
}
