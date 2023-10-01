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
        private readonly ILogger<ContactController> logger;
        public ContactController(IContactService contactService, ILogger<ContactController> logger)
        {
            this.contactService = contactService;
            this.logger = logger;
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
            logger.LogWarning("ContactController's Index method's post is called");
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
