using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFShopMethodDal : EfRepositoryBase<ShopMethod, Context>, IShopMethodDal
    {
        public void Activity(int id)
        {
            using(var context = new Context())
            {
                var shopMethod = context.ShopMethods.FirstOrDefault(x => x.Id == id);
                if (shopMethod.IsDeactive)
                    shopMethod.IsDeactive = false;
                else
                    shopMethod.IsDeactive = true;

                context.SaveChanges();
            }
        }
    }
}
