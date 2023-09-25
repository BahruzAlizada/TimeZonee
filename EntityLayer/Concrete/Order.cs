using CoreLayer.Entity;
using System;

namespace EntityLayer.Concrete
{
	public class Order: IEntity
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		
		

		public AppUser User { get; set; }
	}
}
