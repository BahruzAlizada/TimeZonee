using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class NewsletterManager : INewsletterService
    {
        private readonly INewsletterDal newsletterDal;
        public NewsletterManager(INewsletterDal newsletterDal)
        {
            this.newsletterDal = newsletterDal;
        }
        public void Add(Newsteller newsteller)
        {
            newsletterDal.Add(newsteller);
        }

        public void Delete(int id)
        {
            newsletterDal.Delete(newsletterDal.Get(x => x.Id == id));
        }

        public List<Newsteller> GetAll()
        {
            return newsletterDal.GetAll();
        }
    }
}
