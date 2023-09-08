using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class ShopMethodManager : IShopMethodService
    {
        private readonly IShopMethodDal shopMethodDal;
        public ShopMethodManager(IShopMethodDal shopMethodDal)
        {
            this.shopMethodDal=shopMethodDal;
        }

        public void Activity(int id)
        {
            shopMethodDal.Activity(id);
        }

        public void Add(ShopMethod shopMethod)
        {
            shopMethodDal.Add(shopMethod);
        }

        public void Delete(int id)
        {
           shopMethodDal.Delete(GetById(id));
        }

        public List<ShopMethod> GetAll()
        {
            return shopMethodDal.GetAll();
        }

        public ShopMethod GetById(int id)
        {
            return shopMethodDal.Get(x => x.Id == id);
        }

        public void Update(ShopMethod shopMethod)
        {
            shopMethodDal.Update(shopMethod);
        }
    }
}
