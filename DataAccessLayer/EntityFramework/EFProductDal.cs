using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer.EntityFramework
{
    public class EFProductDal : EfRepositoryBase<Product, Context>, IProductDal
    {
        public void Activity(int id)
        {
            using(var context = new Context())
            {
                var product = context.Products.FirstOrDefault(x=>x.Id == id);
                if (product.IsDeactive)
                    product.IsDeactive = false;
                else
                   product.IsDeactive = true;

                context.SaveChanges();
            }
        }

        public Product GetProduct(int id)
        {
           using(var context = new Context())
            {
                var product = context.Products.Include(x=>x.Category).Include(x=>x.ProductImages).FirstOrDefault(x=>x.Id==id);
                return product;
            }
        }

        public List<Product> GetProducts()
        {
            using(var context = new Context())
            {
                var products = context.Products.Include(x => x.ProductImages).Include(x => x.Category).ToList();
                return products;
            }
        }
    }
}
