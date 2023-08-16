using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        #region Index
        public IActionResult Index()
        {
            List<Contact> contacts = contactService.GetAll().OrderByDescending(x=>x.Id).ToList();
            return View(contacts);
        }
        #endregion

        #region Delete
        public IActionResult Detail(int id)
        {
            var contact = contactService.GetById(id);
            return View();
        }
        #endregion

        //#region Delete
        //public IActionResult Delete(int id)
        //{
        //    Contact contact = contactService.Delete(id);
        //    return View();
        //}
        //#endregion
    }
}
