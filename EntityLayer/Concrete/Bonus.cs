using CoreLayer.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Bonus : IEntity
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public AppUser AppUser { get; set; }
        [ForeignKey("AppUser")]
        public int AppUserId { get; set; }
    }
}
