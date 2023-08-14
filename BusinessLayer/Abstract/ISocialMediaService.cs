using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface ISocialMediaService
    {
        SocialMedia Get();
        SocialMedia GetById(int id);
        void Update(SocialMedia media);
    }
}
