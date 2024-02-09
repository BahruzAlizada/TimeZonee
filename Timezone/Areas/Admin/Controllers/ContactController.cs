using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "ContactManager,Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        #region Index
        public IActionResult Index(int page=1)
        {
            double take = 15;
            ViewBag.PageCount = Math.Ceiling(contactService.GetAll().Count / take);
            ViewBag.CurrentPage = page;

            List<Contact> contacts = contactService.GetAll().OrderByDescending(x => x.Id).
                Skip((page - 1) * (int)take).Take((int)take).ToList();
            return View(contacts);
        }
        #endregion

        #region Delete
        public IActionResult Detail(int id)
        {
            var contact = contactService.GetById(id);
            return View(contact);
        }
        #endregion

        #region Delete
        //public IActionResult Delete(int id)
        //{
        //    Contact contact = contactService.Delete(id);
        //    return View();
        //}
        #endregion
    }
}
