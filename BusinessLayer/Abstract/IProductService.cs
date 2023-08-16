using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        
    }
}
