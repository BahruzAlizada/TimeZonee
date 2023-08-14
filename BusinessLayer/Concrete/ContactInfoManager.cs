using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class ContactInfoManager : IContactInfoService
    {
        private readonly IContactInfoDal contactInfoDal;
        public ContactInfoManager(IContactInfoDal contactInfoDal)
        {
            this.contactInfoDal = contactInfoDal;
        }

        public ContactInfo Get()
        {
            return contactInfoDal.Get();
        }

        public ContactInfo GetById(int id)
        {
            return contactInfoDal.Get(x => x.Id == id);
        }

        public void Update(ContactInfo contactInfo)
        {
            contactInfoDal.Update(contactInfo);
        }
    }
}
