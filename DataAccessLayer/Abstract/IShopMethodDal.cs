using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IShopMethodDal : IRepositoryBase<ShopMethod>
    {
        void Activity(int id);
    }
}
