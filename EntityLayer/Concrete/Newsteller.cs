using CoreLayer.Entity;
using System;

namespace EntityLayer.Concrete
{
    public class Newsteller : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsDeactive { get; set; }
        public DateTime CreatedTime { get; set; }=DateTime.UtcNow.AddHours(4);
    }
}
