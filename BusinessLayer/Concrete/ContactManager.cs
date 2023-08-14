using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal contactDal;
        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
           contactDal.Add(contact);
        }

        public List<Contact> GetAll()
        {
            return contactDal.GetAll();
        }

        public Contact GetById(int id)
        {
            return contactDal.Get(x => x.Id == id);
        }
    }
}
