using BusinessLayer.Abstract;
using BusinessLayer.ValidationRule.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Timezone.Models;

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
            ContactInfo info = contactInfoService.Get();
            ViewBag.EmailInfo = info.Email;
            ViewBag.PhoneInfo = info.Phone;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(ContactModel model)
        {
            ContactInfo info = contactInfoService.Get();
            ViewBag.EmailInfo = info.Email;
            ViewBag.PhoneInfo = info.Phone;

            Contact contact = new Contact
            {
                Id = model.Id,
                Subject = model.Subject,
                Message = model.Message,
                FullName = model.FullName,
                Email = model.Email,
            };
            
            contactService.Add(contact);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
