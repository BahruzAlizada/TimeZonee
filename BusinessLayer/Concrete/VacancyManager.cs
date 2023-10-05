using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;

namespace BusinessLayer.Concrete
{
    public class VacancyManager : IVacancyService
    {
        private readonly IVacancyDal vacancyDal;
        private readonly IDistributedCache distributedCache;
        public VacancyManager(IVacancyDal vacancyDal,IDistributedCache distributedCache)
        {
            this.vacancyDal = vacancyDal;
            this.distributedCache = distributedCache;
        }

        public void Activity(int id)
        {
            vacancyDal.Activity(id);
        }

        public void Add(Vacancy vacancy)
        {
            vacancyDal.Add(vacancy);
        }

        public async Task<List<Vacancy>> GetAll()
        {
            const string cacheKey = "vacancies";
            List<Vacancy> vacancies;

            var cachedData = await distributedCache.GetStringAsync(cacheKey);

            if (cachedData is not null)
            {
                vacancies = JsonConvert.DeserializeObject<List<Vacancy>>(cachedData);
                vacancies = vacancies.Where(x =>!x.IsDeactive).OrderByDescending(x => x.IsDeactive).ToList();
            }
            else
            {
                vacancies = vacancyDal.GetAll().Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).ToList();

                await distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(vacancies), new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(15),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(50)
                });
            }

            return vacancies;
        }

        public List<Vacancy> GetVacancies()
        {
            return vacancyDal.GetAll();
        }

        public Vacancy GetVacancy(int id)
        {
            return vacancyDal.Get(x => x.Id == id);
        }

        public void Remove(Vacancy vacancy)
        {
            vacancyDal.Delete(vacancy);
        }

        public void Update(Vacancy vacancy)
        {
            vacancyDal.Update(vacancy);
        }
    }
}
