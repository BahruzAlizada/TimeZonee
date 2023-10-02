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
            logger.LogInformation($"{DateTime.Now} - FaqsControlller's Index Method is called");

            const string key = "faqs";
            List<Faq> faqs;

            if(!memoryCache.TryGetValue(key,out faqs))
            {
                faqs = faqService.GetFaqs().Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).ToList();

                var memoryCacheEntryOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(10),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
                    Priority = CacheItemPriority.High
                };

                memoryCache.Set(key,faqs, memoryCacheEntryOptions);
            }
            return View(faqs);
        }
        #endregion
    }
}
