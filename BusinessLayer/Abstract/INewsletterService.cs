using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface INewsletterService
    {
        List<Newsteller> GetAll();
        void Add(Newsteller newsteller);
        void Delete(int id);
    }
}
