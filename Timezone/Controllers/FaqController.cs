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
        public FaqController(IFaqService faqService, ILogger<FaqController> logger)
        {
            this.faqService = faqService;
          
            this.logger = logger;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            logger.LogInformation($"{DateTime.Now} - FaqsControlller's Index Method is called");

            var faqs = await faqService.GetAll();
            return View(faqs);
        }
        #endregion
    }
}
