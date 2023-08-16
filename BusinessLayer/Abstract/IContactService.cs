using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        void Add(Contact contact);
        List<Contact> GetAll();
        Contact GetById(int id);
        void Delete(int id);
    }
}
