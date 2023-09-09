using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
	public class BasketItem : IEntity
	{
		public int Id { get; set; }
		public int AppUserId { get; set; }
		public int ProductId { get; set; }
		public double Price { get; set; }
		public int Count { get; set; }
		public AppUser AppUser { get; set; }
		public Product Product { get; set; }
	}
}
