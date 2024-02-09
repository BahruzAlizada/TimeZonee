using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Timezone.Domain.Common;

namespace Timezone.Domain.Entities
{
	public class Product : BaseEntity
	{
		public int CategoryId { get; set; }
		public int GenderId { get; set; }

		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public double Price { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public int Quantity { get; set; }
		public string Image { get; set; }
		//[NotMapped]
		//public IFormFile Photo { get; set; }
		public bool IsDelivery { get; set; }

		public Category Category { get; set; }
		public Gender Gender { get; set; }
	}
}
