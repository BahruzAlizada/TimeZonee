using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timezone.Models;

namespace Timezone.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "ContactManager,Admin")]
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
			List<Faq> faqs = faqService.GetFaqs().OrderByDescending(x=>x.Id).ToList();
			return View(faqs);
		}
		#endregion

		#region Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(FaqModel faqModel)
		{
			Faq faq = new Faq
			{
				Id = faqModel.Id,
				Quetsion = faqModel.Quetsion,
				Answer = faqModel.Answer,
				IsDeactive = false
			};

			faqService.Add(faq);
			return RedirectToAction("Index");
		}
		#endregion

		#region Update
		public IActionResult Update(int id)
		{
			var dbfaq = faqService.GetFaq(id);
			if (dbfaq == null) return NotFound();

			FaqModel dbModel = new FaqModel
			{
				Id = dbfaq.Id,
				Quetsion = dbfaq.Quetsion,
				Answer = dbfaq.Answer
			};

			return View(dbModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Update(int id,FaqModel model)
		{
            #region Get
            var dbfaq = faqService.GetFaq(id);
            if (dbfaq == null) return NotFound();

            FaqModel dbModel = new FaqModel
            {
                Id = dbfaq.Id,
                Quetsion = dbfaq.Quetsion,
                Answer = dbfaq.Answer
            };
			#endregion

			dbModel.Id = model.Id;
			dbModel.Answer = model.Answer;
			dbModel.Quetsion = model.Quetsion;

			Faq faq = new Faq
			{
				Id = model.Id,
				Answer = model.Answer,
				Quetsion = model.Quetsion,
				IsDeactive = false
			};

			faqService.Update(faq);
			return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
		{
			faqService.Activity(id);
			return RedirectToAction("Index");
		}
		#endregion
	}
}
