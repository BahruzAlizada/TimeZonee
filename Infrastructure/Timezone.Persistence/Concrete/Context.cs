using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Timezone.Domain.Entities;
using Timezone.Domain.Identity;

namespace Timezone.Persistence.Concrete
{
	public class Context : IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-OK3QKVJ;Database=Timezone;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=True;");
		}

		public DbSet<Category> Categories { get;set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<BasketItem> BasketItems { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<About> About { get; set; }
		public DbSet<SocialMedia> socialMedias { get; set; }
		public DbSet<Faq> Faqs { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Subscribe> Subscribes { get; set; }
	}
}
