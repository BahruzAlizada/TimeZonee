using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private readonly IProductImageDal productImageDal;
        public ProductImageManager(IProductImageDal productImageDal)
        {
            this.productImageDal=productImageDal;
        }

        public void Add(ProductImage productImage)
        {
            productImageDal.Add(productImage);  
        }

        public void Update(ProductImage productImage)
        {
            productImageDal.Update(productImage);
        }
    }
}
