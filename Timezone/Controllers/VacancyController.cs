using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.Controllers
{
    public class VacancyController : Controller
    {
        private readonly IVacancyService vacancyService;
        private readonly ILogger<VacancyController> logger;
        public VacancyController(IVacancyService vacancyService,ILogger<VacancyController> logger)
        {
            this.vacancyService = vacancyService;
            this.logger = logger;
        }

        #region Index
        public IActionResult Index()
        {
            logger.LogInformation($"{DateTime.Now} - Vacancy Controller's Index Method is called");

            List<Vacancy> vacancies =  vacancyService.GetVacancies();
            return View(vacancies);
        }
        #endregion

        #region Detail
        public IActionResult Detail(int id)
        {
            logger.LogInformation($"{DateTime.Now} - Vacancy Controller's Detail Method is called");
            Vacancy vacancy = vacancyService.GetVacancy(id);
            return View(vacancy);
        }
        #endregion
    }
}
