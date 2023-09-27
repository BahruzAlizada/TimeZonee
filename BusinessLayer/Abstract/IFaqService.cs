using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IFaqService
    {
        List<Faq> GetFaqs();
        Faq GetFaq(int id);
        void Add(Faq faq);
        void Update(Faq faq);
        void Delete(Faq faq);
        void Activity(int id);
    }
}
