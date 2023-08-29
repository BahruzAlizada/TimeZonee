using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepositoryBase<Category>
    {
        void Activity(int id);
    }
}
