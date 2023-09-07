using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void Activity(int id)
        {
            productDal.Activity(id);
        }

        public void Add(Product product)
        {
            productDal.Add(product);
        }

        public List<Product> GetAll()
        {
            return productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return productDal.Get(x => x.Id == id);
        }

        public Product GetProduct(int id)
        {
            return productDal.GetProduct(id);
        }

        public List<Product> GetProducts()
        {
            return productDal.GetProducts();
        }

        public void Update(Product product)
        {
            productDal.Update(product);
        }
    }
}
