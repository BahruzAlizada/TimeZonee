using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFCategoryDal : EfRepositoryBase<Category, Context>, ICategoryDal
    {
        public void Activity(int id)
        {
            using(var context = new Context())
            {
                var category = context.Categories.FirstOrDefault(x=>x.Id == id);
                if (category.IsDeactive)
                    category.IsDeactive = false;
                else
                    category.IsDeactive = true;

                context.SaveChanges();
            }
        }
    }
}
