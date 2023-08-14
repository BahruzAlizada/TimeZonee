using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            this.sliderDal = sliderDal;
        }
        public Slider Get()
        {
            return sliderDal.Get();
        }

        public Slider GetById(int id)
        {
            return sliderDal.Get(x => x.Id == id);
        }

        public void Update(Slider slider)
        {
            sliderDal.Update(slider);
        }
    }
}
