using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IFaqDal : IRepositoryBase<Faq>
    {
        void Activity(int id);
    }
}
