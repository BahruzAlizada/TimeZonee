using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IShopMethodService 
    {
        List<ShopMethod> GetAll();
        ShopMethod GetById(int id);
        void Add(ShopMethod shopMethod);
        void Update(ShopMethod shopMethod);
        void Delete(int id);
        void Activity(int id);
    }
}
