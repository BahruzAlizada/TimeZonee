using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Timezone.Controllers
{
    public class FaqController : Controller
    {
        private readonly IFaqService faqService;
        private readonly IMemoryCache memoryCache;
        private readonly ILogger<FaqController> logger;
        public FaqController(IFaqService faqService, IMemoryCache memoryCache, ILogger<FaqController> logger)
        {
            this.faqService = faqService;
            this.memoryCache = memoryCache;
            this.logger = logger;
        }

        #region Index
        public IActionResult Index()
        {
            List<Faq> faqs;

            if(!memoryCache.TryGetValue("faqs",out faqs))
            {
                faqs = faqService.GetFaqs().Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).ToList();

                var entryCacheOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(15),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(45),
                    Priority = CacheItemPriority.Normal,
                };

                memoryCache.Set("faqs", faqs, entryCacheOptions);
            }
             
            return View(faqs);
        }
        #endregion
    }
}
