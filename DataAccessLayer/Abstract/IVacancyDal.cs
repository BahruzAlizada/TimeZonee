using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IVacancyDal : IRepositoryBase<Vacancy>
    {
        void Activity(int id);
    }
}
