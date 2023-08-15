using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IGaleryService
    {
        List<Galery> GetAll();
        Galery GetById(int id);
        void Add(Galery galery);
        void Update(Galery galery);
        void Delete(int id);
    }
}
