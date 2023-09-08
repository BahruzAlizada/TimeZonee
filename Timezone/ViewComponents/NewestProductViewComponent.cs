﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.ViewComponents
{
	public class NewestProductViewComponent : ViewComponent
	{
		private readonly IProductService productService;
        public NewestProductViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

		public IViewComponentResult Invoke()
		{
			var products = productService.GetProducts().Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).Take(3).ToList();
			return View(products);
		}
	}
}