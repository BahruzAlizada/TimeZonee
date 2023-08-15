using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class GaleryManager : IGaleryService
    {
        private readonly IGaleryDal galeryDal;
        public GaleryManager(IGaleryDal galeryDal)
        {
            this.galeryDal = galeryDal;
        }

        public void Add(Galery galery)
        {
            galeryDal.Add(galery);
        }

        public void Delete(int id)
        {
            galeryDal.Delete(galeryDal.Get(x => x.Id == id));
        }

        public List<Galery> GetAll()
        {
            return galeryDal.GetAll();
        }

        public Galery GetById(int id)
        {
            return galeryDal.Get(x => x.Id == id);
        }

        public void Update(Galery galery)
        {
           galeryDal.Update(galery);
        }
    }
}
