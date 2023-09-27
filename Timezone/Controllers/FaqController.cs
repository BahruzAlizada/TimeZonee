using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.Controllers
{
    public class FaqController : Controller
    {
        private readonly IFaqService faqService;
        public FaqController(IFaqService faqService)
        {
            this.faqService = faqService;
        }

        #region Index
        public IActionResult Index()
        {
            List<Faq> faqs = faqService.GetFaqs().Where(x=>!x.IsDeactive).OrderByDescending(x => x.Id).ToList();
            return View(faqs);
        }
        #endregion
    }
}
