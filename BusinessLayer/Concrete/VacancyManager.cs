using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class VacancyManager : IVacancyService
    {
        private readonly IVacancyDal vacancyDal;
        public VacancyManager(IVacancyDal vacancyDal)
        {
            this.vacancyDal = vacancyDal;
        }

        public void Activity(int id)
        {
            vacancyDal.Activity(id);
        }

        public void Add(Vacancy vacancy)
        {
            vacancyDal.Add(vacancy);
        }

        public List<Vacancy> GetVacancies()
        {
            return vacancyDal.GetAll();
        }

        public Vacancy GetVacancy(int id)
        {
            return vacancyDal.Get(x => x.Id == id);
        }

        public void Remove(Vacancy vacancy)
        {
            vacancyDal.Delete(vacancy);
        }

        public void Update(Vacancy vacancy)
        {
            vacancyDal.Update(vacancy);
        }
    }
}
