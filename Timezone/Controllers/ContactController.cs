using BusinessLayer.Abstract;
using BusinessLayer.ValidationRule.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        private readonly IContactInfoService contactInfoService;
        public ContactController(IContactService contactService,IContactInfoService contactInfoService)
        {
            this.contactInfoService= contactInfoService;
            this.contactService= contactService;
        }

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(Contact contact)
        {
            var validator = new ContactValidator();
            var result = validator.Validate(contact);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
            contactService.Add(contact);
            return RedirectToAction("Index");
        }
        #endregion

      
    }
}
