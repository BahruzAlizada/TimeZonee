using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace BusinessLayer.Concrete
{
    public class BioManager : IBioService
    {
        private readonly IBioDal bioDal;
        private readonly IMemoryCache memoryCache;
        public BioManager(IBioDal bioDal,IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            this.bioDal = bioDal;
        }
        public void Add(Bio bio)
        {
            bioDal.Add(bio);
        }

        public Bio Get()
        {
            return bioDal.Get();
        }

        public Bio GetBio()
        {
            Bio bio;

            if(!memoryCache.TryGetValue("bio",out bio))
            {
                bio = bioDal.Get();

                var memoryCacheEntryOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(20),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                    Priority = CacheItemPriority.NeverRemove
                };

                memoryCache.Set("bio",bio, memoryCacheEntryOptions);
            }
            return bio;
        }

        public Bio GetById(int id)
        {
            return bioDal.Get(x => x.Id == id);
        }

        public void Update(Bio bio)
        {
            bioDal.Update(bio);
        }
    }
}
