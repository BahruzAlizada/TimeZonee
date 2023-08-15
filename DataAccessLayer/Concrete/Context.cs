using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OK3QKVJ;Database=Timezone;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=True;");
        }

        public DbSet<Slider> Sliders { get;set; }
        public DbSet<Galery> Galeries { get;set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Newsteller> Newstellers { get;set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<ShopMethod> ShopMethods { get; set; }
    }
}
