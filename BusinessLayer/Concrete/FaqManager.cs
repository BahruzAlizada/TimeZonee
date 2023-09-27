using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class FaqManager : IFaqService
    {
        private readonly IFaqDal faqDal;
        public FaqManager(IFaqDal faqDal)
        {
            this.faqDal = faqDal;
        }

        public void Activity(int id)
        {
           faqDal.Activity(id);
        }

        public void Add(Faq faq)
        {
            faqDal.Add(faq);
        }

        public void Delete(Faq faq)
        {
            faqDal.Delete(faq);
        }

        public Faq GetFaq(int id)
        {
            return faqDal.Get(x => x.Id == id);
        }

        public List<Faq> GetFaqs()
        {
            return faqDal.GetAll();
        }

        public void Update(Faq faq)
        {
            faqDal.Update(faq);
        }
    }
}
