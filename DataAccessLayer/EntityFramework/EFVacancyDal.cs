using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFVacancyDal : EfRepositoryBase<Vacancy, Context>, IVacancyDal
    {
        public void Activity(int id)
        {
            using var context = new Context();
            Vacancy vacancy = context.Vacancies.FirstOrDefault(x=>x.Id==id);
            if (vacancy.IsDeactive)
                vacancy.IsDeactive = false;
            else
                vacancy.IsDeactive = true;

            context.SaveChanges();
        }
    }
}
