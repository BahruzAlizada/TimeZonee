using Microsoft.AspNetCore.Identity;
using Timezone.Domain.Entities;

namespace Timezone.Domain.Identity
{
	public class AppUser : IdentityUser<int>
	{
		public string FullName { get; set; }
		public string UserRole { get; set; }
		public bool Status { get; set; }
		public ICollection<BasketItem> BasketItems { get; set; }
	}
}
