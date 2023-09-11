using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsDeactive { get; set; }
        public List<Comment> Comments { get; set; }
        public List<BasketItem> BasketItems { get; set; }   
        public Bonus Bonus { get; set; }
    }
}
