using Timezone.Domain.Common;
using Timezone.Domain.Identity;

namespace Timezone.Domain.Entities
{
	public class BasketItem : BaseEntity
	{
		public int AppUserId { get; set; }
		public int ProductId { get; set; }
		public double Price { get; set; }
		public int Count { get; set; }
		public AppUser AppUser { get; set; }
		public Product Product { get; set; }
	}
}
