using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Abstract
{
    public interface IProductImageService
    {
        void Add(ProductImage productImage);
        void Update(ProductImage productImage);
    }
}
