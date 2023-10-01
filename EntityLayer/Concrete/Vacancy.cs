using CoreLayer.Entity;
using System;

namespace EntityLayer.Concrete
{
    public class Vacancy : IEntity
    {
        public int Id { get; set; }
        public string VacancyName { get; set; }
        public string Required { get; set; }
        public string VacancyDescription { get; set; }
        public string Salary { get; set; }
        public DateTime CreatedTime { get; set; }=DateTime.UtcNow.AddHours(4);
        public  string Email { get; set; }
        public bool IsDeactive { get; set; }
    }
}
