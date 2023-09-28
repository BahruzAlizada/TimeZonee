using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IBioService
    {
        Bio GetBio();
        Bio Get();
        Bio GetById(int id);
        void Add(Bio bio);
        void Update(Bio bio);
    }
}
