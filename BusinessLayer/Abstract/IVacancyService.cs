using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Abstract
{
    public interface IVacancyService
    {
        Task<List<Vacancy>> GetAll();
        List<Vacancy> GetVacancies();
        Vacancy GetVacancy(int id);
        void Activity(int id);
        void Add(Vacancy vacancy);
        void Remove(Vacancy vacancy);
        void Update(Vacancy vacancy);
    }
}
