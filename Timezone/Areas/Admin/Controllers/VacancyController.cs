using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timezone.Models;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="ContactManager,Admin")]
    public class VacancyController : Controller
    {
        private readonly IVacancyService vacancyService;
        public VacancyController(IVacancyService vacancyService)
        {
            this.vacancyService=vacancyService;
        }

        #region Index
        public IActionResult Index()
        {
            var vacancies = vacancyService.GetVacancies().OrderByDescending(x=>x.Id).ToList();
            return View(vacancies);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(VacancyModel model)
        {
            Vacancy vacancy = new Vacancy
            {
                Id = model.Id,
                VacancyName = model.VacancyName,
                Required = model.Required,
                VacancyDescription = model.VacancyDescription,
                CreatedTime = model.CreatedTime,
                Salary = model.Salary,
                Email = model.Email
            };

            vacancyService.Add(vacancy);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            Vacancy dbVacancy = vacancyService.GetVacancy(id);
            if (dbVacancy is null) return NotFound();

            VacancyModel dbModel = new VacancyModel
            {
                Id = dbVacancy.Id,
                VacancyName = dbVacancy.VacancyName,
                Email = dbVacancy.Email,
                Required = dbVacancy.Required,
                VacancyDescription = dbVacancy.VacancyDescription,
                Salary = dbVacancy.Salary
            };

            return View(dbModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,VacancyModel model)
        {
            #region Get
            Vacancy dbVacancy = vacancyService.GetVacancy(id);
            if (dbVacancy is null) return NotFound();

            VacancyModel dbModel = new VacancyModel
            {
                Id = dbVacancy.Id,
                VacancyName = dbVacancy.VacancyName,
                Email = dbVacancy.Email,
                Required = dbVacancy.Required,
                VacancyDescription = dbVacancy.VacancyDescription,
                Salary = dbVacancy.Salary
            };
            #endregion

            dbModel.Id = model.Id;
            dbModel.VacancyName = model.VacancyName;
            dbModel.Required = model.Required;
            dbModel.VacancyDescription = model.VacancyDescription;
            dbModel.Salary = model.Salary;
            dbModel.Email = model.Email;
            dbModel.CreatedTime = model.CreatedTime;

            Vacancy vacancy = new Vacancy
            {
                Id = model.Id,
                VacancyName = model.VacancyName,
                Required = model.Required,
                VacancyDescription = model.VacancyDescription,
                CreatedTime = model.CreatedTime,
                Salary = model.Salary,
                Email = model.Email
            };

            vacancyService.Update(vacancy);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            var vacancy = vacancyService.GetVacancy(id);
            vacancyService.Remove(vacancy);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            vacancyService.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
