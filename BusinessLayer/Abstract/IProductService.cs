using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Activity(int id);   
    }
}
