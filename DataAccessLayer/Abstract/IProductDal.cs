using Core.DataAccess;
using EntityLayer.Concrete;
using System;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IRepositoryBase<Product>
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        void Activity(int id);
    }
}
