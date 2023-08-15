using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFShopMethodDal : EfRepositoryBase<ShopMethod,Context>,IShopMethodDal
    {
    }
}
