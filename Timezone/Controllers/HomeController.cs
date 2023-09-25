using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Timezone.Models;

namespace Timezone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsletterService newsletterService;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger,INewsletterService newsletterService,IProductService productService)
        {
            _logger = logger;
            this.newsletterService = newsletterService;
            this.productService = productService;
        }

        #region Index
        public IActionResult Index()
        {
            var products = productService.GetProducts().Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).Take(6).ToList();
            return View(products);
        }
        #endregion

        #region Subscripe
        public async Task<IActionResult> Subscripe(string email)
        {
            if (email == null)
                return Content("Email boş ola bilməz");

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (!match.Success)
                return Content("Email adresini düzgün qeyd edin");
            else
            {
                Newsteller newsteller = new Newsteller { Email = email };

                bool isExist = newsletterService.GetAll().Any(x=>x.Email==email);
                if (isExist)
                    return Content("Siz artıq bizə abunə olmusunuz");

                newsletterService.Add(newsteller);

                List<Newsteller> newstellers = newsletterService.GetAll();
                string message = "Yeni blog və productlarla tanış olmaq üçün səhifəmizə daxil ola bilərsiniz";
                string title = "Salam Əziz İzləyicimiz";
                foreach (Newsteller sub in newstellers)
                {
                    await SendMail.SendMailAsync(title, message, sub.Email);
                }
            }
            return Content("Ok");
        }
        #endregion


        public IActionResult Error()
        {
            return View();
        }
    }
}