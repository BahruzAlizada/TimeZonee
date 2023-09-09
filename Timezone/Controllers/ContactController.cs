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
        public ContactController(IContactService contactService)
        {
            this.contactService= contactService;
        }

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(ContactModel model)
        {

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
