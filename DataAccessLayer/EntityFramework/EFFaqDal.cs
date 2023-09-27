using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFFaqDal : EfRepositoryBase<Faq,Context>,IFaqDal
    {
        public void Activity(int id)
        {
            using var context = new Context();
            var faq = context.Faqs.FirstOrDefault(x=>x.Id==id);
            if (faq.IsDeactive)
                faq.IsDeactive = false;
            else
                faq.IsDeactive = true;

            context.SaveChanges();
        }
    }
}
