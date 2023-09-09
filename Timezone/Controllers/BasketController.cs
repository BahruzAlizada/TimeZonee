using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;
using Timezone.ViewsModel;

namespace Timezone.Controllers
{
	public class BasketController : Controller
	{
		private readonly IProductService productService;
		private readonly UserManager<AppUser> userManager;
        public BasketController(IProductService productService,UserManager<AppUser> userManager)
        {
			this.productService = productService;
			this.userManager = userManager;
        }

		#region Index
		public async Task<IActionResult> Index()
		{
			using var context = new Context();
			List<BasketItemVM> basketItemVMs = new List<BasketItemVM>();

			if (User.Identity.IsAuthenticated)
			{
				AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
				List<BasketItem> basketItems = await context.BasketItems.Where(x=>x.AppUserId==user.Id).
					Include(x=>x.Product).ThenInclude(x=>x.ProductImages).ToListAsync();

				foreach (var item in basketItems)
				{
					basketItemVMs.Add(new BasketItemVM
					{
						ProductId=item.Product.Id,
						Count=item.Count,
						Price=item.Price,
						Image = item.Product.ProductImages[0].Image,
						ProductName=item.Product.Name
					});
				}
			}
			return View(basketItemVMs);
		}
		#endregion

		#region AddBasket
		public async Task<IActionResult> AddBasket(int? id)
		{
			using(var context = new Context())
			{
				if (id is null || id < 1) return BadRequest();
				Product product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
				if (product is null) return NotFound();

				if (User.Identity.IsAuthenticated)
				{
					AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

					var existed = await context.BasketItems.FirstOrDefaultAsync(x=>x.ProductId==product.Id && x.AppUserId == user.Id);
					if(existed is not null)
					{
						existed.Count++;
					}
					else
					{
						existed = new BasketItem
						{
							AppUserId = user.Id,
							ProductId = product.Id,
							Price = product.Price,
							Count = 1
						};
						await context.BasketItems.AddAsync(existed);
					}
				}
				await context.SaveChangesAsync();
				return RedirectToAction("Index", "Home");
			}
		}
		#endregion

		#region PlusProductCount
		public async Task<IActionResult> PlusProductCount(int? id)
		{
			using var context = new Context();
			if (id is null || id < 1) return BadRequest();
			Product product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
			if (product is null) return NotFound();

			if (User.Identity.IsAuthenticated)
			{
				AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

				var existed = await context.BasketItems.FirstOrDefaultAsync(x => x.ProductId == product.Id && x.AppUserId == user.Id);
				if (existed is not null)
				{
					existed.Count++;
				}
			}
			await context.SaveChangesAsync();
			return RedirectToAction("Index", "Basket");
		}
        #endregion

        #region MinusProductCount
        public async Task<IActionResult> MinusProductCount(int? id)
        {
            using var context = new Context();
            if (id is null || id < 1) return BadRequest();
            Product product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product is null) return NotFound();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

                BasketItem basketItem = await context.BasketItems.FirstOrDefaultAsync(x => x.ProductId == product.Id && x.AppUserId == user.Id);
                if (basketItem is not null)
                {
                    basketItem.Count--;
					if(basketItem.Count == 0)
					{
						context.BasketItems.Remove(basketItem);
					}
                }
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Basket");
        }
        #endregion

        #region DeleteProduct
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            using var context = new Context();
            if (id is null || id < 1) return BadRequest();
            Product product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product is null) return NotFound();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

                BasketItem basketItem = await context.BasketItems.FirstOrDefaultAsync(x => x.ProductId == product.Id && x.AppUserId == user.Id);
                if (basketItem is not null)
                {
                    context.BasketItems.Remove(basketItem);
                }
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Basket");
        }
		#endregion

		#region ClearBasket
		public async Task<IActionResult> ClearBasket()
		{
            using var context = new Context();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

                var basketItem = await context.BasketItems.Where(x => x.AppUserId == user.Id).ToListAsync();
                if (basketItem is not null)
                {
                    context.BasketItems.RemoveRange(basketItem);
                }
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Basket");
        }
		#endregion
	}
}
