using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Abstract
{
    public interface IContactInfoService
    {
        ContactInfo Get();
        ContactInfo GetById(int id);
        void Update(ContactInfo contactInfo);
    }
}
