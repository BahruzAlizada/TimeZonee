using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal socialMediaDal;
        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            this.socialMediaDal= socialMediaDal;
        }

        public SocialMedia Get()
        {
           return socialMediaDal.Get();
        }

        public SocialMedia GetById(int id)
        {
            return socialMediaDal.Get(x => x.Id == id);
        }

        public void Update(SocialMedia media)
        {
            socialMediaDal.Update(media);
        }
    }
}
