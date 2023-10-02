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
        public bool IsSalesAccount { get; set; } = false;
        public bool IsVerify { get; set; } = false;
        public string? Image { get; set; }
        public string? Bio { get; set; }
        public List<Comment> Comments { get; set; }
        public List<BasketItem> BasketItems { get; set; }   
        public Bonus Bonus { get; set; }
    }
}
