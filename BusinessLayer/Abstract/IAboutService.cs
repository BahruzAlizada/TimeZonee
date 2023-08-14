using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        About Get();
        About GetById(int id);
        void Update(About about);
    }
}
