using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Abstract
{
    public interface ISliderService
    {
        Slider Get();
        Slider GetById(int id);
        void Update(Slider slider);
    }
}
