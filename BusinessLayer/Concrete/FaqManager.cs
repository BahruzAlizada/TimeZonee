using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;

namespace BusinessLayer.Concrete
{
    public class FaqManager : IFaqService
    {
        private readonly IFaqDal faqDal;
        private readonly IDistributedCache distributedCache;
        public FaqManager(IFaqDal faqDal,IDistributedCache distributedCache)
        {
            this.faqDal = faqDal;
            this.distributedCache = distributedCache;
        }

        const string cacheKey = "faqs";

        public void Activity(int id)
        {
           faqDal.Activity(id);
        }

        public void Add(Faq faq)
        {
            distributedCache.Remove(cacheKey);
            faqDal.Add(faq);
        }

        public void Delete(Faq faq)
        {
            faqDal.Delete(faq);
        }

        public async Task<List<Faq>> GetAll()
        {
            var cachedData = await distributedCache.GetStringAsync(cacheKey);
            List<Faq> faqs;

            if(cachedData is not null)
            {
                faqs = JsonConvert.DeserializeObject<List<Faq>>(cachedData);
                faqs = faqs.Where(x => !x.IsDeactive).ToList();
            }
            else
            {
                faqs = faqDal.GetAll().Where(x => !x.IsDeactive).ToList();

                await distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(faqs), new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(15),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(45)
                });
            }

            return faqs;
        }

        public Faq GetFaq(int id)
        {
            return faqDal.Get(x => x.Id == id);
        }

        public List<Faq> GetFaqs()
        {
            return faqDal.GetAll();
        }

        public void Update(Faq faq)
        {
            distributedCache.Remove(cacheKey);
            faqDal.Update(faq);
        }
    }
}
